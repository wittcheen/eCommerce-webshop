import { api } from './api.js';

export const categoryService = {
    getAll: async () => {
        return await api.get("/categories").json();
    },

    create: (data, token) => {
        return api.post("/categories/add", { headers: {
            Authorization: `Bearer ${token}`
        }, json: data }).json();
    }
};
