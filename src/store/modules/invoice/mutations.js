export default {
    SET_NEW_PRODUCT_TO_LIST( state , product) {
        // custom console
                // eslint-disable-next-line no-console
        console.log(product, 'mutation');
        state.InvoiceProducts.push({
            articleNumber: product.articleNumber,
            name: product.name,
            price: product.price
        })
    },
    REMOVE_PRODUCT_FROM_LIST(state, product) {
        //state.InvoiceProducts.pop(productId, 1)
            /*eslint no-debugger: */
        //debugger;
        //state.InvoiceProducts.find(product => product.articleNumber === productId).name = 'neger'
        //var hello = state.InvoiceProducts.findIndex(f => f.articleNumber === productId);

        for (var i = 0; i < state.InvoiceProducts.length; i++) {
            //for (var j = 0; j < state.InvoiceProducts[i].length; j++) {
            
           
            if (state.InvoiceProducts[i].articleNumber === product.id.articleNumber) {
                

                var kanin = {
                    articleNumber: state.InvoiceProducts[i].articleNumber,
                    name: state.InvoiceProducts[i].name,
                    price: state.InvoiceProducts[i].price
                };
                // custom console
                // eslint-disable-next-line no-console
                console.log(product.id.articleNumber, 'product.id.articleNumber');

                state.InvoiceProducts.splice(state.InvoiceProducts.findIndex(x => x.articleNumber === product.id.articleNumber), 1); 

                state.InvoiceProducts.push({
                    articleNumber: kanin.articleNumber,
                    name: 'motherfucker',
                    price: product.number
                }
                )
                return false;
            }
        }  
        
        
    },
}