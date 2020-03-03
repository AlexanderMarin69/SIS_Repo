"use strict";

import axios from "axios";

export default {
    register: (vm) => {
        return axios.post('/api/account/register', vm);
    },
    changePassword: (vm) => {
        return axios.post('/api/account/ChangePassword', vm);
    },
    login: (vm) => {
        return axios.post('https://dinafakturor.se:80/api/account/login', vm);
    },
    isUserLoggedIn: () => {
        return axios.get('http://dinafakturor.se/api/account/isuserloggedin', { withCredentials: true });
    },
    logout: () => {
        return axios.post('/api/Account/logout', { withCredentials: true });
    },
    getUser: () => {
        return axios.get('/api/account/GetLoggedUser', { withCredentials: true });
    },
    updateUser: (vm) => {
        return axios.post('/api/account/updateUser', vm);
    },
}