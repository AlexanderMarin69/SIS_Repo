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
                <v-btn color="black" @click="addNewCustomerDialog = !addNewCustomerDialog" class="ml-3">
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
                                <v-col cols="12" sm="6" md="4">
                                    <v-text-field v-model="editName" label="Namn"></v-text-field>
                                </v-col>
                                <v-col cols="12" sm="6" md="4">
                                    <v-text-field readonly v-model="editCustomerId" label="Kundnummer"></v-text-field>
                                </v-col>
                                <v-col cols="12" sm="6" md="4">
                                    <v-text-field v-model="editInvoiceAddress" label="Fakturaadress"></v-text-field>
                                </v-col>
                                <v-col cols="12" sm="6" md="4">
                                    <v-text-field v-model="editSecondInvoiceAddress" label="Fakturaadress 2"></v-text-field>
                                </v-col>
                                <v-col cols="12" sm="6" md="4">
                                    <v-text-field v-model="editZipCode" label="Postnr"></v-text-field>
                                </v-col>
                                <v-col cols="12" sm="6" md="4">
                                    <v-text-field v-model="editCity" label="Ort"></v-text-field>
                                </v-col>
                                <v-col cols="12" sm="6" md="4">
                                    <v-text-field v-model="editCountry" label="Land"></v-text-field>
                                </v-col>
                                <v-col cols="12">
                                    <v-text-field v-model="editOrganisationNumber" label="Organisationsnummer"></v-text-field>
                                </v-col>
                                <v-col cols="12" sm="6" md="4">
                                    <v-text-field v-model="editPhoneNumber" label="Telefonnummer"></v-text-field>
                                </v-col>
                                <v-col cols="12" sm="6" md="4">
                                    <v-text-field v-model="editSecondPhoneNumber" label="Andra telefonnummer"></v-text-field>
                                </v-col>
                                <v-col cols="12" sm="6" md="4">
                                    <v-text-field v-model="editFax" label="Fax"></v-text-field>
                                </v-col>
                                <v-col cols="12" sm="6" md="4">
                                    <v-text-field v-model="editEmailAddress" label="E-post"></v-text-field>
                                </v-col>
                                <v-col cols="12" sm="6" md="4">
                                    <v-text-field v-model="editWebAddress" label="Webbadress"></v-text-field>
                                </v-col>
                                <v-col cols="12" sm="12" md="12">
                                    <v-text-field v-model="editDescription" label="Beskrivning / egna anteckningar"></v-text-field>
                                </v-col>
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
    </div>
</template>

<script>
    /* eslint-disable no-console */
    import { mapState, mapActions } from 'vuex';
    import CustomerAPI from '@/services/Customer'
    export default {
        data: () => ({

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
                getAllCustomers: 'customer/GET_ALL_CUSTOMERS',
                searchCustomers: 'customer/SEARCH_CUSTOMERS',
            }),
            closeDialog() {
                this.addNewCustomerDialog = false;
            }
        },
        computed: {
            ...mapState({
                allUserCustomersToDisplay: state => state.customer.allUserCustomers
            }),
        },
        beforeMount() {
            this.getAllCustomers();
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
