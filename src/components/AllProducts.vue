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
                <v-btn color="black" @click="addNewProductDialog = !addNewProductDialog" class="ml-3">
                    Skapa ny
                </v-btn>
            </v-toolbar>
            <v-card color="grey lighten-4" flat>
                <v-toolbar dense>
                    <!--<v-toolbar-title>Title</v-toolbar-title>-->
                    <v-text-field class="pa-2 mt-4" placeholder="Hitta..." v-model="searchInput" @keyup="searchOnKeyup"></v-text-field>
                </v-toolbar>
            </v-card>
            <v-list two-line>
                <v-list-item-group>
                    <template v-for="(item, index) in warehouseProductsToDisplay">
                        <v-list-item :key="item.name" @click="showProductDetails(item)">
                            <template>
                                <v-list-item-content>
                                    <v-list-item-subtitle v-text="item.articleNumber" class="pa-1"></v-list-item-subtitle>
                                    <v-list-item-title v-text="item.name" class="pa-1" style="font-weight: bold;"></v-list-item-title>
                                    <v-list-item-subtitle class="text--primary pa-1" v-text="item.description"></v-list-item-subtitle>
                                </v-list-item-content>
                                <v-list-item-action>
                                    <v-list-item-action-text v-text="item.price + ' kr'"></v-list-item-action-text>
                                </v-list-item-action>
                            </template>
                        </v-list-item>
                        <v-divider v-if="index + 1 < listOfProducts.length"
                                   :key="index"></v-divider>
                    </template>
                </v-list-item-group>
            </v-list>
        </v-card>
        <!--ADD NEW PRODUCT DIALOG ------- START -->
        <v-row justify="center">
            <v-dialog v-model="addNewProductDialog" persistent max-width="600px">
                <v-card>
                    <v-card-title>
                        <span class="headline">Skapa ny artikel</span>
                        <v-card flat v-if="showArticleNumberErrorMessage">
                            <p class="articleNumberErrorMessage">
                                Det finns redan en produkt med ditt valda artikelnumret, välj ett annat.
                            </p>
                        </v-card>
                    </v-card-title>
                    <v-card-text>
                        <v-container>
                            <v-row>
                                <v-col cols="12" sm="6" md="4">
                                    <v-text-field v-model="name" label="Benämning"></v-text-field>
                                </v-col>
                                <v-col cols="12" sm="6" md="4">
                                    <v-text-field v-model="articleNumber" label="Artikelnummer"></v-text-field>
                                </v-col>
                                <v-col cols="12" sm="6" md="4">
                                    <v-text-field v-model="price" label="Försäljningspris"></v-text-field>
                                </v-col>
                                <v-col cols="12" sm="6" md="4">
                                    <v-text-field v-model="ean" label="EAN"></v-text-field>
                                </v-col>
                                <v-col cols="12" sm="6" md="4">
                                    <v-text-field v-model="manufacturer" label="Tillverkare"></v-text-field>
                                </v-col>
                                <v-col cols="12" sm="6" md="4">
                                    <v-text-field v-model="manufacturerSku" label="Tillverkarens artikelnummer"></v-text-field>
                                </v-col>
                                <v-col cols="12" sm="6" md="4">
                                    <v-text-field v-model="supplier" label="Leverantör"></v-text-field>
                                </v-col>
                                <v-col cols="12">
                                    <v-text-field v-model="description" label="Beskrivning"></v-text-field>
                                </v-col>
                                <v-col cols="12" sm="6" md="4">
                                    <v-text-field v-model="costPerItem" label="Kalkylkostnad"></v-text-field>
                                </v-col>
                                <v-col cols="12" sm="6" md="4">
                                    <v-text-field v-model="stockBalance" label="I lager"></v-text-field>
                                </v-col>
                                <v-col cols="12" sm="6" md="4">
                                    <v-text-field v-model="productType" label="Enhet"></v-text-field>
                                    <small> Exempel: "timmar", "kilometer", "styck", "förpackning"</small>
                                </v-col>
                            </v-row>
                        </v-container>
                    </v-card-text>
                    <v-card-actions>
                        <v-spacer></v-spacer>
                        <v-btn color="blue darken-1" text @click="closeDialog">Stäng</v-btn>
                        <v-btn color="blue darken-1" text @click="createNewProduct()">Skapa</v-btn>
                    </v-card-actions>
                </v-card>
            </v-dialog>
        </v-row>
        <!--ADD NEW PRODUCT DIALOG  --------   END-->
        <!--   PRODUCT SUCCESSFULLY ADDED DIALOG --------- START     -->
        <div class="text-center">
            <v-dialog v-model="productSuccessfullyAddedDialog"
                      hide-overlay
                      persistent
                      width="300">
                <v-card color="primary"
                        dark>
                    <v-card-text class="text-center pa-5">
                        Produkten lades till!
                    </v-card-text>
                </v-card>
            </v-dialog>
        </div>
        <!--   PRODUCT SUCCESSFULLY ADDED DIALOG --------- END     -->
        <!--  SELECTED PRODUCT DIALOG ------- START -->
        <v-row justify="center">
            <v-dialog v-model="selectedProductDialog" persistent max-width="600px">
                <v-card>
                    <v-card-title>
                        <span class="headline">Ändra din produkt</span>
                    </v-card-title>
                    <v-card-text>
                        <v-container>
                            <v-row>
                                <v-col cols="12" sm="6" md="4">
                                    <v-text-field v-model="editName" label="Benämning"></v-text-field>
                                </v-col>
                                <v-col cols="12" sm="6" md="4">
                                    <v-text-field readonly filled v-model="editArticleNumer" label="Artikelnummer"></v-text-field>
                                </v-col>
                                <v-col cols="12" sm="6" md="4">
                                    <v-text-field v-model="editPrice" label="Försäljningspris"></v-text-field>
                                </v-col>
                                <v-col cols="12" sm="6" md="4">
                                    <v-text-field v-model="editEan" label="EAN"></v-text-field>
                                </v-col>
                                <v-col cols="12" sm="6" md="4">
                                    <v-text-field v-model="editManufacturer" label="Tillverkare"></v-text-field>
                                </v-col>
                                <v-col cols="12" sm="6" md="4">
                                    <v-text-field v-model="editManufacturerSku" label="Tillverkarens artikelnummer"></v-text-field>
                                </v-col>
                                <v-col cols="12" sm="6" md="4">
                                    <v-text-field v-model="editSupplier" label="Leverantör"></v-text-field>
                                </v-col>
                                <v-col cols="12">
                                    <v-text-field v-model="editDescription" label="Beskrivning"></v-text-field>
                                </v-col>
                                <v-col cols="12" sm="6" md="4">
                                    <v-text-field v-model="editCostPerItem" label="Kalkylkostnad"></v-text-field>
                                </v-col>
                                <v-col cols="12" sm="6" md="4">
                                    <v-text-field v-model="editStockBalance" label="I lager"></v-text-field>
                                </v-col>
                                <v-col cols="12" sm="6" md="4">
                                    <v-text-field v-model="editProductType" label="Enhet"></v-text-field>
                                    <small> Exempel: "timmar", "kilometer", "styck", "förpackning"</small>
                                </v-col>
                            </v-row>
                        </v-container>

                    </v-card-text>
                    <v-card-actions>
                        <v-btn color="danger darken-1" text @click="deleteProductDialog = true">Ta bort</v-btn>
                        <v-spacer></v-spacer>
                        <v-btn color="blue darken-1" text @click="selectedProductDialog = false">Stäng</v-btn>
                        <v-btn color="blue darken-1" text @click="updateExistingProduct()">Spara ändringar</v-btn>
                    </v-card-actions>
                </v-card>
            </v-dialog>
        </v-row>
        <!-- SELECTED PRODUCT DIALOG  --------   END-->
        <!-- DELETE PRODUCT DIALOG  --------   START-->

        <v-row justify="center">
            <v-dialog v-model="deleteProductDialog" max-width="300px">
                <v-card>
                    <v-card-title>
                        <span class="headline">Är du säker?</span>
                    </v-card-title>
                    <v-card-text>
                        <v-container>
                            <p>Om du tar bort produkten går detta inte att ångra.</p>
                        </v-container>
                    </v-card-text>
                    <v-card-actions>
                        <v-btn color="danger darken-1" text @click="deleteProduct()">Ta bort</v-btn>
                        <v-spacer></v-spacer>
                        <v-btn color="blue darken-1" text @click="deleteProductDialog = false">Avbryt</v-btn>
                    </v-card-actions>
                </v-card>
            </v-dialog>
        </v-row>
        <!-- DELETE PRODUCT DIALOG  --------   END-->
    </div>
