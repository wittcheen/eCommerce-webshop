<script setup>
import { computed } from "vue";
import { Button, Tag } from "primevue";
import { formatCurrency } from "@/utils/formats";

const props = defineProps({
    product: {
        type: Object, required: true
    }
});

const placeholder = "https://placeholder.vn/placeholder/300x200";
const isOutOfStock = computed(() => props.product.stock <= 0);
</script>

<template>
    <div class="p-4 border border-surface-200 bg-surface-0 rounded-sm flex flex-col">
        <div class="aspect-[3/2] bg-surface-50 flex items-center justify-center rounded-sm overflow-hidden max-w-[300px] mx-auto relative">
            <img class="w-full h-full object-cover" :src="!product.image ? placeholder : product.image" :alt="product.name" />
            <Tag v-if="isOutOfStock" value="Out of Stock" severity="danger" class="absolute left-1 top-1" />
        </div>
        <div class="pt-4">
            <h3 class="text-lg font-medium line-clamp-1">{{ product.name }}</h3>
            <p class="text-sm text-surface-600 line-clamp-2 min-h-10">{{ product.description }}</p>
            <div class="flex flex-col gap-4 mt-4">
                <p class="text-2xl font-semibold">{{ formatCurrency(product.price, "DKK") }}</p>
                <Button icon="pi pi-shopping-cart" severity="contrast" label="Buy" :disabled="isOutOfStock" :class="{ 'hover:opacity-90': !isOutOfStock }" />
            </div>
        </div>
    </div>
</template>

<style scoped></style>
