export default {
    SET_NEW_PRODUCT_TO_LIST(state, product) {
        state.InvoiceProducts.push({
            articleNumber: product.articleNumber,
            name: product.name,
            price: product.price,
            quantity: 1
        })
    },
    //REMOVE_PRODUCT_FROM_LIST(state, product) {

    //    for (var i = 0; i < state.InvoiceProducts.length; i++) {

    //        if (state.InvoiceProducts[i].articleNumber === product.id.articleNumber) {
    //            var kanin = {
    //                articleNumber: state.InvoiceProducts[i].articleNumber,
    //                name: state.InvoiceProducts[i].name,
    //                price: state.InvoiceProducts[i].price
    //            };

    //            state.InvoiceProducts.splice(state.InvoiceProducts.findIndex(x => x.articleNumber === product.id.articleNumber), 1);

    //            state.InvoiceProducts.push({
    //                articleNumber: kanin.articleNumber,
    //                name: 'ny variabel',
    //                price: product.number
    //            }
    //            )
    //            return false;
    //        }
    //    }
    //},
    UPDATE_PRODUCT_PRICE_FROM_LIST(state, product) {
        for (var i = 0; i < state.InvoiceProducts.length; i++) {

            if (state.InvoiceProducts[i].articleNumber === product.articleNumber) {
                var kanin = {
                    articleNumber: state.InvoiceProducts[i].articleNumber,
                    name: state.InvoiceProducts[i].name,
                    price: state.InvoiceProducts[i].price,
                    quantity: state.InvoiceProducts[i].quantity
                };

                state.InvoiceProducts.splice(state.InvoiceProducts.findIndex(x => x.articleNumber === product.articleNumber), 1);

                state.InvoiceProducts.unshift({
                    articleNumber: kanin.articleNumber,
                    name: kanin.name,
                    price: product.price,
                    quantity: kanin.quantity
                }
                )
                return false;
            }
        }
    },
    UPDATE_PRODUCT_QUANTITY_FROM_LIST(state, product) {

        for (var i = 0; i < state.InvoiceProducts.length; i++) {

            if (state.InvoiceProducts[i].articleNumber === product.articleNumber) {
                var kanin = {
                    articleNumber: state.InvoiceProducts[i].articleNumber,
                    name: state.InvoiceProducts[i].name,
                    price: state.InvoiceProducts[i].price,
                    quantity: state.InvoiceProducts[i].quantity
                };

                state.InvoiceProducts.splice(state.InvoiceProducts.findIndex(x => x.articleNumber === product.articleNumber), 1);

                state.InvoiceProducts.unshift({
                    articleNumber: kanin.articleNumber,
                    name: kanin.name,
                    price: kanin.price,
                    quantity: product.quantity
                }
                )
                return false;
            }
        }
    },
    REMOVE_PRODUCT_FROM_LIST(state, product) {

        for (var i = 0; i < state.InvoiceProducts.length; i++) {

            if (state.InvoiceProducts[i].articleNumber === product.articleNumber) {
                state.InvoiceProducts.splice(state.InvoiceProducts.findIndex(x => x.articleNumber === product.articleNumber), 1);
            }
        }
    },
}