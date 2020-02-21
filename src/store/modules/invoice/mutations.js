export default {
    SET_NEW_PRODUCT_TO_LIST(state, product) {

        if (
            state.InvoiceProducts.find(x => x.articleNumber === product.articleNumber)
        ) {
            /*eslint no-console: */
            // custom console
            //console.log('hellooo');
            return false;
        } else {
            /*eslint no-console: */
            // custom console
            console.log('else satsen');

            state.InvoiceProducts.push({
                articleNumber: product.articleNumber,
                name: product.name,
                price: product.price,
                quantity: 1
            })
            state.totalInvoiceItemsPrice = 0;
            for (var j = 0; j < state.InvoiceProducts.length; j++) {
                state.totalInvoiceItemsPrice += state.InvoiceProducts[j].price * state.InvoiceProducts[j].quantity
            }
        }
    },
    RESET_INVOICE_PRODUCT_LIST(state) {
        for (var i = 0; i < state.InvoiceProducts.length; i++) {
            state.InvoiceProducts.splice(0, state.InvoiceProducts.length);
        }
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
                    price: kanin.price = parseInt(product.price),
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
                    quantity: kanin.price = parseInt(product.quantity)
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
        state.totalInvoiceItemsPrice = 0;
        for (var j = 0; j < state.InvoiceProducts.length; j++) {
            state.totalInvoiceItemsPrice += state.InvoiceProducts[j].price * state.InvoiceProducts[j].quantity
        }
    },
    CALCULATE_TOTAL_INVOICE_ITEMS_PRICE(state) {
        state.totalInvoiceItemsPrice = 0;
        for (var i = 0; i < state.InvoiceProducts.length; i++) {
            state.totalInvoiceItemsPrice += state.InvoiceProducts[i].price * state.InvoiceProducts[i].quantity
        }
    },
    //UPDATE_INVOICE_FEE(state, invoiceFee) {
    //    state.totalInvoiceItemsPrice = 0;
    //    for (var i = 0; i < state.InvoiceProducts.length; i++) {
    //        state.totalInvoiceItemsPrice += state.InvoiceProducts[i].price * state.InvoiceProducts[i].quantity
    //    }
      
    //    if (invoiceFee == isNaN) {
    //        state.invoiceFee = 0
    //    } 
    //        state.deliveryFee = parseInt(invoiceFee)
    //        state.totalInvoiceItemsPrice += state.deliveryFee
    //        state.totalInvoiceItemsPrice += state.invoiceFee
        

    //},
    //UPDATE_DELIVERY_FEE(state, deliveryFee) {
    //    state.totalInvoiceItemsPrice = 0;
    //    for (var i = 0; i < state.InvoiceProducts.length; i++) {
    //        state.totalInvoiceItemsPrice += state.InvoiceProducts[i].price * state.InvoiceProducts[i].quantity
    //    }
    //    if (deliveryFee == isNaN) {
    //        state.deliveryFee = 0
    //    } 
    //        state.deliveryFee = parseInt(deliveryFee)
    //        state.totalInvoiceItemsPrice += state.deliveryFee
    //        state.totalInvoiceItemsPrice += state.invoiceFee
    //},

    SET_ALL_USER_INVOICES(state, result) {
        state.allUserInvoices = result;
       
    },
}