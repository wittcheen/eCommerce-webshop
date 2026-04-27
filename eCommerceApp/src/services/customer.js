import { api } from './api.js';

export const customerService = {
    create: (data) => {
        return api.post("/customers/add", { json: data }).json();
    }
};
