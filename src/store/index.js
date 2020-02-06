import Vue from 'vue';
import Vuex from 'vuex';
import actions from "./actions"
import mutations from "./mutations"
import loginModule from "./modules/login/index"
import invoiceModule from "./modules/invoice/index"
import warehouseModule from "./modules/warehouse/index"
import customerModule from "./modules/customer/index"

Vue.use(Vuex)

const store = new Vuex.Store({
    strict: true,
    modules: {
        login: loginModule,
        invoice: invoiceModule,
        warehouse: warehouseModule,
        customer: customerModule
    },
    state: {
        title: 'Kundvagn',
        cart: [],
    },
    //  mutations: {
    //      SET_NEW_CART_ITEM(state, product) {
    //          state.cart.push({
    //              id: product.id,
    //              name: product.name,
    //              published: product.published
    //          })

    //          //state.extend({},  )
    //      },
    //      REMOVE_CART_ITEM(state, productId) {
    //          state.cart.pop(productId, 1)
    //      }
    //},
    //  actions: {
    //      ADD_TO_CART({ commit, product }) {
    //          commit('SET_NEW_CART_ITEM', product);
    //      },
    //      REMOVE_PRODUCT_FROM_BASKET({ commit, productId }) {
    //          commit('REMOVE_CART_ITEM', productId)
    //          //splice(index, 1) remove object from cart with id
    //      },
    //},
    //modules: {
    //}
    mutations,
    actions,
});
if (module.hot) {
    // accept actions and mutations as hot modules
    //module.hot.accept(['./modules/windows/index',
    //                    './modules/door/index',
    //                    './modules/doorleaves/index',
    //                    './modules/maindoor/index',
    //                    './modules/login/index',
    //                    './modules/deliveryAddress/index'],
    module.hot.accept([
        './modules/login/index',
        './modules/invoice/index',
        './modules/warehouse/index',
        './modules/customer/index',
    ]);
    () => {
        // require the updated modules
        // have to add .default here due to babel 6 module output
        //const newModuleWindows = require('./modules/windows/index').default
        //const newModuleDoor = require('./modules/door/index').default
        //const newModuleDoorLeaves = require('./modules/doorleaves/index').default
        //const newModuleMainDoor = require('./modules/maindoor/index').default
        //const newModuleLogin = require('./modules/login/index').default
        //const newModuleDeliveryAddress = require('./modules/deliveryAddress/index').default
        const newModuleLogin = require('./modules/login/index').default
        const newModuleinvoice = require('./modules/invoice/index').default
        const newModulewarehouse = require('./modules/warehouse/index').default
        const newModulecustomer = require('./modules/customer/index').default
        // swap in the new modules and mutations
        store.hotUpdate({
            modules: {
                //windows: newModuleWindows,
                //door: newModuleDoor,
                //doorLeaves: newModuleDoorLeaves,
                //mainDoor: newModuleMainDoor,
                login: newModuleLogin,
                invoice: newModuleinvoice,
                warehouse: newModulewarehouse,
                customer: newModulecustomer,
            }
        })
    }
}
export default store;