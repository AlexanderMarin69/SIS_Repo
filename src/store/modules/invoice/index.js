import actions from "./actions";
import mutations from "./mutations";

export default {
    namespaced: true,
    state: {
        InvoiceProducts: [
            //{
            //ANR,
            //Price,
            //Name
            //}
        ],
        InvoiceId: ''
    },
    actions,
    mutations
}