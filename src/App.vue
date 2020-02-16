<template>
    <v-app>
        <v-navigation-drawer v-model="drawer"
                             app>
            <v-list dense>


                <v-list-item>

                    <v-list-item-content>
                        <v-list-item-title>

                            <v-btn text> <router-link to="/">Hem</router-link></v-btn>
                            <!--<v-btn text> <router-link to="/Products">Artiklar</router-link></v-btn>
                <v-btn text> <router-link to="/Customers">Kunder</router-link></v-btn>
                <v-btn text> <router-link to="/Settings">Konto</router-link></v-btn>
                <v-btn text> <router-link to="/Settings">Kontakta oss</router-link></v-btn>
                <v-btn text> <router-link to="/Login">Logga in</router-link></v-btn>-->
                        </v-list-item-title>
                    </v-list-item-content>
                </v-list-item>


                <v-list-item>
                   
                    <v-list-item-content>
                        <v-list-item-title><v-btn text> <router-link to="/Products">Artiklar</router-link></v-btn></v-list-item-title>
                    </v-list-item-content>
                </v-list-item>

                <v-list-item>
                    <!--<v-list-item-action>
                        <v-icon>contact_mail</v-icon>
                    </v-list-item-action>-->
                    <v-list-item-content>
                        <v-list-item-title> <v-btn text> <router-link to="/Customers">Kunder</router-link></v-btn></v-list-item-title>
                    </v-list-item-content>
                </v-list-item>

                <v-list-item>
                   
                    <v-list-item-content>
                        <v-list-item-title>  <v-btn text> <router-link to="/Settings">Konto</router-link></v-btn></v-list-item-title>
                    </v-list-item-content>
                </v-list-item>

                <!--<v-list-item @click="dothis">
                  
                    <v-list-item-content>
                        <v-list-item-title>     <v-btn text> <router-link to="/Settings">Kontakta oss</router-link></v-btn></v-list-item-title>
                    </v-list-item-content>
                </v-list-item>-->

                <v-list-item>
                   
                    <v-list-item-content>
                        <v-list-item-title>   <v-btn text> <router-link to="/Login">Logga in</router-link></v-btn></v-list-item-title>
                    </v-list-item-content>
                </v-list-item>




            </v-list>
        </v-navigation-drawer>

        <v-app-bar app
                   color="indigo"
                   dark>
            <v-app-bar-nav-icon @click.stop="drawer = !drawer"></v-app-bar-nav-icon>
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
};
</script>
