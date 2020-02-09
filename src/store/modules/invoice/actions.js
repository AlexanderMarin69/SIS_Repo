import InvoiceAPI from '@/services/invoice'
export default {
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


