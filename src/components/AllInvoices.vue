<template>
    <div>
        <v-card max-width="500"
                class="mx-auto">
            <v-toolbar color="primary"
                       dark>
                <v-toolbar-title>Alla Fakturor</v-toolbar-title>
                <v-spacer></v-spacer>
                <!--<v-btn icon class="ml-3 mr-3">
                    <v-icon>mdi-magnify</v-icon>
                    sök
                </v-btn>-->
                <v-btn color="black" @click="createNewInvoiceDialog = !createNewInvoiceDialog" class="ml-3">
                    Skapa ny
                </v-btn>
            </v-toolbar>
            <v-card color="grey lighten-4" flat>
                <v-toolbar dense>
                    <!--<v-toolbar-title>Title</v-toolbar-title>-->
                    <v-text-field class="pa-2 mt-4" placeholder="Hitta..." v-model="searchInput" @keyup="searchOnKeyup"></v-text-field>
                    <v-btn icon>
                        <v-icon>mdi-dots-vertical</v-icon>
                    </v-btn>
                </v-toolbar>
            </v-card>
            <v-list two-line>
                <v-list-item-group>
                    <template v-for="(item, index) in allUserCustomersToDisplay">
                        <v-list-item :key="item.name" @click="showCustomerDetails(item)">
                            <template>
                                <v-list-item-content>
                                    <v-list-item-subtitle v-text="item.phoneNumber" class="pa-1"></v-list-item-subtitle>
                                    <v-list-item-title v-text="item.name" class="pa-1" style="font-weight: bold;"></v-list-item-title>
                                    <v-list-item-subtitle class="text--primary pa-1" v-text="item.emailAddress"></v-list-item-subtitle>
                                    <v-list-item-subtitle class="text--primary pa-1" v-text="item.city"></v-list-item-subtitle>
                                </v-list-item-content>
                                <v-list-item-action>
                                    <!--<v-list-item-action-text v-text="item.price + ' kr'"></v-list-item-action-text>-->
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
            <v-dialog v-model="addNewCustomerDialog" persistent max-width="600px">
                <v-card>
                    <v-card-title>
                        <span class="headline">Skapa ny kund</span>
                        <v-card flat v-if="showCustomerIdErrorMessage">
                            <p class="customerIdErrorMessage">
                                Det finns redan en produkt med detta kundnummret, välj ett annat.
                            </p>
                        </v-card>
                    </v-card-title>
                    <v-card-text>
                        <v-container>
                            <v-row>
                                <v-col cols="12" sm="6" md="4">
                                    <v-text-field v-model="name" label="Namn"></v-text-field>
                                </v-col>
                                <v-col cols="12" sm="6" md="4">
                                    <v-text-field v-model="customerId" label="Kundnummer"></v-text-field>
                                </v-col>
                                <v-col cols="12" sm="6" md="4">
                                    <v-text-field v-model="invoiceAddress" label="Fakturaadress"></v-text-field>
                                </v-col>
                                <v-col cols="12" sm="6" md="4">
                                    <v-text-field v-model="secondInvoiceAddress" label="Fakturaadress 2"></v-text-field>
                                </v-col>
                                <v-col cols="12" sm="6" md="4">
                                    <v-text-field v-model="zipCode" label="Postnr"></v-text-field>
                                </v-col>
                                <v-col cols="12" sm="6" md="4">
                                    <v-text-field v-model="city" label="Ort"></v-text-field>
                                </v-col>
                                <v-col cols="12" sm="6" md="4">
                                    <v-text-field v-model="country" label="Land"></v-text-field>
                                </v-col>
                                <v-col cols="12">
                                    <v-text-field v-model="organisationNumber" label="Organisationsnummer"></v-text-field>
                                </v-col>
                                <v-col cols="12" sm="6" md="4">
                                    <v-text-field v-model="phoneNumber" label="Telefonnummer"></v-text-field>
                                </v-col>
                                <v-col cols="12" sm="6" md="4">
                                    <v-text-field v-model="secondPhoneNumber" label="Andra telefonnummer"></v-text-field>
                                </v-col>
                                <v-col cols="12" sm="6" md="4">
                                    <v-text-field v-model="fax" label="Fax"></v-text-field>
                                </v-col>
                                <v-col cols="12" sm="6" md="4">
                                    <v-text-field v-model="emailAddress" label="E-post"></v-text-field>
                                </v-col>
                                <v-col cols="12" sm="6" md="4">
                                    <v-text-field v-model="webAddress" label="Webbadress"></v-text-field>
                                </v-col>
                                <v-col cols="12" sm="12" md="12">
                                    <v-text-field v-model="description" label="Beskrivning / egna anteckningar"></v-text-field>
                                </v-col>
                            </v-row>
                        </v-container>
                    </v-card-text>
                    <v-card-actions>
                        <v-spacer></v-spacer>
                        <v-btn color="blue darken-1" text @click="closeDialog">Stäng</v-btn>
                        <v-btn color="blue darken-1" text @click="createNewCustomer()">Skapa</v-btn>
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
                        Kunden lades till!
                    </v-card-text>
                </v-card>
            </v-dialog>
        </div>
        <!--   PRODUCT SUCCESSFULLY ADDED DIALOG --------- END     -->
        <!--  SELECTED PRODUCT DIALOG ------- START -->
        <v-row justify="center">
            <v-dialog v-model="selectedCustomerDialog" persistent max-width="600px">
                <v-card>
                    <v-card-title>
                        <span class="headline">Ändra kundinformation</span>
                    </v-card-title>
                    <v-card-text>
                        <v-container>
                            <v-row>

                            </v-row>
                        </v-container>

                    </v-card-text>
                    <v-card-actions>
                        <v-btn color="danger darken-1" text @click="deleteCustomerDialog = true">Ta bort</v-btn>
                        <v-spacer></v-spacer>
                        <v-btn color="blue darken-1" text @click="selectedCustomerDialog = false">Stäng</v-btn>
                        <v-btn color="blue darken-1" text @click="updateExistingCustomer()">Spara ändringar</v-btn>
                    </v-card-actions>
                </v-card>
            </v-dialog>
        </v-row>
        <!-- SELECTED PRODUCT DIALOG  --------   END-->
        <!-- DELETE PRODUCT DIALOG  --------   START-->

        <v-row justify="center">
            <v-dialog v-model="deleteCustomerDialog" max-width="300px">
                <v-card>
                    <v-card-title>
                        <span class="headline">Är du säker?</span>
                    </v-card-title>
                    <v-card-text>
                        <v-container>
                            <p>Om du tar bort kunden går detta inte att ångra.</p>
                        </v-container>
                    </v-card-text>
                    <v-card-actions>
                        <v-btn color="danger darken-1" text @click="deleteCustomer()">Ta bort</v-btn>
                        <v-spacer></v-spacer>
                        <v-btn color="blue darken-1" text @click="deleteCustomerDialog = false">Avbryt</v-btn>
                    </v-card-actions>
                </v-card>
            </v-dialog>
        </v-row>
        <!-- DELETE PRODUCT DIALOG  --------   END-->



        <v-row justify="center">
            <v-dialog v-model="createNewInvoiceDialog" fullscreen hide-overlay transition="dialog-bottom-transition">
               
                <v-card>
                    <v-toolbar dark color="primary">
                        <v-btn icon dark @click="createNewInvoiceDialog = false">
                            <v-icon>mdi-close</v-icon>
                        </v-btn>
                        <v-toolbar-title>Ny faktura</v-toolbar-title>


                        <v-spacer></v-spacer>


                        <v-toolbar-items>
                            <v-btn dark text @click="createNewInvoiceDialog = false">Spara</v-btn>
                        </v-toolbar-items>
                    </v-toolbar>
                    <v-list three-line subheader>
                        <v-subheader style="font-size: 20px;" class="mt-1">Fakturauppgifter</v-subheader>
                        <v-list-item>
                            <v-list-item-content>

                                <v-col cols="12" sm="6" md="4">
                                    <v-text-field v-model="editName" label="HÄMTA LISTA PÅ KUNDER OCH FYLL INVOICE V-MODELS"></v-text-field>
                                </v-col>
                                <v-col cols="12" sm="6" md="4">
                                    <v-menu ref="invoiceDateMenu"
                                            v-model="invoiceDateMenu"
                                            :close-on-content-click="false"
                                            :return-value.sync="invoiceDate"
                                            transition="scale-transition"
                                            offset-y
                                            min-width="290px">
                                        <template v-slot:activator="{ on }">
                                            <v-text-field v-model="invoiceDate"
                                                          label="Picker in invoiceDateMenu: "
                                                          readonly
                                                          v-on="on"></v-text-field>
                                        </template>
                                        <v-date-picker v-model="invoiceDate" no-title scrollable>
                                            <v-spacer></v-spacer>
                                            <v-btn text color="primary" @click="invoiceDateMenu = false">Cancel</v-btn>
                                            <v-btn text color="primary" @click="$refs.invoiceDateMenu.save(invoiceDate)">OK</v-btn>
                                        </v-date-picker>
                                    </v-menu>
                                </v-col>
                                <v-col cols="12" sm="6" md="4">
                                    <v-menu ref="invoicePayDateMenu"
                                            v-model="invoicePayDateMenu"
                                            :close-on-content-click="false"
                                            :return-value.sync="invoicePayDate"
                                            transition="scale-transition"
                                            offset-y
                                            min-width="290px">
                                        <template v-slot:activator="{ on }">
                                            <v-text-field v-model="invoicePayDate"
                                                          label="Picker in invoicePayDateMenu: "
                                                          readonly
                                                          v-on="on"></v-text-field>
                                        </template>
                                        <v-date-picker v-model="invoicePayDate" no-title scrollable>
                                            <v-spacer></v-spacer>
                                            <v-btn text color="primary" @click="invoiceDatePayMenu = false">Cancel</v-btn>
                                            <v-btn text color="primary" @click="$refs.invoicePayDateMenu.save(invoicePayDate)">OK</v-btn>
                                        </v-date-picker>
                                    </v-menu>
                                </v-col>


                                <v-text-field class="pa-2 mt-4" label="Lägg till produkter" placeholder="Sök produkter" v-model="searchInput" @keyup="searchOnKeyup"></v-text-field>
                                <!--<v-list-item-group>-->
                                <template v-for="(item, index) in productsToChoose">
                                    <v-col cols="3" sm="6" md="4" :key="item.name" @click="showCustomerDetails(item)">
                                        <!--<v-list-item-content>-->
                                        <!--<v-list-item-subtitle v-text="item.phoneNumber"></v-list-item-subtitle>
                        <v-list-item-title v-text="item.name" style="font-weight: bold;"></v-list-item-title>
                        <v-list-item-subtitle class="text--primary" v-text="item.emailAddress"></v-list-item-subtitle>
                        <v-list-item-subtitle class="text--primary" v-text="item.city"></v-list-item-subtitle>-->
                                        <v-card>
                                            <p>item.phoneNumber</p>
                                            <p style="font-weight: bold;">item.name</p>
                                            <p>item.emailAddress</p>
                                            <p>item.city</p>
                                        </v-card>

                                    </v-col>
                                    <v-divider v-if="index + 1 < listOfProducts.length"
                                               :key="index"></v-divider>
                                </template>
                                <!--</v-list-item-group>-->


                                <v-list two-line>
                                    <v-list-item-group>
                                        <template v-for="(item, index) in productsToChoose">
                                            <v-list-item :key="item.name">
                                                <template>
                                                    <v-list-item-content>
                                                        <v-list-item-subtitle v-text="item.phoneNumber" class="pa-1"></v-list-item-subtitle>
                                                        <v-list-item-title v-text="item.name" class="pa-1" style="font-weight: bold;"></v-list-item-title>
                                                        <v-list-item-subtitle class="text--primary pa-1" v-text="item.emailAddress"></v-list-item-subtitle>
                                                        <v-list-item-subtitle class="text--primary pa-1" v-text="item.city"></v-list-item-subtitle>
                                                    </v-list-item-content>
                                                    <v-list-item-action>
                                                        <v-col cols="12" sm="6" md="4">
                                                            <v-text-field v-model="editZipCode" label="Pris"></v-text-field>
                                                        </v-col>
                                                        <v-col cols="12" sm="6" md="4">
                                                            <v-text-field v-model="editZipCode" label="Antal"></v-text-field>
                                                        </v-col>
                                                    </v-list-item-action>
                                                </template>
                                            </v-list-item>
                                            <v-divider v-if="index + 1 < listOfProducts.length"
                                                       :key="index"></v-divider>
                                        </template>
                                    </v-list-item-group>
                                </v-list>

                                <v-col cols="12" sm="6" md="4">
                                    <v-text-field v-model="editCity" label="Fraktavgift"></v-text-field>
                                </v-col>
                                <v-col cols="12" sm="6" md="4">
                                    <v-text-field v-model="editCountry" label="Fakturaavgift"></v-text-field>
                                </v-col>
                                <v-col cols="12" sm="6" md="4">
                                    <v-spacer></v-spacer>
                                    <v-card class="pa-5">
                                        <h3>Summa: 2 472 sek</h3>
                                    </v-card>
                                </v-col>
                                <v-col cols="12" sm="12" md="12">
                                    <v-text-field v-model="editDescription" label="Fakturatext"></v-text-field>
                                </v-col>
                            </v-list-item-content>
                        </v-list-item>
                    </v-list>
                  
                        <v-spacer></v-spacer>
                        <v-card-actions>
                            <v-btn icon
                                   @click="show = !show">
                                Skicka som <v-icon>{{ show ? 'mdi-chevron-up' : 'mdi-chevron-down' }}</v-icon>
                            </v-btn>

                            <v-expand-transition>
                                <div v-show="show">

                                    <v-list-item>
                                        <v-list-item-action>
                                            <v-radio v-model="notifications"></v-radio>
                                        </v-list-item-action>
                                        <v-list-item-content>
                                            <v-list-item-title>Faktura</v-list-item-title>
                                        </v-list-item-content>
                                    </v-list-item>
                                    <v-list-item>
                                        <v-list-item-action>
                                            <v-radio v-model="sound"></v-radio>
                                        </v-list-item-action>
                                        <v-list-item-content>
                                            <v-list-item-title>Påminnelse</v-list-item-title>
                                        </v-list-item-content>
                                    </v-list-item>
                                    <v-list-item>
                                        <v-list-item-action>
                                            <v-radio v-model="widgets"></v-radio>
                                        </v-list-item-action>
                                        <v-list-item-content>
                                            <v-list-item-title>Offert</v-list-item-title>
                                        </v-list-item-content>
                                    </v-list-item>
                                </div>
                            </v-expand-transition>
                        </v-card-actions>
                   
                  
                        <v-card-actions>
                            <v-btn disabled color="primary" class="mt-3 mr-5">
                                Skicka
                            </v-btn>
                            <v-spacer></v-spacer>
                            <v-btn color="primary" class="ma-3" onclick="saveInvoice()">
                                Spara
                            </v-btn>
                        </v-card-actions>
                        <p class="pa-5" style="font-size:14px; font-weight: 300;">
                           Välj först ovanför vad du vill skicka som.
                        </p>
                  
                </v-card>
            </v-dialog>
        </v-row>
    </div>






