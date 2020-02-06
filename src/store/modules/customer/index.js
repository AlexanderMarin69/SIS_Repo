import actions from "./actions";
import mutations from "./mutations";

export default {
    namespaced: true,
    state: {
        allUserCustomers: [
            //{
            //ANR,
            //Price,
            //Name
            //}
        ],
        //productToCreate: {},
    },
    actions,
    mutations
}