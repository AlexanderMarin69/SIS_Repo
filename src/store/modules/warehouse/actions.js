﻿import ProductAPI from '@/services/Product'
export default {
    GET_ALL_PRODUCTS({ commit }) {
        return ProductAPI.GetAllProducts()
            .then(result => {

                // custom console
                // eslint-disable-next-line no-console
                commit('SET_WAREHOUSE_PRODUCTS', result);
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

    SEARCH_WAREHOUSE({ commit }, data) {
        return ProductAPI.SearchProducts(data)
            .then(result => {
                // custom console
                // eslint-disable-next-line no-console
                console.log(result)
                commit('SET_WAREHOUSE_PRODUCTS_TO_SEARCH_RESULTS', result);
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


