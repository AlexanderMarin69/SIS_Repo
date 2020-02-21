"use strict";

import axios from "axios";

export default {
/* eslint-disable no-console */
    GeneratePdfInvoice: () => {
        return axios.post('/api/CreateInvoice/GenerateInvoicePdf');
    },
    SendInvoiceViaMail: () => {
        return axios.post('/api/Invoice/SendInvoiceViaMail')
            .then(result => {
                console.log(result.data, 'success mannen');
                return result.data;

            }).catch(result => { console.log(result, 'error mannen'); })

            ;
    },
    GetAllInvoices: () => {
        return axios.get('/api/customers/GetAllCustomers')
            .then(result => {
                return result.data;
            });
    },

    CreateNewInvoice: (vm) => {
        return axios.post('/api/Invoice/CreateNewInvoice', vm);
    },

    PrintPdf: () => {
        return axios.post('/api/CreateInvoice/PrintInvoicePdf');
    },

    
/* eslint-enable no-console */
}