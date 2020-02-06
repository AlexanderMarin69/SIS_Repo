"use strict";

import axios from "axios";

export default {
    /* eslint-disable no-console */
    CreateNewCustomer: (data) => {
        return axios.post('/api/customers/CreateNewCustomer', data)
            .then(result => {
                return result.data;
            });
    },
    UpdateExistingCustomer: (data) => {
        return axios.post('/api/customers/UpdateExistingCustomer', data)
            .then(result => {
                return result.data;
            });
    },
    DeleteCustomer: (data) => {
        return axios.post('/api/customers/DeleteCustomer', data)
            .then(result => {
                return result.data;
            });
    },
    GetAllCustomers: () => {
        return axios.get('/api/customers/GetAllCustomers')
            .then(result => {
                return result.data;
            });
    },
    GetCustomerByCustomerId: (id) => {
        return axios.post('/api/customers/GetCustomerByCustomerId', id)
            .then(result => {
                return result.data;
            });
    },
    SearchCustomers: (data) => {
        return axios.post('/api/customers/SearchCustomers', data)
            .then(result => {
                return result.data;
            });
    },
    /* eslint-enable no-console */
}