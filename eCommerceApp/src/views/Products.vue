<script setup>
import { ref, onMounted, watch } from "vue";
import Filter from "@/components/widgets/filter.vue";
import Product from "@/components/widgets/product.vue";

import { categoryService } from "@/services/category.js";
import { productService } from "@/services/product.js";

const categories = ref([]);
const products = ref([]);
const selectedCategory = ref(null);

onMounted(async () => {
    categories.value = await categoryService.getAll();
    products.value = await productService.getAll();
});

watch(selectedCategory, async (id) => {
    if (!id) {
        products.value = await productService.getAll();
    } else {
        products.value = await productService.getByCategory(id);
    }
});
</script>

<template>
    <header class="text-center mb-8">
        <h1 class="text-4xl font-bold mb-2">Products</h1>
        <p class="text-gray-600">Browse our collection</p>
    </header>

    <div class="flex justify-center mb-10">
        <Filter v-model="selectedCategory" :categories="categories" />
    </div>

    <div class="grid grid-cols-12 gap-4 2xl:max-w-fit place-self-center">
        <article v-for="p in products" :key="p.id" class="col-span-12 sm:col-span-6 md:col-span-4 xl:col-span-3 p-2">
            <Product :product="p" />
        </article>
    </div>
</template>

<style scoped></style>
