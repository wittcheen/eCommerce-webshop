<script setup>
import { Button, OverlayBadge } from "primevue";
</script>

<template>
    <nav class="fixed w-full h-24 md:h-14 z-[100] px-2 md:px-6 bg-surface-0 border-b-2 border-surface flex justify-between items-center">
        <router-link to="/" class="pl-2">
            <span class="font-bold text-lg">eCommerce</span>
        </router-link>

        <div class="flex sm:gap-2">
            <Button aria-label="User" icon="pi pi-user" severity="contrast" variant="text" rounded @click="$router.push('admin')" icon-class="text-xl" class="size-10" />
            <Button aria-label="Shopping Bag" severity="contrast" variant="text" rounded @click="$router.push('cart')" class="size-10">
                <OverlayBadge value="0" size="small" severity="contrast" class="h-5" pt:pcbadge:root="h-3.5 min-w-3.5 leading-[normal] -translate-x-1/4 translate-y-1/4">
                    <i class="pi pi-shopping-bag text-xl"></i>
                </OverlayBadge>
            </Button>
        </div>
    </nav>
</template>

<style scoped></style>
