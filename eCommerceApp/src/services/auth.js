import { api } from './api.js';

export const authService = {
    fetchUser: (token) => {
        return api.get("/users/me", { headers: {
            Authorization: `Bearer ${token}`
        } }).json();
    },

    login: (email, password) => {
        return api.post("/auth/login", { json: { email, password } }).json();
    },

    logout: () => {
        return api.post("/auth/logout");
    }
};
