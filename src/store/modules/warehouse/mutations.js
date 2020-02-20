export default {
    SET_WAREHOUSE_PRODUCTS(state, products) {
        //for (var i = 0; i < state.warehouseProducts.length; i++) {
        //    state.InvoiceProducts.splice(0, state.InvoiceProducts.length);
        //}

        // custom console
        // eslint-disable-next-line no-console
        console.log(products, 'incoming products on get');

        // custom console
        // eslint-disable-next-line no-console
        console.log(state.warehouseProducts, 'state.warehouseProducts');
        state.warehouseProducts = products;

        // custom console
        // eslint-disable-next-line no-console
        console.log(state.warehouseProducts, 'state after set mutation');
        state.warehouseProducts = products;
    },
    SET_WAREHOUSE_PRODUCTS_TO_SEARCH_RESULTS(state, products) {
        state.warehouseProducts = products;
    },
    DELETE_PRODUCT_FROM_LIST(state, productArticleNumber) {

        if (state.warehouseProducts.find(x => x.articleNumber === productArticleNumber)) {
            state.warehouseProducts.splice(state.warehouseProducts.findIndex(x => x.articleNumber === productArticleNumber), 1);
        }
    },
    UPDATE_PRODUCT_LIST_STATE(state, productArticleNumber) {

        if (state.warehouseProducts.find(x => x.articleNumber === productArticleNumber)) {
            state.warehouseProducts.splice(state.warehouseProducts.findIndex(x => x.articleNumber === productArticleNumber), 1);
        }
    }

    
}