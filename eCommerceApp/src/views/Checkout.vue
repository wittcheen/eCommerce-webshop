<script setup>
import { useRouter } from "vue-router";
import { Button } from "primevue";
import Customer from '@/components/forms/customer.vue';
import { useCartStore } from "@/stores/cart.js";
import { formatCurrency } from "@/utils/formats.js";
import { customerService } from "@/services/customer";
import { orderService } from "@/services/order";

const router = useRouter();
const cart = useCartStore();

const submitOrder = async (customer) => {
    if (!cart.items.length) return;

    var data = await customerService.create(customer);
    const order = {
        customerID: data.id,
        totalPrice: cart.totalPrice,
        items: cart.items.map(i => ({
            productID: i.id,
            quantity: i.quantity,
            price: i.price
        }))
    };
    await orderService.create(order);

    router.push("/");
    cart.clear();
    alert("Order placed!");
};
</script>

<template>
    <nav class="fixed w-full h-14 z-[100] px-6 bg-surface-0 border-b-2 border-surface flex gap-3 items-center">
        <router-link to="/" class="pl-2">
            <span class="font-bold text-lg">eCommerce</span>
        </router-link>
        <div class="pl-3 font-light border-l-1">CHECKOUT</div>
    </nav>
    <div class="pt-[5.5rem] px-8 flex flex-col min-h-screen">
        <main class="pb-8 2xl:px-16 flex-1">
            <div class="grid md:grid-cols-2 gap-8">
                <section class="order-2 md:order-1">
                    <h1 class="text-2xl font-bold mb-8">Shipping Details</h1>
                    <Customer @customer="submitOrder" />
                </section>
                <section class="order-1 md:order-2 border border-surface-200 bg-surface-0 rounded-md p-4">
                    <h1 class="text-xl font-bold flex justify-between pb-4">Order Summary
                        <Button label="Edit Order" @click="$router.push('/')" unstyled class="underline text-base font-normal" />
                    </h1>
                    <div v-for="item in cart.items" :key="item.id" class="mb-2 flex justify-between">
                        <p>{{ item.quantity }} &times; {{ item.name }}</p>
                        <p>{{ formatCurrency((item.quantity * item.price), "DKK") }}</p>
                    </div>
                    <div class="border-t-2 pt-2 mt-4 flex justify-between">
                        <h2 class="text-lg font-semibold">Total</h2>
                        <h2 class="text-lg font-semibold">{{ formatCurrency(cart.totalPrice, "DKK") }}</h2>
                    </div>
                </section>
            </div>
        </main>
    </div>
</template>

<style scoped></style>
