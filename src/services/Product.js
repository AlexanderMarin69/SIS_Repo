"use strict";

import axios from "axios";

export default {
    /* eslint-disable no-console */
    CreateNewProduct: (data) => {
        return axios.post('/api/product/CreateNewProduct', data)
            .then(result => {
                return result.data;
            });
    },
    UpdateExistingProduct: (data) => {
        return axios.post('/api/product/UpdateExistingProduct', data)
            .then(result => {
                return result.data;
            });
    },
    DeleteProduct: (data) => {
        return axios.post('/api/product/DeleteProduct', data)
            .then(result => {
                return result.data;
            });
    },
    GetAllProducts: () => {
        return axios.get('/api/Product/GetAllProducts')
            .then(result => {
                return result.data;
            });
    },
    GetProductById: (id) => {
        return axios.post('/api/Product/GetProductById', id)
            .then(result => {
                return result.data;
            });
    },
    SearchProducts: (data) => {
        return axios.post('/api/product/SearchProducts', data)
            .then(result => {
                return result.data;
            });
    },
    /* eslint-enable no-console */
}