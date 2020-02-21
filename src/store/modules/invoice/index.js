import actions from "./actions";
import mutations from "./mutations";

export default {
    namespaced: true,
    state: {
        allUserInvoices: [],
        InvoiceProducts: [],
        totalInvoiceItemsPrice: 0,
        //invoiceFee: 0,
        //deliveryFee: 0,
    },
    actions,
    mutations
}