</template>

<script>
    /* eslint-disable no-console */
    import { mapState, mapActions } from 'vuex';
    import CustomerAPI from '@/services/Customer'
    export default {
        data: () => ({
            dialog: false,
            notifications: false,
            sound: true,
            widgets: false,
    createNewInvoiceDialog: false,
    show: false,








            invoiceDate: new Date().toISOString().substr(0, 10),
            invoiceDateMenu: false,
            invoiceDateModal: false,

            invoicePayDate: new Date().toISOString().substr(0, 10),
            invoicePayDateMenu: false,
            invoicePayDateModal: false,

            productsToChoose: [

                {
                    phoneNumber: '0761952005',
                    city: 'Värnamo',
                    emailAddress: 'alexander@hotmail.com',
                    name: 'Produktnamnet'
                }
            ],

            //create customer v-models start------------
            name: '',
            customerId: '',
            invoiceAddress: '',
            secondInvoiceAddress: '',
            zipCode: '',
            city: '',
            country: '',
            organisationNumber: '',
            phoneNumber: '',
            secondPhoneNumber: '',
            fax: '',
            emailAddress: '',
            webAddress: '',
            description: '',

            showCustomerIdErrorMessage: false,
            //create customer v-models end---------------

            //--------------------------

            //edit customer v-models start-----------------
            editName: '',
            editCustomerId: '',
            editInvoiceAddress: '',
            editSecondInvoiceAddress: '',
            editZipCode: '',
            editCity: '',
            editCountry: '',
            editOrganisationNumber: '',
            editPhoneNumber: '',
            editSecondPhoneNumber: '',
            editFax: '',
            editEmailAddress: '',
            editWebAddress: '',
            editDescription: '',
            //edit customer v-models end --------------------


            //delete customer v-models start-----------------

            deleteCustomerDialog: false,


            //delete customer v-models start-----------------


            selectedCustomerDialog: false,
            selectedProductForEdit: {},

            searchInput: '',

            addNewCustomerDialog: false,
            productSuccessfullyAddedDialog: false,



            placeholderArrayForProducts: [],
            listOfProducts: [],
        }),
        methods: {
            // DELETE customer START -------
            deleteCustomer() {
                this.deleteCustomerDialog = false,
                    CustomerAPI.DeleteCustomer(
                        {
                            CustomerId: this.customerId
                        }

                    );
            },   // DELETE customer START -------


            // UPDATE customer START -------
            updateExistingCustomer() {
                CustomerAPI.UpdateExistingCustomer({
                    Name: this.editName,
                    CustomerId: this.editCustomerId,
                    InvoiceAddress: this.editInvoiceAddress,
                    SecondInvoiceAddress: this.editSecondInvoiceAddress,
                    ZipCode: this.editZipCode,
                    City: this.editCity,
                    Country: this.editCountry,
                    OrganisationNumber: this.editOrganisationNumber,
                    PhoneNumber: this.editPhoneNumber,
                    SecondPhoneNumber: this.editSecondPhoneNumber,
                    Fax: this.editFax,
                    EmailAddress: this.editEmailAddress,
                    WebAddress: this.editWebAddress,
                    Description: this.editDescription
                });
            }, // UPDATE customer END -------

            showCustomerDetails(item) {
                this.customerId = item.customerId,
                    CustomerAPI.GetCustomerByCustomerId({ CustomerId: item.customerId }).then((response) => {
                        this.editName = response.name,
                            this.editCustomerId = response.customerId,
                            this.editInvoiceAddress = response.invoiceAddress,
                            this.editSecondInvoiceAddress = response.secondInvoiceAddress,
                            this.editZipCode = response.zipCode,
                            this.editCity = response.city,
                            this.editCountry = response.country,
                            this.editOrganisationNumber = response.organisationNumber,
                            this.editPhoneNumber = response.phoneNumber,
                            this.editSecondPhoneNumber = response.secondPhoneNumber,
                            this.editFax = response.fax,
                            this.editEmailAddress = response.emailAddress,
                            this.editWebAddress = response.webAddress,
                            this.editDescription = response.description
                    });
                this.selectedCustomerDialog = true
            },
            searchOnKeyup() {
                setTimeout(() => (

                    this.searchCustomers(
                        {
                            SearchWords: this.searchInput
                        })

                ), 1500)
            },
            productAddedDialog() {
                this.productSuccessfullyAddedDialog = true;
                setTimeout(() => (this.productSuccessfullyAddedDialog = false), 2000)
            },
            createNewCustomer() {
                this.showCustomerIdErrorMessage = false,
                    CustomerAPI.CreateNewCustomer(
                        {
                            Name: this.name,
                            CustomerId: this.customerId,
                            InvoiceAddress: this.invoiceAddress,
                            SecondInvoiceAddress: this.secondInvoiceAddress,
                            ZipCode: this.zipCode,
                            City: this.city,
                            Country: this.country,
                            OrganisationNumber: this.organisationNumber,
                            PhoneNumber: this.phoneNumber,
                            SecondPhoneNumber: this.secondPhoneNumber,
                            Fax: this.fax,
                            EmailAddress: this.emailAddress,
                            WebAddress: this.webAddress,
                            Description: this.description

                        },
                    ).then(result => {
                        if (result == 'Det finns redan en produkt med detta kundnummret, välj ett annat.') {
                            this.showCustomerIdErrorMessage = true
                        } else {
                            this.name = '',
                                this.customerId = '',
                                this.invoiceAddress = '',
                                this.secondInvoiceAddress = '',
                                this.zipCode = '',
                                this.city = '',
                                this.country = '',
                                this.organisationNumber = '',
                                this.phoneNumber = '',
                                this.secondPhoneNumber = '',
                                this.fax = '',
                                this.emailAddress = '',
                                this.webAddress = '',
                                this.description = ''
                        }
                    }),

                    this.productAddedDialog();
            },
            ...mapActions({
                getAllInvoices: 'customer/GET_ALL_INVOICES',
                searchInvoices: 'customer/SEARCH_INVOICES',
            }),
            closeDialog() {
                this.addNewCustomerDialog = false;
            }
        },
        computed: {
            ...mapState({
                allUserInvoicesToDisplay: state => state.customer.allUserInvoices
            }),
        },
        beforeMount() {
            this.getAllInvoices();
        }
    }


    /* eslint-enable no-console */
</script>

<style scoped>
    .customerIdErrorMessage {
        font-size: 14px;
        color: #e46b6b;
        padding: 10px;
    }
</style>
