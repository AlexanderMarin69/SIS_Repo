<template>
    <div class="pl-1 pr-1">
        <v-card max-width="1000px" raised shaped
                class="mx-auto">
            <v-toolbar light>
                <v-toolbar-title color="black">Alla Fakturor</v-toolbar-title>
                <v-spacer></v-spacer>
                <!--<v-btn icon class="ml-3 mr-3">
                    <v-icon>mdi-magnify</v-icon>
                    sök
                </v-btn>-->
                <v-btn color="primary" rounded style="color: white;" @click="activateCreateNewInvoiceDialog()" class="ml-3">
                    Skapa ny +
                </v-btn>
            </v-toolbar>
            <v-card color="grey lighten-4" outlined>
                <v-toolbar dense style="box-shadow: 0px 0px 0px 0px rgba(0, 0, 0, 0.0), 0px 0px 0px 0px rgba(0, 0, 0, 0.0), 0px 0px 0px 0px rgba(0, 0, 0, 0.0);">
                    <!--<v-toolbar-title>Title</v-toolbar-title>-->
                    <v-text-field class="pa-2 mt-4" placeholder="Hitta..." v-model="searchInput" @keyup="searchOnKeyup"></v-text-field>
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
                                <!--<v-col cols="12" sm="6" md="4">
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
                                </v-col>-->
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

                                <v-col cols="12" sm="12" md="12">
                                    <v-select v-model="select"
                                              :hint="`${select.name}, ${select.city}, ${select.phoneNumber}, ${select.emailAddress}, ${select.customerId}`"
                                              :items="allCustomers"
                                              item-text="descriptiveDataForSelectList"
                                              item-value="customerId"
                                              label="Välj kund"
                                              return-object
                                              single-line></v-select>
                                </v-col>
                                <v-col cols="12" sm="6" md="6">
                                    <v-menu ref="invoiceDateMenu"
                                            v-model="invoiceDateMenu"
                                            :close-on-content-click="false"
                                            :return-value.sync="invoiceDate"
                                            transition="scale-transition"
                                            offset-y
                                            min-width="290px">
                                        <template v-slot:activator="{ on }">
                                            <v-text-field v-model="invoiceDate"
                                                          label="Fakturadatum"
                                                          readonly
                                                          v-on="on"></v-text-field>
                                        </template>
                                        <v-date-picker v-model="invoiceDate" no-title scrollable>
                                            <v-spacer></v-spacer>
                                            <v-btn text color="primary" @click="invoiceDateMenu = false">Avbryt</v-btn>
                                            <v-btn text color="primary" @click="$refs.invoiceDateMenu.save(invoiceDate)">OK</v-btn>
                                        </v-date-picker>
                                    </v-menu>
                                </v-col>
                                <v-col cols="12" sm="6" md="6">
                                    <v-menu ref="invoicePayDateMenu"
                                            v-model="invoicePayDateMenu"
                                            :close-on-content-click="false"
                                            :return-value.sync="invoicePayDate"
                                            transition="scale-transition"
                                            offset-y
                                            min-width="290px">
                                        <template v-slot:activator="{ on }">
                                            <v-text-field v-model="invoicePayDate"
                                                          label="Förfallodatum"
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

                                <v-col cols="12" sm="6" md="6">
                                    <v-container>
                                        <p>Fakturatyp</p>
                                        <v-radio-group v-model="invoiceType" :mandatory="false">
                                            <v-radio label="Faktura" value="Faktura"></v-radio>
                                            <v-radio label="Kontantfaktura" value="Kontantfaktura"></v-radio>
                                        </v-radio-group>
                                    </v-container>
                                </v-col>

                                <v-col cols="12" sm="6" md="6">
                                    <v-container>
                                        <p>Kreditfaktura</p>
                                        <v-radio-group v-model="invoiceIsCredit" :mandatory="false">
                                            <v-radio label="Ja" value="Ja"></v-radio>
                                            <v-radio label="Nej" value="Nej"></v-radio>
                                        </v-radio-group>
                                    </v-container>
                                </v-col>







                                <!-- dialog ------------------------ start-->

                                <v-dialog v-model="addProductsToInvoiceDialog" max-width="290">
                                    <template v-slot:activator="{ on }">
                                        <v-btn color="primary" rounded dark v-on="on">Lägg till produkter</v-btn>
                                    </template>
                                    <v-card raised shaped>

                                        <AllProductsForInvoice></AllProductsForInvoice>

                                        <v-card-actions>
                                            <v-spacer></v-spacer>
                                            <v-btn color="primary" text @click="addProductsToInvoiceDialog = false">Stäng</v-btn>
                                        </v-card-actions>
                                    </v-card>
                                </v-dialog>


                                <!-- dialog ------------------------ end -->

                                <v-list two-line>
                                    <v-list-item-group>
                                        <template v-for="(item, index) in InvoiceProductsToDisplay">
                                            <v-list-item :key="item.name">
                                                <template>
                                                    <v-list-item-content v-if="InvoiceProductsToDisplay.length < 1">

                                                    </v-list-item-content>
                                                    <v-list-item-content>
                                                        <v-list-item-subtitle v-text="item.articleNumber" class="pa-1"></v-list-item-subtitle>
                                                        <v-list-item-title v-text="item.name" class="pa-1" style="font-weight: bold;"></v-list-item-title>
                                                        <v-list-item-subtitle class="text--primary pa-1" v-text="item.name"></v-list-item-subtitle>
                                                        <v-list-item-subtitle class="text--primary pa-1"></v-list-item-subtitle>
                                                        <div><v-btn color="red" small @click="removeProductFromInvoiceList(item.articleNumber)">ta bort</v-btn></div>
                                                    </v-list-item-content>
                                                    <v-list-item-action>
                                                        <v-col cols="4" sm="6" md="12">
                                                            <v-text-field v-model="item.price" @keyup="updateInvoiceProductPriceData(item.articleNumber, item.price)" label="Välj pris"></v-text-field>
                                                        </v-col>
                                                        <v-col cols="4" sm="6" md="12">
                                                            <v-text-field v-model="item.quantity" @keyup="updateInvoiceProductQuantityData(item.articleNumber, item.quantity)" label="Välj antal"></v-text-field>
                                                        </v-col>
                                                    </v-list-item-action>
                                                </template>
                                            </v-list-item>
                                            <v-divider v-if="index + 1 < InvoiceProductsToDisplay.length"
                                                       :key="index"></v-divider>
                                        </template>
                                    </v-list-item-group>
                                </v-list>

                                <v-col cols="12" sm="6" md="3">
                                    <v-text-field v-model="deliveryFee" @keyup="kanin()" label="Fraktavgift"></v-text-field>
                                </v-col>

                                <v-col cols="12" sm="6" md="3">
                                    <v-text-field v-model="invoiceFee" @keyup="kanin()" label="Fakturaavgift"></v-text-field>
                                </v-col>
                                <v-col cols="12" sm="6" md="2">
                                    <v-text-field v-model="optionalReminderFee" @keyup="kanin()" label="Påminnelseavgift"></v-text-field>
                                </v-col>
                                <v-col cols="12" sm="6" md="4">
                                    <v-spacer></v-spacer>
                                    <v-card class="pa-2">
                                        <!--<v-text-field v-text="totalInvoiceItemsPriceToDisplay + ' SEK'" readonly label="Summa"></v-text-field>-->
                                        <!--<p><b>Total exkl. moms</b> 2 003 kr</p>

            <p><b>Moms 25%</b> 480 kr</p>

            <p><b>Öresutjämning</b> 0,50 kr</p>-->

                                        <p class="mt-10"><b><!--Total att belala {{totalTyp + totalInvoiceItemsPriceToDisplay}} kr--></b></p>

                                        <v-simple-table>
                                            <tbody>
                                                <tr>
                                                    <td>Totalt exkl. moms</td>
                                                    <td>{{totalTyp + totalInvoiceItemsPriceToDisplay}} kr</td>

                                                </tr>
                                                <tr>

                                                    <td>Moms 25%</td>
                                                    <td>{{totalTyp * 1.25 - totalTyp + totalInvoiceItemsPriceToDisplay * 1.25 - totalInvoiceItemsPriceToDisplay}} kr</td>

                                                </tr>
                                                <tr>

                                                    <td>Öresutjämning</td>
                                                    <td>{{totalTyp * 1.25 + totalInvoiceItemsPriceToDisplay * 1.25 - Math.round(totalTyp * 1.25 + totalInvoiceItemsPriceToDisplay * 1.25)}} kr</td>
                                                </tr>

                                                <tr>

                                                    <td><h3><b>Att belala</b></h3></td>
                                                    <td><h3><b>{{Math.round(totalTyp * 1.25 + totalInvoiceItemsPriceToDisplay * 1.25)}} kr</b></h3></td>

                                                </tr>
                                            </tbody>
                                        </v-simple-table>

                                    </v-card>
                                </v-col>
                                <v-col cols="12" sm="12" md="12">
                                    <v-text-field v-model="invoiceMessageText" label="Fakturatext"></v-text-field>
                                </v-col>
                            </v-list-item-content>
                        </v-list-item>
                    </v-list>
                    <v-btn color="primary" @click="printPdf()">Skriv ut</v-btn>
                    <v-spacer></v-spacer>
                    <!--<v-card-actions>
                        <v-overflow-btn class="my-2"
                                        :items="dropdown_icon"
                                        label="Skicka som"
                                        segmented
                                        target="#dropdown-example"></v-overflow-btn>
                    </v-card-actions>-->
                    <v-col cols="12" sm="6" md="6">
                        <v-container>
                            <p>Skicka som</p>
                            {{sendAs || null}}
                        <v-radio-group v-model="sendAs" :mandatory="false">
                            <v-radio label="Faktura" value="Faktura"></v-radio>
                            <v-radio v-if="invoiceType == 'Faktura'" label="Offert" value="Offert"></v-radio>
                            <v-radio v-if="invoiceType == 'Faktura'" label="Påminnelse" value="Påminnelse"></v-radio>

                        </v-radio-group>
                        </v-container>
                    </v-col>
                    <v-card-actions>
                        <v-btn color="primary" large rounded class="mt-3 mr-5">
                            Skicka
                        </v-btn>
                        <v-spacer></v-spacer>
                        <v-btn color="primary" large rounded class="ma-3" @click="saveInvoice()">
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
    import InvoiceAPI from '@/services/invoice'
    import AllProductsForInvoice from '@/components/AllProductsForInvoice'
    export default {
        components: {
            AllProductsForInvoice
        },
        data: () => ({
            invoiceType: 'Faktura',
            invoiceIsCredit: 'Nej',
            sendAs: 'Faktura',

            totalInvoiceCost: 0,

            addProductsToInvoiceDialog: false,
            //actions on click push list selectedFruits to vuex array and then finally on save push get array in object and push to api
            //TO FIX
            searchCustomers: '',
            showCustomerIdErrorMessage: false,
            searchProducts: '',
            allUserCustomersToDisplay: '',
            select: {
                phoneNumber: '',
                city: '',
                emailAddress: '',
                name: 'Välj kund',
                customerId: ''
            },
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
            //create invoice v-models start------------
            deliveryFee: 0,
            invoiceFee: 0,
            optionalReminderFee: 0,
            invoiceMessageText: '',
            customerId: '',
            //create invoice v-models end---------------
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
            totalTyp: 0,
        }),
        methods: {
            printPdf() {
                InvoiceAPI.PrintPdf();
            },
            kanin() {
                this.totalTyp = parseInt(this.invoiceFee) + parseInt(this.optionalReminderFee) + parseInt(this.deliveryFee);
            },
            activateCreateNewInvoiceDialog() {
                this.resetInvoiceProductListAction();
                this.createNewInvoiceDialog = true
            },
            //updateDeliveryFee(deliveryFee) {
            //     setTimeout(() => (
            //        this.updateDeliveryFeeAction(deliveryFee)
            //     ), 500)
            //},
            //updateInvoiceFee(invoiceFee) {
            //     setTimeout(() => (
            //        this.updateInvoiceFeeAction(invoiceFee)
            //     ), 3000)
            //},
            updateInvoiceProductPriceData(articleNumber, price) {
                setTimeout(() => (
                    this.updateProductPriceListAction({ articleNumber, price })
                ), 3000)

                setTimeout(() => (
                    this.calculateTotalPriceAction()
                ), 1000)
            },
            updateInvoiceProductQuantityData(articleNumber, quantity) {
                setTimeout(() => (
                    this.updateProductQuantityListAction({ articleNumber, quantity })
                ), 1000)

                setTimeout(() => (
                    this.calculateTotalPriceAction()
                ), 1000)
            },
            removeProductFromInvoiceList(articleNumber) {
                this.removeInvoiceProductListAction({ articleNumber });
            },
            addToInvoiceProductList(item) {
                this.addToInvoiceProductListAction(item)
                this.calculateTotalPriceAction();
            },
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
            saveInvoice() {
                this.showCustomerIdErrorMessage = false,
                    InvoiceAPI.CreateNewInvoice(
                        {
                            InvoiceDate: this.invoiceDate,
                            InvoicePayDate: this.invoicePayDate,
                            InvoiceTypeToSend: this.invoiceType,
                            InvoiceIsCredit: this.invoiceIsCredit,
                            InvoiceProducts: this.InvoiceProductsToDisplay,
                            InvoiceFee: this.invoiceFee,
                            DeliveryFee: this.deliveryFee,
                            OptionalReminderFee: this.optionalReminderFee,
                            InvoiceMessageText: this.invoiceMessageText,
                            SendAs: this.sendAs,
                            AssociatedCustomerId: this.select.customerId,
                            ExtraInvoiceCosts: this.totalTyp,
                            InvoiceProductsTotalCost: this.totalInvoiceItemsPriceToDisplay
                        },
                    ),
                    this.productAddedDialog();
            },
            ...mapActions({
                //getAllInvoices: 'customer/GET_ALL_INVOICES',
                //searchInvoices: 'customer/SEARCH_INVOICES',
                getAllCustomers: 'customer/GET_ALL_CUSTOMERS',
                getAllProducts: 'warehouse/GET_ALL_PRODUCTS',
                addToInvoiceProductListAction: 'invoice/ADD_PRODUCT_TO_LIST',
                updateProductPriceListAction: 'invoice/UPDATE_PRODUCT_PRICE_FROM_LIST',
                updateProductQuantityListAction: 'invoice/UPDATE_PRODUCT_QUANTITY_FROM_LIST',
                removeInvoiceProductListAction: 'invoice/REMOVE_PRODUCT_FROM_LIST',
                searchWarehouse: 'warehouse/SEARCH_WAREHOUSE',
                resetInvoiceProductListAction: 'invoice/RESET_INVOICE_PRODUCT_LIST_ON_ENTER',
                calculateTotalPriceAction: 'invoice/CALCULATE_TOTAL_INVOICE_ITEMS_PRICE',
                //updateInvoiceFeeAction: 'invoice/UPDATE_INVOICE_FEE',
                //updateDeliveryFeeAction: 'invoice/UPDATE_DELIVERY_FEE',
            }),
            closeDialog() {
                this.addNewCustomerDialog = false;
            }
        },
        computed: {
            ...mapState({
                //allUserInvoicesToDisplay: state => state.customer.allUserInvoices,
                allCustomers: state => state.customer.allUserCustomers,
                warehouseProductsToDisplay: state => state.warehouse.warehouseProducts,
                InvoiceProductsToDisplay: state => state.invoice.InvoiceProducts,
                totalInvoiceItemsPriceToDisplay: state => state.invoice.totalInvoiceItemsPrice,
            }),
        },
        beforeMount() {
            //this.getAllInvoices();
            this.getAllCustomers();
            this.getAllProducts();
            this.calculateTotalPriceAction();
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

    @media all and (display-mode: standalone) {
        /*works*/
    }
</style>
