<template>
    <v-card class="mx-auto"
            max-width="500">


        <v-toolbar color="indigo"
                   dark>


            <v-toolbar-title>Mitt Konto</v-toolbar-title>

            <v-spacer></v-spacer>


        </v-toolbar>

        <v-container fluid>
            <v-row dense>
                <v-col cols="12" sm="12" md="12">
                    <v-card>


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
                                ändra
                            </v-btn>
                        </v-card-actions>
                    </v-card>
                </v-col>

                <v-col cols="12" sm="12" md="12">
                    <v-card>
                        <v-card-title v-text="extraSettingsTitle"></v-card-title>
                        <v-col cols="12" sm="12" md="12">
                            <v-text-field readonly placeholder="Alexander" label="Namn"></v-text-field>
                            <v-text-field readonly placeholder="Marin" label="Efternamn"></v-text-field>
                            <v-text-field readonly placeholder="alexandermarin@gmail.com" label="Webbadress"></v-text-field>
                        </v-col>
                        <v-card-actions>
                            <v-spacer></v-spacer>
                            <v-btn text color="primary">
                                ändra
                            </v-btn>
                        </v-card-actions>
                    </v-card>
                </v-col>

                <v-col cols="12" sm="12" md="12">
                    <v-card>
                        <v-card-title v-text="subscriptionSettingsTitle"></v-card-title>
                        <v-col cols="12" sm="12" md="12">
                            <v-text-field readonly placeholder="89kr/mån - 12 mån" label="Betalplan"></v-text-field>
                            <v-text-field readonly placeholder="2020 - 02 - 16" label="Gick med"></v-text-field>
                            <v-text-field readonly placeholder="2021 - 02 - 16" label="Utgår"></v-text-field>
                        </v-col>
                        <v-card-actions>
                            <v-spacer></v-spacer>
                            <v-btn text color="primary">
                                mer
                            </v-btn>
                        </v-card-actions>
                    </v-card>
                </v-col>

                <v-col cols="12" sm="12" md="12">
                    <v-card>
                        <v-card-title v-text="feedbackSettingsTitle"></v-card-title>
                        <v-col cols="12" sm="12" md="12">
                            <v-textarea readonly label="Lämna feedback"></v-textarea>
                        </v-col>
                        <v-card-actions>
                            <v-spacer></v-spacer>
                            <v-btn text color="primary">
                                Skicka feedback
                            </v-btn>
                        </v-card-actions>
                    </v-card>
                </v-col>

                <p class="mt-5">Din Faktura v 0.1.0</p>

            </v-row>
        </v-container>
    </v-card>
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