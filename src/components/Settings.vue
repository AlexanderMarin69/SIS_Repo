<template>
    <div class="pl-1 pr-1">

        <template>
            <v-row justify="center">
                <v-dialog v-model="accountSettingsDialog" persistent max-width="1000">
                    <v-card>
                        <v-card-title class="headline">
                            Kontoinställningar
                        </v-card-title>
                        <v-card-actions>
                            <v-spacer></v-spacer>
                            <v-btn color="primary" text @click="accountSettingsDialog = false">stäng</v-btn>
                            <v-btn color="primary" text @click="contactMessageSentDialog = false">Spara ändringar</v-btn>
                        </v-card-actions>

                        <v-card-actions>
                            <v-spacer></v-spacer>
                            <v-btn color="primary" text @click="accountSettingsDialog = false">stäng</v-btn>
                            <v-btn color="primary" text @click="contactMessageSentDialog = false">Spara ändringar</v-btn>
                        </v-card-actions>
                    </v-card>
                </v-dialog>
            </v-row>
        </template>
        <v-card class="mx-auto" raised shaped
                max-width="1000">


            <v-toolbar light>


                <v-toolbar-title flat><v-icon class="mr-1">mdi-account</v-icon> Mitt Konto</v-toolbar-title>

                <v-spacer></v-spacer>

                <v-btn color="primary" @click="logout()">Logga ut</v-btn>

            </v-toolbar>

            <v-container fluid>
                <v-row>
                    <v-col cols="12" sm="12" md="12">
                        <v-card shaped>

                            <v-icon class="ml-3 mt-3">mdi-account-cog-outline</v-icon>
                            <v-card-title v-text="accountSettingsTitle"></v-card-title>
                            <v-card-text>
                                <v-container>
                                    <v-row>
                                        <v-col cols="12" sm="6" md="4">
                                            <v-text-field v-model="firstName" label="Förnamn"></v-text-field>
                                        </v-col>
                                        <v-col cols="12" sm="6" md="4">
                                            <v-text-field v-model="lastName" label="Efternamn"></v-text-field>
                                        </v-col>
                                        <v-col cols="12" sm="6" md="4">
                                            <v-text-field v-model="companyName" label="Företagsnamn"></v-text-field>
                                        </v-col>
                                        <v-col cols="12" sm="6" md="4">
                                            <v-text-field v-model="orgNr" label="Organisationsnummer"></v-text-field>
                                        </v-col>
                                        <v-col cols="12" sm="6" md="4">
                                            <v-text-field v-model="momsRegNr" label="Momsregistrerinsnummer"></v-text-field>
                                        </v-col>
                                        <v-col cols="12" sm="6" md="4">
                                            <v-text-field v-model="emailAddress" label="E-post"></v-text-field>
                                            <small>Dina fakturor skickas från denna E-postadressen</small>
                                        </v-col>
                                        <v-col cols="12" sm="6" md="4">
                                            <v-text-field v-model="invoiceAddress" label="Adress"></v-text-field>
                                        </v-col>
                                        <v-col cols="12" sm="6" md="4">
                                            <v-text-field v-model="zipCode" label="Postkod"></v-text-field>
                                        </v-col>
                                        <v-col cols="12" sm="6" md="4">
                                            <v-text-field v-model="city" label="Ort"></v-text-field>
                                        </v-col>
                                        <v-col cols="12" sm="6" md="4">
                                            <v-text-field v-model="country" label="Land"></v-text-field>
                                        </v-col>
                                        <v-col cols="12" sm="6" md="4">
                                            <v-text-field v-model="phoneNumber" label="Telefonnummer"></v-text-field>
                                        </v-col>
                                        <v-col cols="12" sm="6" md="4">
                                            <v-text-field v-model="fax" label="Fax"></v-text-field>
                                        </v-col>
                                        <v-col cols="12" sm="6" md="4">
                                            <v-text-field v-model="plusGiro" label="Plusgiro"></v-text-field>
                                        </v-col>
                                        <v-col cols="12" sm="6" md="4">
                                            <v-text-field v-model="bankGiro" label="Bankgiro"></v-text-field>
                                        </v-col>
                                        <v-col cols="12" sm="6" md="4">
                                            <v-text-field v-model="paymentTerms" label="Betalningsvillkor"></v-text-field>
                                            <small>Exempel "30 dagar"</small>
                                        </v-col>
                                        <v-col cols="12" sm="6" md="4">
                                            <v-text-field v-model="invoicecPastDuePercentageFee" label="Dröjsmålsränta"></v-text-field>
                                            <small>Exempel "10%"</small>
                                        </v-col>


                                    </v-row>
                                </v-container>
                            </v-card-text>
                            <v-card-actions>
                                <v-spacer></v-spacer>
                                <v-btn text @click="updateSettings()" color="primary">
                                    <v-icon class="mr-1">mdi-pencil</v-icon>  spara
                                </v-btn>


                            </v-card-actions>
                        </v-card>
                    </v-col>
                </v-row>
                <v-row>
                    <v-col cols="12" sm="12" md="6">
                        <v-card shaped>

                            <v-icon class="ml-3 mt-3">mdi-card-text-outline</v-icon>
                            <v-card-title v-text="subscriptionSettingsTitle"></v-card-title>
                            <v-col cols="12" sm="12" md="12">
                                <v-text-field readonly placeholder="89kr/mån - 12 mån" label="Betalplan"></v-text-field>
                                <v-text-field readonly placeholder="2020 - 02 - 16" label="Gick med"></v-text-field>
                                <v-text-field readonly placeholder="2021 - 02 - 16" label="Utgår"></v-text-field>
                            </v-col>
                            <v-card-actions>
                                <v-spacer></v-spacer>
                                <v-btn text color="primary">
                                    <v-icon class="mr-1">mdi-clipboard-text</v-icon>   detaljer
                                </v-btn>
                            </v-card-actions>
                        </v-card>
                    </v-col>

                    <v-col cols="12" sm="12" md="6">
                        <v-card shaped>
                            <v-icon class="ml-3 mt-3">mdi-message-text-outline</v-icon>
                            <v-card-title v-text="feedbackSettingsTitle"></v-card-title>
                            <v-col cols="12" sm="12" md="12">
                                <v-textarea style="color:black;" v-model="contactMessage" label="Lämna ditt meddelande"></v-textarea>
                            </v-col>
                            <v-card-actions>
                                <v-spacer></v-spacer>
                                <v-btn text disabled v-if="contactMessage.length < 1" color="primary">
                                    <v-icon class="mr-1">mdi-cube-send</v-icon>  Skicka
                                </v-btn>

                                <v-btn text v-else @click="contactMessageSentDialog = true" color="primary">
                                    <v-icon class="mr-1">mdi-cube-send</v-icon>  Skicka
                                </v-btn>

                                <template>
                                    <v-row justify="center">
                                        <v-dialog v-model="contactMessageSentDialog" persistent max-width="290">
                                            <v-card>
                                                <v-card-title class="headline">
                                                    Käften mannen
                                                </v-card-title>
                                                <v-card-text>

                                                </v-card-text>
                                                <v-card-actions>
                                                    <v-spacer></v-spacer>
                                                    <v-btn color="green darken-1" text @click="contactMessageSentDialog = false">okej</v-btn>
                                                    <v-btn color="green darken-1" text @click="contactMessageSentDialog = false">acceptera</v-btn>
                                                </v-card-actions>
                                            </v-card>
                                        </v-dialog>
                                    </v-row>
                                </template>
                            </v-card-actions>
                        </v-card>
                    </v-col>
                    <p class="mt-5 ml-3">Dina Fakturor v 0.1.0</p>
                </v-row>
            </v-container>
        </v-card>
        <br />
    </div>
