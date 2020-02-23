import actions from "./actions";
import mutations from "./mutations";

export default {
    namespaced: true,
    state: {
        allUserInvoices: [],
        InvoiceProducts: [],
        totalInvoiceItemsPrice: 0,
        currentInvoicePdfGuid: '',
    },
    actions,
    mutations
}