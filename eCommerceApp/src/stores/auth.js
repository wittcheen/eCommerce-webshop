import { defineStore } from 'pinia';
import { ref, computed } from 'vue';
import { authService } from '@/services/auth.js';

export const useAuthStore = defineStore("auth", () => {
    const user = ref(null);
    const token = ref(localStorage.getItem("token") || null)
    const isInitialized = ref(false)
    const isAuthenticated = computed(() => Boolean(token.value));

    const init = async () => {
        if(!token.value) {
            isInitialized.value = true;
            return;
        }

        try {
            user.value = await authService.fetchUser(token.value);
        } catch (error) {
            logout();
        } finally {
            isInitialized.value = true;
        }
    };

    const set = (data) => {
        user.value = data.user;
        token.value = data.token;
        localStorage.setItem("token", data.token);
    };

    const logout = () => {
        user.value = null;
        token.value = null;
        localStorage.removeItem("token");
    };

    return {
        user,
        token,
        isInitialized,
        isAuthenticated,
        init,
        set,
        logout
    };
});
