<script setup>
defineProps({
    page: {
        type: String, required: true
    }
});
</script>

<template>
    <nav class="fixed w-full h-14 z-[100] px-6 bg-surface-0 border-b-2 border-surface flex justify-between items-center">
        <div class="flex gap-3 items-center">
            <router-link to="/" class="pl-2">
                <span class="font-bold text-lg">eCommerce</span>
            </router-link>
            <div class="pl-3 font-light border-l-1">{{ page }}</div>
        </div>
        <slot name="button" :class="'h-10'" />
    </nav>
    <div class="pt-[5.5rem] px-8 flex flex-col min-h-screen">
        <main class="pb-8 2xl:px-16 flex-1">
            <slot />
        </main>
    </div>
</template>

<style scoped></style>
