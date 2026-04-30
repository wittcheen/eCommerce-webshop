<script setup>
import { Button } from "primevue";
import Layout from "@/components/layout.vue";
import Product from "@/components/forms/product.vue";
import { useAuthStore } from "@/stores/auth.js";
import { authService } from "@/services/auth.js";

const authStore = useAuthStore();

const onLogout = async () => {
    try {
        await authService.logout();
    } catch (error) {
        console.error("Logout failed:", error);
    } finally {
        authStore.logout();
    }
};
</script>

<template>
    <Layout page="PRODUCT MANAGER">
        <template #button="slot" v-if="authStore.isAuthenticated">
            <Button label="Logout" @click="onLogout" severity="danger" variant="outlined" rounded :class="slot.class" />
        </template>
        <div>
            <header class="flex justify-between items-center px-1 mb-8">
                <h1 class="text-2xl font-bold">Create Product</h1>
                <Button label="Dashboard" @click="$router.push('/admin')" unstyled class="underline text-surface-800" />
            </header>
            <Product />
        </div>
    </Layout>
</template>

<style scoped></style>
