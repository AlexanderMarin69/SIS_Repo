import actions from "./actions";
import mutations from "./mutations";

export default {
    namespaced: true,
    state: {
        warehouseProducts: [
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