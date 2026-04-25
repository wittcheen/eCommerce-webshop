import { api } from './api.js';

export const categoryService = {
    getAll: async () => {
        return await api.get("/categories").json();
    }
};
