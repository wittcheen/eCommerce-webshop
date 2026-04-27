import { api } from './api.js';

export const orderService = {
    create: (data) => {
        return api.post("/orders/add", { json: data }).json();
    }
};
