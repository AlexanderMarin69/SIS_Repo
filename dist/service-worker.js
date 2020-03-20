'use strict';

// CODELAB: Update cache names any time any of the cached files change.
const CACHE_NAME = 'static-cache-v1';

// CODELAB: Add list of files to cache here.
const FILES_TO_CACHE = [
    '/offline.html',
];

//const installButton = document.getElementById('mannen');
//const installButton2 = document.getElementById('kanin');
//installButton.removeAttribute('hidden');

//fic updates on actions in allinvoices etc on frontend and test reliability for service worker then

self.addEventListener('install', (evt) => {

    //dbPromise = idb.open('invoices', 1, db => {
    //    const invoice = db.createObjectStore('invoice', {
    //        keyPath: 'articleNumber'
    //    });

    console.log('[ServiceWorker] Install');

    caches.delete(CACHE_NAME).then(function (boolean) {
        console.log('Cache reset');
    })

    // CODELAB: Precache static resources here.
    //evt.waitUntil(
    //    caches.open(CACHE_NAME).then((cache) => {
    //        console.log('[ServiceWorker] Pre-caching offline page');
    //        return cache.addAll(FILES_TO_CACHE);
    //    })
    //);
    self.skipWaiting();
});

self.addEventListener('activate', (evt) => {
    console.log('[ServiceWorker] Activate');
    // CODELAB: Remove previous cached data from disk.
    //evt.waitUntil(
    //caches.keys().then((keyList) => {
    //    return Promise.all(keyList.map((key) => {
    //        if (key !== CACHE_NAME) {
    //            console.log('[ServiceWorker] Removing old cache', key);
    //            return caches.delete(key);
    //        }
    //    }));
    //})
    caches.delete(CACHE_NAME).then(function (boolean) {
        console.log('Cache reset');
    })
    //);
    self.clients.claim();
});

self.addEventListener('fetch', (event) => {
    event.respondWith(
        caches.open(CACHE_NAME).then(cache => {
            return cache.match(event.request).then(response => {
                const fetchPromise = fetch(event.request)
                    .then(networkResponse => {
                        cache.put(event.request, networkResponse.clone());
                        return networkResponse;
                    });
                return response || fetchPromise;
                //switch order?
            })
        })
    )
});





    // ORIGINAL CODE
    //console.log('[ServiceWorker] Fetch', evt.request.url);
    //// CODELAB: Add fetch event handler here.
    //if (evt.request.mode !== 'navigate') {
    //    // Not a page navigation, bail.
    //    return;
    //}
    //evt.respondWith(
    //    fetch(evt.request)
    //        .catch(() => {
    //            return caches.open(CACHE_NAME)
    //                .then((cache) => {
    //                    return cache.match('offline.html');
    //                });
    //        })



    //);



   // cache pages on navigation for offline
        //caches.match(evt.request).then(cachesRes => {
        //    return cachesRes || fetch(evt.request).then(fetchRes => {
        //        return caches.open(dynamicCache).then(cache => {
        //            cache.put(evt.request.url, fetchRes.clone());
        //            return fetchRes;
        //        })
        //    });
        //})