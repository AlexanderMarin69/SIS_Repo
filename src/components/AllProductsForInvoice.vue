<template>
    <div>
        <v-card max-width="500"
                class="mx-auto">
            <v-toolbar color="primary"
                       dark>
                <v-toolbar-title>Hela lagret</v-toolbar-title>
                <v-spacer></v-spacer>
                <!--<v-btn icon class="ml-3 mr-3">
                <v-icon>mdi-magnify</v-icon>
                sök
            </v-btn>-->
               
            </v-toolbar>
            <v-card color="grey lighten-4" flat>
                <v-toolbar dense>
                    <!--<v-toolbar-title>Title</v-toolbar-title>-->
                    <v-text-field class="pa-2 mt-4" placeholder="Hitta..." v-model="searchInput" @keyup="searchOnKeyup"></v-text-field>
                    <v-btn icon>
                    </v-btn>
                </v-toolbar>
            </v-card>
            <v-list two-line>
                <v-list-item-group>
                    <template v-for="(item, index) in warehouseProductsToDisplay">
                        <v-list-item :key="item.name">
                            <template>
                                <v-list-item-content>
                                    <v-list-item-subtitle v-text="item.articleNumber" class="pa-1"></v-list-item-subtitle>
                                    <v-list-item-title v-text="item.name" class="pa-1" style="font-weight: bold;"></v-list-item-title>
                                    <v-list-item-subtitle class="text--primary pa-1" v-text="item.description"></v-list-item-subtitle>
                                </v-list-item-content>
                                <v-list-item-action>
                                    <v-btn color="primary" small @click="addToInvoiceProductList(item)">Lägg till +</v-btn>
                                </v-list-item-action>
                            </template>
                        </v-list-item>
                        <v-divider v-if="index + 1 < listOfProducts.length"
                                   :key="index"></v-divider>
                    </template>
                </v-list-item-group>
            </v-list>
        </v-card>
      
     

      
    </div>
</template>

<script>
    /* eslint-disable no-console */
    import { mapState, mapActions } from 'vuex';
    //import ProductAPI from '@/services/Product'
    export default {
        data: () => ({

            

            searchInput: '',

         

            

            placeholderArrayForProducts: [],
            listOfProducts: [],
        }),
        methods: {
             addToInvoiceProductList(item) {
                this.addToInvoiceProductListAction(item);
            },
            searchOnKeyup() {
                setTimeout(() => (

                    this.searchWarehouse(
                        {
                            SearchWords: this.searchInput
                        })
                        
                ), 1500)
            },
            ...mapActions({
                //getAllProducts: 'warehouse/GET_ALL_PRODUCTS',
                searchWarehouse: 'warehouse/SEARCH_WAREHOUSE',
                addToInvoiceProductListAction: 'invoice/ADD_PRODUCT_TO_LIST',
            }),
        },
        computed: {
            ...mapState({
                warehouseProductsToDisplay: state => state.warehouse.warehouseProducts
            }),
        },
        beforeMount() {
            //this.getAllProducts();
        }
    }


    /* eslint-enable no-console */
</script>

<style scoped>
    .articleNumberErrorMessage {
        font-size: 14px;
        color: #e46b6b;
        padding: 10px;
    }
</style>
