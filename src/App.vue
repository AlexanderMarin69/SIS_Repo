<template>
    <v-app>

        <v-content>
            <div>
                <v-toolbar>
                    <v-toolbar-title>Svenska Faktura System</v-toolbar-title>

                    <v-spacer></v-spacer>

                    <v-toolbar-items>
                        <v-btn text> <router-link to="/">Hem</router-link></v-btn>
                        <v-btn text> <router-link to="/Products">Artiklar</router-link></v-btn>
                        <v-btn text> <router-link to="/Customers">Kunder</router-link></v-btn>
                        <v-btn text> <router-link to="/Login">Logga in</router-link></v-btn>
                    
                    </v-toolbar-items>

                    <!--<template v-if="$vuetify.breakpoint.smAndUp">
                        <v-btn icon>
                            <v-icon>mdi-export-variant</v-icon>
                        </v-btn>
                        <v-btn icon>
                            <v-icon>mdi-delete-circle</v-icon>
                        </v-btn>
                        <v-btn icon>
                            <v-icon>mdi-plus-circle</v-icon>
                        </v-btn>
                    </template>-->
                </v-toolbar>
            </div>
            <router-view></router-view>
        </v-content>
    </v-app>
</template>

<script>
  

export default {
  name: 'App',
        components: {
           
        }, 
  data: () => ({
      
  }),
};
</script>
