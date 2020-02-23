"use strict";

import axios from "axios";

export default {
/* eslint-disable no-console */

    //TODO: vm is not sent, but string is console logged correctly, 
    //maybe cache not updated on app run, console.log worked after 3 app updates and empty site data...
    GeneratePdfInvoice: (vm) => {
        console.log(vm, 'GeneratePdfInvoice');
        return axios.post('/api/CreateInvoice/GenerateInvoicePdf', vm);
    },
    SendInvoiceViaMail: (vm) => {
        console.log(vm, 'SendInvoiceViaMail');
        return axios.post('/api/Invoice/SendInvoiceViaMail', vm)
            .then(result => {
                console.log(result.data, 'success mannen');
                return result.data;

            }).catch(result => { console.log(result, 'error mannen'); })

            ;
    },
    GetAllInvoices: () => {
        return axios.get('/api/Invoice/GetAllInvoices')
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