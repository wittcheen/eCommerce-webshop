<script setup>
import { Divider } from "primevue";
import { formatDateTime, formatCurrency } from "@/utils/formats.js";

const props = defineProps({
    order: {
        type: Object, required: true
    }
});
</script>

<template>
    <div class="p-4 border border-surface-200 bg-surface-0 rounded-sm">
        <div class="flex justify-between items-center mb-4">
            <div>
                <h2 class="font-semibold text-lg">Order #{{ order.id }}</h2>
                <p class="text-xs text-gray-600">{{ formatDateTime(order.createdAt) }}</p>
            </div>
            <h2 class="font-bold text-lg">{{ formatCurrency(order.totalPrice, "DKK") }}</h2>
        </div>
        <p class="text-sm text-gray-600">{{ order.customer?.email }}</p>
        <Divider />
        <div v-for="item in order.items" :key="item.id" class="mb-1 last:mb-0 flex justify-between text-sm">
            <p>{{ item.quantity }} &times; {{ item.product.name }}</p>
            <p class="text-gray-600">{{ formatCurrency((item.quantity * item.price), "DKK") }}</p>
        </div>
    </div>
</template>

<style scoped></style>
