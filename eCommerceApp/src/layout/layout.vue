<script setup>
import Topbar from "@/layout/topbar.vue";
</script>

<template>
    <Topbar />
    <div class="pt-32 md:pt-[5.5rem] px-8 flex flex-col min-h-screen">
        <main class="pb-8 2xl:px-16 flex-1">
            <router-view />
        </main>
    </div>
</template>

<style scoped></style>
