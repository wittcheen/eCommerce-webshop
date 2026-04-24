<script setup>
import { Button, Drawer } from "primevue";
import { useCartStore } from "@/stores/cart.js";
import { formatCurrency } from "@/utils/formats.js";

defineProps({
    visible: {
        type: Boolean
    }
});

defineEmits(["update:visible"]);
const cart = useCartStore();
</script>

<template>
    <Drawer v-bind:visible="visible" position="right" blockScroll class="w-[30rem] text-surface-950">
        <template #container>
            <header class="flex py-1 md:py-2 px-2 md:px-6 items-center justify-between">
                <h3 class="text-lg pl-3 flex-1">Your shopping bag</h3>

                <Button aria-label="Close" severity="contrast" variant="text" rounded @click="$emit('update:visible', false)" class="h-10 w-auto border-0">
                    <i class="pi pi-times"></i>
                    <span class="text-sm">Close</span>
                </Button>
            </header>

            <main class="size-full p-5 pt-0 overflow-y-auto">
                <div class="md:px-4 flex flex-col h-full justify-between">
                    <section class="border-t-2 py-6 gap-3 flex flex-col">
                        <h2 v-if="!cart.items.length" class="text-gray-600 text-md">Bag is empty</h2>
                        <div v-for="item in cart.items" :key="item.id" class="pb-2 border-b-1 border-surface">
                            <div class="flex justify-between items-center">
                                <p class="text-md flex-1">{{ item.name }}</p>
                                <Button aria-label="Remove" icon="pi pi-times" severity="contrast" variant="text" rounded @click="cart.remove(item.id)" icon-class="text-red-700" class="size-8" />
                            </div>
                            <p class="text-sm">{{ item.quantity }} &times; {{ formatCurrency(item.price, "DKK") }}</p>
                        </div>
                    </section>
                    <section class="border-t-2 py-6">
                        <h2 class="text-xl font-semibold mb-3">Total: {{ formatCurrency(cart.totalPrice, "DKK") }}</h2>
                        <Button label="Checkout" severity="contrast" rounded fluid @click="$router.push('/checkout')" :disabled="!cart.items.length" class="py-2.5" />
                    </section>
                </div>
            </main>
        </template>
    </Drawer>
</template>

<style scoped></style>
