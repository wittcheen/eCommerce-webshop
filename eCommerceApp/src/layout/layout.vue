<script setup>
import { ref } from "vue";
import Topbar from "@/layout/topbar.vue";
import CartDrawer from "@/layout/cart-drawer.vue";

const drawerVisible = ref(false);
</script>

<template>
    <Topbar @open-drawer="drawerVisible = true" />
    <CartDrawer v-model:visible="drawerVisible" />
    <div class="pt-24 md:pt-[5.5rem] px-8 flex flex-col min-h-screen">
        <main class="pb-8 2xl:px-16 flex-1">
            <router-view />
        </main>
    </div>
</template>

<style scoped></style>
