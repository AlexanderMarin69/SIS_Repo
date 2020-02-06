import CustomerAPI from '@/services/Customer'
export default {
    GET_ALL_CUSTOMERS({ commit }) {
        return CustomerAPI.GetAllCustomers()
            .then(result => {

                // custom console
                // eslint-disable-next-line no-console
                console.log(result)
                commit('SET_ALL_USER_CUSTOMERS', result);
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
        return CustomerAPI.SearchCustomers(data)
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


