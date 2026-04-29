<script setup>
import { ref, watch } from "vue";
import { Button } from "primevue";
import Layout from "@/components/layout.vue";
import Login from "@/components/forms/login.vue";
import Order from "@/components/widgets/order.vue";
import { useAuthStore } from "@/stores/auth.js";
import { authService } from "@/services/auth.js";
import { orderService } from "@/services/order.js";

const authStore = useAuthStore();
const orders = ref([]);
let interval;

const fetchOrders = async () => {
    orders.value = await orderService.getAll(authStore.token);
};

watch(() => authStore.isAuthenticated, async (isAuth, _, onInvalidate) => {
        clearInterval(interval);
        if (!isAuth) {
            orders.value = [];
            return;
        }

        await fetchOrders();

        interval = setInterval(() => {
            if (document.visibilityState === "visible") {
                fetchOrders();
            }
        }, 30000); // every 30 seconds
        onInvalidate(() => clearInterval(interval));
    },
    { immediate: true }
);

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
            <h2 v-if="!orders.length" class="text-gray-600 text-md">No orders yet</h2>
            <div class="grid gap-4">
                <Order v-for="o in orders" :key="o.id" :order="o" />
            </div>
        </div>
    </Layout>
</template>

<style scoped></style>
