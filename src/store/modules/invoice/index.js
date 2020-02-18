import actions from "./actions";
import mutations from "./mutations";

export default {
    namespaced: true,
    state: {
        InvoiceProducts: [],
    },
    totalInvoiceItemsPrice: 0,
    actions,
    mutations
}