import InvoiceAPI from '@/services/invoice'
export default {
    ADD_PRODUCT_TO_LIST({ commit }, item) {
    /*eslint no-debugger: */
        //debugger;
        commit('SET_NEW_PRODUCT_TO_LIST', item);
    },
    UPDATE_PRODUCT_PRICE_FROM_LIST({ commit }, object ) {
        commit('UPDATE_PRODUCT_PRICE_FROM_LIST', object)
    },
    //UPDATE_INVOICE_FEE({ commit }, invoiceFee) {
    //    commit('UPDATE_INVOICE_FEE', invoiceFee)
    //},
    //UPDATE_DELIVERY_FEE({ commit }, deliveryFee) {
    //    commit('UPDATE_DELIVERY_FEE', deliveryFee)
    //},
    UPDATE_PRODUCT_QUANTITY_FROM_LIST({ commit }, object) {
        commit('UPDATE_PRODUCT_QUANTITY_FROM_LIST', object)
    },
    REMOVE_PRODUCT_FROM_LIST({ commit }, object) {
        commit('REMOVE_PRODUCT_FROM_LIST', object)
    },
    RESET_INVOICE_PRODUCT_LIST_ON_ENTER({ commit }) {
        commit('RESET_INVOICE_PRODUCT_LIST')
    },
    CALCULATE_TOTAL_INVOICE_ITEMS_PRICE({ commit }) {
        commit('CALCULATE_TOTAL_INVOICE_ITEMS_PRICE')
    }, 
    GET_ALL_INVOICES({ commit }) {
        return InvoiceAPI.GetAllInvoices()
            .then(result => {

                // custom console
                // eslint-disable-next-line no-console
                console.log(result, 'INVOICESSSSSS')
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
    SET_INVOICE_PDF_GUID({ commit }, data) {
        commit('SET_INVOICE_PDF_GUID', data);
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


