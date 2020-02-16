<template>
    <div>

        <br />




        <v-row>

            <v-col cols="12" sm="6" md="6">
                <v-card class="mt-4 mx-auto"
                        max-width="300">
                    <v-sheet class="v-sheet--offset mx-auto"
                             color="green"
                             elevation="12"
                             max-width="calc(100% - 32px)">
                        <v-sparkline :labels="labelss"
                                     :value="valuess"
                                     color="white"
                                     line-width="2"
                                     padding="16"></v-sparkline>
                    </v-sheet>

                    <v-card-text class="pt-0">
                        <div class="title font-weight-light mb-2">Försäljning senaste 6 månaderna</div>
                        <v-divider class="my-2"></v-divider>
                        <!--<v-icon class="mr-2"
                        small>
                    mdi-clock
                </v-icon>
                <span class="caption grey--text font-weight-light">last registration 26 minutes ago</span>-->
                    </v-card-text>
                </v-card>
            </v-col>

            <v-col cols="12" sm="6" md="6">
                <v-card class="mt-4 mx-auto"
                        max-width="300">
                    <v-sheet class="v-sheet--offset mx-auto"
                             color="cyan"
                             elevation="12"
                             max-width="calc(100% - 32px)">
                        <v-sparkline :labels="labels"
                                     :value="values"
                                     color="white"
                                     line-width="2"
                                     padding="16"></v-sparkline>
                    </v-sheet>

                    <v-card-text class="pt-0">
                        <div class="title font-weight-light mb-2">Dina nya kunder</div>
                        <div class="subheading font-weight-light grey--text">Antalet nya kunder som du registrerat i systemet den senaste månaden.</div>
                        <v-divider class="my-2"></v-divider>
                        <!--<v-icon class="mr-2"
                        small>
                    mdi-clock
                </v-icon>
                <span class="caption grey--text font-weight-light">last registration 26 minutes ago</span>-->
                    </v-card-text>
                </v-card>
            </v-col>

        </v-row>



        <v-row class="mt-5">

            <v-col cols="12" sm="6" md="6">
                <v-card class="mx-auto" raised shaped
                        max-width="344">
                    <v-list-item three-line>
                        <v-list-item-content>
                            <div class="overline mb-4">Information</div>
                            <v-list-item-title class="headline mb-1">Försäljning</v-list-item-title>
                            <v-list-item-subtitle>Du har sålt för 33 476:- hittils denna månaden</v-list-item-subtitle>
                        </v-list-item-content>

                        <v-list-item-avatar raised
                                            size="80"
                                            color="success">
                            <v-icon large color="white">mdi-arrow-up</v-icon>
                        </v-list-item-avatar>
                    </v-list-item>

                </v-card>
            </v-col>

            <v-col cols="12" sm="6" md="6">
                <v-card class="mx-auto" raised shaped
                        max-width="344">
                    <v-list-item three-line>
                        <v-list-item-content>
                            <div class="overline mb-4">Information</div>
                            <v-list-item-title class="headline mb-1">Obetalda fakturor</v-list-item-title>
                            <v-list-item-subtitle>Du har 2 kunder som inte har betalat sina fakturor i tid</v-list-item-subtitle>
                        </v-list-item-content>

                        <v-list-item-avatar raised
                                            size="80"
                                            color="error">
                            <v-icon large color="white">mdi-alert-circle-outline</v-icon>
                        </v-list-item-avatar>
                    </v-list-item>
                </v-card>
            </v-col>

        </v-row>


    </div>
</template>

<script>
    export default {
        data: function () {
            return {
                labels: [
                    'Januari',
                    'Februari',
                    'Mars',
                    'April',
                    'Maj',
                    'Juni'
                ],
                values: [
                    200,
                    300,
                    100,
                    390,
                    100,
                    460
                ],
                 labelss: [
                    'Januari',
                    'Februari',
                    'Mars',
                    'April',
                    'Maj',
                    'Juni'
                ],
                valuess: [
                    200,
                    300,
                    100,
                    390,
                    100,
                    460
                ],
            }
        },
    }

</script>

<style scoped>
    .v-sheet--offset {
        top: -24px;
        position: relative;
    }
</style>
