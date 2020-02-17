<template>
    <div>
        <v-container fluid
                     fill-height>
            <v-layout align-center
                      justify-center>
                <v-flex xs12
                        sm8
                        md4>
                    <v-card class="elevation-12">
                        <v-toolbar color="indigo"
                                   dark
                                   flat>
                            <v-toolbar-title>Logga in till Dina Fakturor</v-toolbar-title>

                        </v-toolbar>
                        <v-card-text>
                            <v-form>
                           
                                <v-text-field label="E-post" v-model="username"
                                              prepend-icon="mdi-account"
                                              name="E-post"
                                              type="email"></v-text-field>

                                <v-text-field id="password"
                                              label="Lösenord" v-model="password"
                                               prepend-icon="mdi-lock"
                                              name="password"
                                              type="password"></v-text-field>
                            </v-form>
                        </v-card-text>
                        <v-form class="pa-5">
                            <v-layout row wrap text-center>
                                <v-flex xs12>
                                    <!--<v-text-field type="email" v-model="username" label="Username"></v-text-field>
                <v-text-field type="password" v-model="password" label="Password"></v-text-field>-->
                                    <v-btn large color="primary" @click="login()">Logga in</v-btn>
                                    <div class="mt-10 justify-center line-wrapper">
                                        <div>
                                            <div :class="themeMode ? 'light' : 'dark'" class="line"></div>
                                            eller
                                            <div :class="themeMode ? 'light' : 'dark'" class="line"></div>
                                        </div>
                                    </div>
                                    <v-btn large class="mt-10" color="success" @click="register">Registrera dig</v-btn>
                                </v-flex>
                            </v-layout>
                        </v-form>
                    </v-card>
                </v-flex>
            </v-layout>
        </v-container>
       
        <br />
        <br />
        <br />
        <br />

    </div>
</template>

<style scoped>
    .line {
        height: 1px;
        width: 20%;
        display: inline-block;
        margin-bottom: 10px;
        margin-right: 7px;
    }

    .line-wrapper {
        font-size: 40px;
        font-weight: 200;
        margin: 0 auto;
        width: 100%;
    }

    .light {
        background-color: #fff;
        color: #000;
    }

    .dark {
        background-color: #000;
        color: #fff;
    }
</style>

<script>
    import { mapState, mapMutations, mapActions } from 'vuex';

    export default {
        methods: {
            ...mapMutations({
                setUsername: 'login/SET_USERNAME',
                setPassword: 'login/SET_PASSWORD',
            }),
            ...mapActions('login', {
                userLogin: 'LOGIN'
            }),
            login() {
                let data = { vm: this.loginViewModel, redirectUrl: this.redirectUrl };
                this.userLogin(data);
            },
            register() {
                this.$router.push('/register');
            }
        },
        computed: {
            ...mapState({
                loginViewModel: state => state.login.loginViewModel,
                errors: state => state.login.errors,
                redirectUrl: state => state.login.redirectUrl,
                IsUserLoggedInVariable: state => state.login.isUserLoggedIn
            }),
            password: {
                get() {
                    return this.loginViewModel.password
                },
                set(value) {
                    this.setPassword(value)
                }
            },
            username: {
                get() {
                    return this.loginViewModel.username
                },
                set(value) {
                    this.setUsername(value)
                }
            },
            rememberMe: {
                get() {
                    return this.loginViewModel.rememberMe
                },
                set(value) {
                    this.setRememberMe(value)
                }
            },
            themeMode: {
                get() { return this.$vuetify.theme.dark }
            }
        }
    }
</script>