<script setup>
import { Button } from "primevue";
import Layout from "@/components/layout.vue";
import Login from "@/components/forms/login.vue";
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
    <Layout page="DASHBOARD">
        <template #button="slot" v-if="authStore.isAuthenticated">
            <Button label="Logout" @click="onLogout" severity="danger" variant="outlined" rounded :class="slot.class" />
        </template>
        <div v-if="!authStore.isAuthenticated" class="max-w-[26rem]">
            <h1 class="text-2xl font-bold px-1 mb-8">Admin Account</h1>
            <Login />
        </div>
        <div v-else>
            <h1 class="text-2xl font-bold px-1 mb-8">Orders</h1>
        </div>
    </Layout>
</template>

<style scoped></style>
