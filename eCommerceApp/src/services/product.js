import { api } from './api.js';

export const productService = {
    getAll: () => {
        return api.get("/products").json();
    },

    getByCategory: (id) => {
        return api.get("/products", { searchParams: { categoryId: id }}).json();
    }
};
