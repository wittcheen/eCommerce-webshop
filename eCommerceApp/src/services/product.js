import { api } from './api.js';

export const productService = {
    getAll: () => {
        return api.get("/products").json();
    },

    getByCategory: (id) => {
        return api.get("/products", { searchParams: { categoryId: id }}).json();
    },

    create: (data, token) => {
        return api.post("/products/add", { headers: {
            Authorization: `Bearer ${token}`
        }, json: data }).json();
    }
};