</template>

<style scoped>
</style>

<script>
    import { mapActions } from 'vuex';
    import AccountApi from '@/services/account'
    import router from '@/plugins/default.router.js'
    export default {
        data: () => ({
            // v-models
            firstName: '',
            lastName: '',
            companyName: '',
            orgNr: '',
            momsRegNr: '',
            emailAddress: '',
            invoiceAddress: '',
            zipCode: '',
            city: '',
            country: '',
            phoneNumber: '',
            fax: '',
            plusGiro: '',
            bankGiro: '',
            paymentTerms: '',
            invoicecPastDuePercentageFee: '',
            contactMessage: '',
            // v-models

            // dialogs
            accountSettingsDialog: false,
            contactMessageSentDialog: false,
            // dialogs

            //titles
            accountSettingsTitle: 'Kontoinställningar',
            subscriptionSettingsTitle: 'Abonnemang',
            feedbackSettingsTitle: 'Kontakt',
            //titles
        }),
        methods: {
            updateSettings() {
                AccountApi.updateUser(
                    {
                        FirstName: this.firstName,
                        LastName: this.lastName,
                        CompanyName: this.companyName,
                        OrgNr: this.orgNr,
                        MomsRegNr: this.momsRegNr,
                        Country: this.country,
                        EmailAddress: this.emailAddress,
                        InvoiceAddress: this.invoiceAddress,
                        ZipCode: this.zipCode,
                        City: this.city,
                        PhoneNumber: this.phoneNumber,
                        Fax: this.fax,
                        PlusGiro: this.plusGiro,
                        BankGiro: this.bankGiro,
                        PaymentTerms: this.paymentTerms,
                        InvoicecPastDuePercentageFee: this.invoicecPastDuePercentageFee
                    }).then(response => {
                          /*eslint no-console: */
            // custom console
            console.log(response, 'updateResponse');
                        this.firstName = response.data.firstName,
                            this.lastName = response.data.lastName,
                            this.companyName = response.data.companyName,
                            this.orgNr = response.data.orgNr,
                            this.momsRegNr = response.data.momsRegNr,
                            this.emailAddress = response.data.emailAddress,
                            this.invoiceAddress = response.data.invoiceAddress,
                            this.zipCode = response.data.zipCode,
                            this.city = response.data.city,
                            this.phoneNumber = response.data.phoneNumber,
                            this.fax = response.data.fax,
                            this.plusGiro = response.data.plusGiro,
                            this.bankGiro = response.data.bankGiro,
                            this.paymentTerms = response.data.paymentTerms,
                            this.invoicecPastDuePercentageFee = response.data.invoicecPastDuePercentageFee

                    });
            },
            getUser() {
                AccountApi.getUser().then(response => {
                                   /*eslint no-console: */
            // custom console
            console.log(response, 'getUserResponse');
                        this.firstName = response.data.firstName,
                            this.lastName = response.data.lastName,
                            this.companyName = response.data.companyName,
                            this.orgNr = response.data.orgNr,
                            this.momsRegNr = response.data.momsRegNr,
                            this.emailAddress = response.data.emailAddress,
                            this.invoiceAddress = response.data.invoiceAddress,
                            this.zipCode = response.data.zipCode,
                            this.city = response.data.city,
                            this.phoneNumber = response.data.phoneNumber,
                            this.fax = response.data.fax,
                            this.plusGiro = response.data.plusGiro,
                            this.bankGiro = response.data.bankGiro,
                            this.country = response.data.country,
                            this.paymentTerms = response.data.paymentTerms,
                            this.invoicecPastDuePercentageFee = response.data.invoicecPastDuePercentageFee

                    });
            },
            logout() {
                AccountApi.logout(),
                    router.push('/login');
                this.setLoggedInStatusToFalse()
            },
            ...mapActions({
                setLoggedInStatusToFalse: 'login/SET_LOGGED_IN_STATE_FALSE',
                getUserData: 'login/GET_USERDATA',
            }),
        },
        beforeMount() {
            this.getUser();
        }
    }
</script>