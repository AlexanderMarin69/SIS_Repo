﻿import InvoiceAPI from '@/services/invoice'
export default {
    ADD_PRODUCT_TO_LIST({ commit }, item) {
    /*eslint no-debugger: */
        //debugger;
        commit('SET_NEW_PRODUCT_TO_LIST', item);
    },
    REMOVE_PRODUCT_FROM_LIST({ commit }, object ) {
    /*eslint no-debugger: */
        //debugger;
        // custom console
        // eslint-disable-next-line no-console
        console.log(object, 'inserted object');
        commit('REMOVE_PRODUCT_FROM_LIST', object)
    },
    GET_ALL_INVOICES({ commit }) {
        return InvoiceAPI.GetAllInvoices()
            .then(result => {

                // custom console
                // eslint-disable-next-line no-console
                console.log(result)
                commit('SET_ALL_USER_INVOICES', result);
            }).catch(result => {
                // eslint-disable-next-line no-console
                console.log(result)
            })
    },
    //SEARCH_WAREHOUSE({ commit }, data) {
    //    return ProductAPI.SearchProducts(data)
    //        .then(result => {
    //            commit('SET_WAREHOUSE_PRODUCTS_TO_SEARCH_RESULTS', result);
    //        }).catch(result => {
    //            // eslint-disable-next-line no-console
    //            console.log(result)
    //        })
    //},

    SEARCH_CUSTOMERS({ commit }, data) {
        return InvoiceAPI.SearchCustomers(data)
            .then(result => {
                // custom console
                // eslint-disable-next-line no-console
                console.log(result)
                commit('SET_ALL_USER_CUSTOMERS_TO_SEARCH_RESULTS', result);
            }).catch((result) => {
                // custom console
                // eslint-disable-next-line no-console
                console.log(result)

            });
    },

    //GET_ALL_PRODUCTS({ commit }) {
    //    return ProductAPI.SearchProducts()
    //        .then(result => {
    //            commit('SET_WAREHOUSE_PRODUCTS_TO_SEARCH_RESULTS', result);
    //        }).catch(result => {
    //            // eslint-disable-next-line no-console
    //            console.log(result)
    //        })
    //}, 
}