</template>

<script>
    /* eslint-disable no-console */
    import { mapState, mapActions } from 'vuex';
    import ProductAPI from '@/services/Product'
    export default {
        data: () => ({

            //create product v-models start------------
            name: '',
            articleNumber: '',
            price: '',
            ean: '',
            manufacturer: '',
            manufacturerSku: '',
            supplier: '',
            description: '',
            costPerItem: '',
            stockBalance: '',
            productType: '',

            showArticleNumberErrorMessage: false,
            //create product v-models end---------------

            //--------------------------

            //edit product v-models start-----------------
            editName: '',
            editArticleNumer: '',
            editPrice: '',
            editEan: '',
            editManufacturer: '',
            editManufacturerSku: '',
            editSupplier: '',
            editDescription: '',
            editCostPerItem: '',
            editStockBalance: '',
            editProductType: '',
            //edit product v-models end --------------------


            //delete product v-models start-----------------

            deleteProductDialog: false,


            //delete product v-models start-----------------


            selectedProductDialog: false,
            selectedProductForEdit: {},

            searchInput: '',

            addNewProductDialog: false,
            productSuccessfullyAddedDialog: false,

            

            placeholderArrayForProducts: [],
            listOfProducts: [],
        }),
        methods: {
              // DELETE PRODUCT START -------
            deleteProduct() {
                this.deleteProductDialog = false,
            ProductAPI.DeleteProduct({
            Name: this.editName,
            ArticleNumber: this.editArticleNumer,
            Price: this.editPrice,
            EAN: this.editEan,
            Manufacturer: this.editManufacturer,
            ManufacturerSku: this.editManufacturerSku,
            Supplier: this.editSupplier,
            Description: this.editDescription,
            CostPerItem: this.editCostPerItem,
            StockBalance: this.editStockBalance,
            ProductType: this.editProductType
                });
            },   // DELETE PRODUCT START -------


            // UPDATE PRODUCT START -------
            updateExistingProduct() {
            ProductAPI.UpdateExistingProduct({
            Name: this.editName,
            ArticleNumber: this.editArticleNumer,
            Price: this.editPrice,
            EAN: this.editEan,
            Manufacturer: this.editManufacturer,
            ManufacturerSku: this.editManufacturerSku,
            Supplier: this.editSupplier,
            Description: this.editDescription,
            CostPerItem: this.editCostPerItem,
            StockBalance: this.editStockBalance,
            ProductType: this.editProductType
                });
            }, // UPDATE PRODUCT END -------

            showProductDetails(item) {
                ProductAPI.GetProductById({ id: item.id }).then((response) => {
            this.editName = response.name,
            this.editArticleNumer = response.articleNumber,
            this.editPrice = response.price,
            this.editEan = response.ean,
            this.editManufacturer = response.manufacturer,
            this.editManufacturerSku = response.manufacturerSku,
            this.editSupplier = response.supplier,
            this.editDescription = response.description,
            this.editCostPerItem = response.costPerItem,
            this.editStockBalance = response.stockBalance,
            this.editProductType = response.productType
                    });
                this.selectedProductDialog = true
            },
            searchOnKeyup() {
                setTimeout(() => (

                    this.searchWarehouse(
                        {
                            SearchWords: this.searchInput
                        })
                        
                ), 1500)
            },
            productAddedDialog() {
                this.productSuccessfullyAddedDialog = true;
                setTimeout(() => (this.productSuccessfullyAddedDialog = false), 2000)
            },
            createNewProduct() {
                this.showArticleNumberErrorMessage = false,
                ProductAPI.CreateNewProduct(
                    {
                        Name: this.name,
                        ArticleNumber: this.articleNumber,
                        Price: this.price,
                        EAN: this.ean,
                        Manufacturer: this.manufacturer,
                        ManufacturerSku: this.manufacturerSku,
                        Supplier: this.supplier,
                        Description: this.description,
                        CostPerItem: this.costPerItem,
                        StockBalance: this.stockBalance,
                        ProductType: this.productType

                    },
                ).then(result => {
                    if (result == 'Det finns redan en produkt med detta artikelnumret, välj ett annat artikelnumer.') {
                        this.showArticleNumberErrorMessage = true
                    } else {
                         this.name = '',
            this.articleNumber = '',
            this.price = '',
            this.ean = '',
            this.manufacturer = '',
            this.manufacturerSku = '',
            this.supplier = '',
            this.description = '',
            this.costPerItem = '',
            this.stockBalance = '',
            this.productType = ''
                    }
                }),
            




                //this.name,
                //this.sku,
                //this.price,
                //this.ean,
                //this.producer,
                //this.manufacturer,
                //this.supplier,
                //this.description,
                //this.costPerItem,
                //this.inStock,
                //this.productType


                //TODO: works well with ProductAPI directly, loses all data when sending through actions
                //this.createNewProducto(
                //    {
                //         name: 'hello',
                //    sku: 'hello',
                //    //name: this.name,
                //    //sku: this.sku,

                //     }
                //);


                //this.createNewProduct({

                //   Name: this.name,
                //    SKU: this.sku,
                //    Price: this.price,
                //    EAN: this.ean,
                //    Producer: this.producer,
                //    Manufacturer: this.manufacturer,
                //    Supplier: this.supplier,
                //    Description: this.description,
                //   CostPerItem: this.costPerItem,
                //    InStock: this.inStock,
                //    ProductType: this.productType
                //});
                this.productAddedDialog();

                //this.name = '';
                //this.sku = '';
                //this.price = '';
                //this.ean = '';
                //this.producer = '';
                //this.manufacturer = '';
                //this.supplier = '';
                //this.description = '';
                //this.costPerItem = '';
                //this.inStock = '';
                //this.productType = '';
            },
            ...mapActions({
                getAllProducts: 'warehouse/GET_ALL_PRODUCTS',
                searchWarehouse: 'warehouse/SEARCH_WAREHOUSE',
            }),
            closeDialog() {
                this.addNewProductDialog = false;
            }
        },
        computed: {
            ...mapState({
                warehouseProductsToDisplay: state => state.warehouse.warehouseProducts
            }),
        },
        beforeMount() {
            this.getAllProducts();
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
