import Vue from 'vue';
import Router from 'vue-router';

import store from '../store/index'

import Start from '@/Views/Start'
import Products from '@/Views/Products'
import Customers from '@/Views/Customers'
import Settings from '@/Views/Settings'
import Dashboard from '@/Views/Dashboard'

import RegisterUserForm from '../components/RegisterUserForm'
import Login from '@/components/Login'


Vue.use(Router);

const router = new Router({
    mode: 'history',
    base: process.env.BASE_URL,
    routes: [
        //{
        //    path: '/',
        //    name: 'start',
        //    component: () => import('@/Views/Start.vue')
        //},

        {
            path: '/',
            name: 'start',
            component: Start,
            async beforeEnter(to, from, next) {
                var hasPermission = await store.dispatch('login/USER_IS_LOGGED_IN');
                        if (hasPermission) {
                            next()
                        }

                if (!hasPermission) {
                    //TODO: Might send user to the configurator instead of login
                    next({
                        name: "login", // back to safety route //
                        query: { redirectFrom: to.fullPath }
                    })
                }
                
            }
        },

        {
            path: '/register',
            name: 'register',
            component: RegisterUserForm
        },
        {
            path: '/login',
            name: 'login',
            component: Login
        },
        {
            path: '/products',
            name: 'products',
            component: Products,
             async beforeEnter(to, from, next) {
                var hasPermission = await store.dispatch('login/USER_IS_LOGGED_IN');
                if (hasPermission) {
                    next()
                }

                if (!hasPermission) {
                    //TODO: Might send user to the configurator instead of login
                    next({
                        name: "login", // back to safety route //
                        query: { redirectFrom: to.fullPath }
                    })
                }

            }
        },
        {
            path: '/customers',
            name: 'customers',
            component: Customers,
            async beforeEnter(to, from, next) {
                var hasPermission = await store.dispatch('login/USER_IS_LOGGED_IN');
                if (hasPermission) {
                    next()
                }

                if (hasPermission == false) {
                    //TODO: Might send user to the configurator instead of login
                    next({
                        name: "login", // back to safety route //
                        query: { redirectFrom: to.fullPath }
                    })
                }

            }
        },
        {
            path: '/settings',
            name: 'settings',
            component: Settings,
            async beforeEnter(to, from, next) {
                var hasPermission = await store.dispatch('login/USER_IS_LOGGED_IN');
                if (hasPermission) {
                    next()
                }

                if (!hasPermission) {
                    //TODO: Might send user to the configurator instead of login
                    next({
                        name: "login", // back to safety route //
                        query: { redirectFrom: to.fullPath }
                    })
                }

            }
        },
        {
            path: '/dashboard',
            name: 'dashboard',
            component: Dashboard,
            async beforeEnter(to, from, next) {
                var hasPermission = await store.dispatch('login/USER_IS_LOGGED_IN');
                if (hasPermission) {
                    next()
                }

                if (!hasPermission) {
                    //TODO: Might send user to the configurator instead of login
                    next({
                        name: "login", // back to safety route //
                        query: { redirectFrom: to.fullPath }
                    })
                }

            }
        },
        //{
        //    path: '/details/:id',
        //    name: 'details',
        //    // route level code-splitting
        //    // this generates a separate chunk (about.[hash].js) for this route
        //    // which is lazy-loaded when the route is visited.
        //    component: () => import(/* webpackChunkName: "about" */ './views/ArticleDetails.vue')
        //}
    ]
});

//router.beforeEach((to, from, next) => {
//    store.dispatch("login/GET_USERDATA");
//    next()
//});

export default router;