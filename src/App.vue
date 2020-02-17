<template>
    <v-app>
        <v-navigation-drawer v-model="drawer"
                             app>
            <img src="../public/images/icons/icon-128x128.png" class="ml-10" alt="Alternate Text" />
            <v-list dense>

                <v-list-item>


                    <v-list-item-content>
                        <router-link class="linkStyle" to="/Dashboard">
                            <v-list-item-title>

                                <v-btn text color="indigo">
                                    Hem
                                </v-btn>
                                <!--<v-btn text> <router-link to="/Products">Artiklar</router-link></v-btn>
                    <v-btn text> <router-link to="/Customers">Kunder</router-link></v-btn>
                    <v-btn text> <router-link to="/Settings">Konto</router-link></v-btn>
                    <v-btn text> <router-link to="/Settings">Kontakta oss</router-link></v-btn>
                    <v-btn text> <router-link to="/Login">Logga in</router-link></v-btn>-->
                            </v-list-item-title>
                        </router-link>
                    </v-list-item-content>
                </v-list-item>


                <v-list-item>

                    <v-list-item-content>
                        <router-link class="linkStyle" to="/">
                            <v-list-item-title>
                                <v-btn text color="indigo">Dina Fakturor</v-btn>
                                <!--<v-btn text> <router-link to="/Products">Artiklar</router-link></v-btn>
    <v-btn text> <router-link to="/Customers">Kunder</router-link></v-btn>
    <v-btn text> <router-link to="/Settings">Konto</router-link></v-btn>
    <v-btn text> <router-link to="/Settings">Kontakta oss</router-link></v-btn>
    <v-btn text> <router-link to="/Login">Logga in</router-link></v-btn>-->
                            </v-list-item-title>
                        </router-link>
                    </v-list-item-content>
                </v-list-item>


                <v-list-item>
                    <router-link class="linkStyle" to="/Products">
                        <v-list-item-content>
                            <v-list-item-title>
                                <v-btn text color="indigo">
                                    Artiklar
                                </v-btn>
                            </v-list-item-title>
                        </v-list-item-content>
                    </router-link>
                </v-list-item>

                <v-list-item>
                    <!--<v-list-item-action>
            <v-icon>contact_mail</v-icon>
        </v-list-item-action>-->
                    <router-link class="linkStyle" to="/Customers">
                        <v-list-item-content>
                            <v-list-item-title>
                                <v-btn text color="indigo">
                                    Kunder
                                </v-btn>
                            </v-list-item-title>
                        </v-list-item-content>
                    </router-link>
                </v-list-item>

                <v-list-item>
                    <router-link class="linkStyle" to="/Settings">
                        <v-list-item-content>
                            <v-list-item-title>
                                <v-btn text color="indigo">
                                    Konto
                                </v-btn>
                            </v-list-item-title>
                        </v-list-item-content>
                    </router-link>
                </v-list-item>

                <!--<v-list-item @click="dothis">

        <v-list-item-content>
            <v-list-item-title>     <v-btn text> <router-link to="/Settings">Kontakta oss</router-link></v-btn></v-list-item-title>
        </v-list-item-content>
    </v-list-item>-->

            

             




            </v-list>
        </v-navigation-drawer>

        <v-app-bar app
                   color="indigo"
                   dark>
            <v-app-bar-nav-icon @click.stop="drawer = !drawer"></v-app-bar-nav-icon>
            <img src="../public/images/icons/icon-128x128.png" width="60" height="60" class="ml-10" alt="Alternate Text" />


            <v-toolbar-title>Dina Fakturor</v-toolbar-title>
        </v-app-bar>

        <v-content>
            <router-view></router-view>
        </v-content>
        <v-footer color="indigo"
                  app>
            <span class="white--text">Dina Fakturor &copy; 2019</span>
        </v-footer>
        <!--<v-content>
            <div>
                <v-toolbar>
                    <v-toolbar-title>Svenska Faktura System</v-toolbar-title>

                    <v-spacer></v-spacer>

                    <v-toolbar-items>
                        <v-btn text> <router-link to="/">Hem</router-link></v-btn>
                        <v-btn text> <router-link to="/Products">Artiklar</router-link></v-btn>
                        <v-btn text> <router-link to="/Customers">Kunder</router-link></v-btn>
                        <v-btn text> <router-link to="/Settings">Konto</router-link></v-btn>
                        <v-btn text> <router-link to="/Settings">Kontakta oss</router-link></v-btn>
                        <v-btn text> <router-link to="/Login">Logga in</router-link></v-btn>

                    </v-toolbar-items>

                </v-toolbar>
            </div>
            <router-view></router-view>
        </v-content>-->
    </v-app>
</template>

<script>

    export default {
        name: 'App',
        components: {

        },
        data: () => ({
            drawer: null
        }),
    }
</script>

<style scoped>
    .linkStyle{
        text-decoration:none;
    }
</style>