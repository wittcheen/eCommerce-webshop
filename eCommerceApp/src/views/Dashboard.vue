<script setup>
import { Button } from "primevue";
import Layout from "@/components/layout.vue";
import Login from "@/components/forms/login.vue";
import { useAuthStore } from "@/stores/auth.js";

const authStore = useAuthStore();
</script>

<template>
    <Layout page="DASHBOARD">
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
