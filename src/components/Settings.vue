<template>
    <div class="pl-1 pr-1">
    <v-card class="mx-auto" raised shaped
            max-width="1000">


        <v-toolbar light>


            <v-toolbar-title flat><v-icon class="mr-1">mdi-account</v-icon> Mitt Konto</v-toolbar-title>

            <v-spacer></v-spacer>


        </v-toolbar>

        <v-container fluid>
            <v-row>
                <v-col cols="12" sm="12" md="3">
                    <v-card shaped>

                        <v-icon class="ml-3 mt-3">mdi-account-cog-outline</v-icon>
                        <v-card-title v-text="accountSettingsTitle"></v-card-title>
                        <v-col cols="12" sm="12" md="12">
                            <v-text-field readonly placeholder="Alexander" label="Namn"></v-text-field>
                            <v-text-field readonly placeholder="Marin" label="Efternamn"></v-text-field>
                            <v-text-field readonly placeholder="alexandermarin@gmail.com" label="Webbadress"></v-text-field>
                            <v-text-field readonly placeholder="alexandermarin@gmail.com" label="Skicka faktura från"></v-text-field>

                            <v-text-field readonly placeholder="********" label="Lösenord"></v-text-field>
                        </v-col>


                        <v-card-actions>
                            <v-spacer></v-spacer>
                            <v-btn text color="primary">
                                <v-icon class="mr-1">mdi-pencil</v-icon>  ändra
                            </v-btn>
                        </v-card-actions>
                    </v-card>
                </v-col>

                <v-col cols="12" sm="12" md="3">
                    <v-card shaped>
                        <v-icon class="ml-3 mt-3">mdi-card-plus-outline</v-icon>
                        <v-card-title v-text="extraSettingsTitle"></v-card-title>
                        <v-col cols="12" sm="12" md="12">
                            <v-text-field readonly placeholder="Alexander" label="Namn"></v-text-field>
                            <v-text-field readonly placeholder="Marin" label="Efternamn"></v-text-field>
                            <v-text-field readonly placeholder="alexandermarin@gmail.com" label="Webbadress"></v-text-field>
                        </v-col>
                        <v-card-actions>
                            <v-spacer></v-spacer>
                            <v-btn text color="primary">
                                <v-icon class="mr-1">mdi-pencil</v-icon>  ändra
                            </v-btn>
                        </v-card-actions>
                    </v-card>
                </v-col>

                <v-col cols="12" sm="12" md="3">
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

                <v-col cols="12" sm="12" md="3">
                    <v-card shaped>
                        <v-icon class="ml-3 mt-3">mdi-head-lightbulb-outline</v-icon>
                        <v-card-title v-text="feedbackSettingsTitle"></v-card-title>
                        <p class="blockquote">Lämna feedback om något du vill ha annorlunda eller rapportera ett problem.</p>
                        <v-col cols="12" sm="12" md="12">
                            <v-textarea readonly label="Lämna feedback här..."></v-textarea>
                        </v-col>
                        <v-card-actions>
                            <v-spacer></v-spacer>
                            <v-btn text color="primary">
                                <v-icon class="mr-1">mdi-cube-send</v-icon>  Skicka feedback
                            </v-btn>
                        </v-card-actions>
                    </v-card>
                </v-col>

                <p class="mt-5 ml-3">Dina Fakturor v 0.1.0</p>

            </v-row>
        </v-container>
    </v-card>
        </div>
</template>

<style scoped>
</style>

<script>
    export default {
        data: () => ({
            accountSettingsTitle: 'Kontoinställningar',
            subscriptionSettingsTitle: 'Abonnemang',
            extraSettingsTitle: 'Övriga inställningar',
            feedbackSettingsTitle: 'Feedback',
            
        }),
        methods: {

        },
    }
</script>