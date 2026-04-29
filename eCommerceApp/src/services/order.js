import { api } from './api.js';

export const orderService = {
    getAll: (token) => {
        return api.get("/orders", { headers: {
            Authorization: `Bearer ${token}`
        } }).json();
    },

    create: (data) => {
        return api.post("/orders/add", { json: data }).json();
    }
};
