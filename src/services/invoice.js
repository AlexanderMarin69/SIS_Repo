"use strict";

import axios from "axios";

export default {
/* eslint-disable no-console */
    GeneratePdfInvoice: (vm) => {
        return axios.post('/api/CreateInvoice/GenerateInvoicePdf', vm);
    },

    SendInvoiceViaMail: (vm) => {
        return axios.post('/api/CreateInvoice/SendInvoiceViaMail', vm)
            .then(result => {
                console.log(result.data, 'success mannen');
                return result.data;

            }).catch(result => { console.log(result, 'error mannen'); })

            ;
    },

    
/* eslint-enable no-console */
}