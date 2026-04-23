<script setup>
import { ref, computed } from "vue";
import Filter from "@/components/widgets/filter.vue";
import Product from "@/components/widgets/product.vue";

// Sample categories
const categories = ref([
    {
        id: 1,
        name: "Category 1"
    },
    {
        id: 2,
        name: "Category 2"
    }
]);

// Sample products
const products = ref([
    {
        id: 1,
        name: "Product 1",
        description: "Lorem ipsum dolor sit amet consectetur adipisicing elit. Reprehenderit, libero veritatis sunt dicta vitae eum quas dolorem cupiditate pariatur magnam? Ex quaerat pariatur molestias amet rem nihil expedita ipsam repellat!",
        price: 99,
        stock: 10,
        category: 1,
        image: ""
    },
    {
        id: 2,
        name: "Product 2",
        description: "Lorem ipsum dolor sit amet consectetur adipisicing elit. Reprehenderit, libero veritatis sunt dicta vitae eum quas dolorem cupiditate pariatur magnam? Ex quaerat pariatur molestias amet rem nihil expedita ipsam repellat!",
        price: 99,
        stock: 0,
        category: 2,
        image: ""
    },
    {
        id: 3,
        name: "Product 3",
        description: "Lorem ipsum dolor sit amet consectetur adipisicing elit. Reprehenderit, libero veritatis sunt dicta vitae eum quas dolorem cupiditate pariatur magnam? Ex quaerat pariatur molestias amet rem nihil expedita ipsam repellat!",
        price: 99,
        stock: 10,
        category: 1,
        image: ""
    }
]);

const selectedCategory = ref(null);

const filteredProducts = computed(() => {
    if (!selectedCategory.value) return products.value;
    return products.value.filter(p => p.category === selectedCategory.value);
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
        <article v-for="p in filteredProducts" :key="p.id" class="col-span-12 sm:col-span-6 md:col-span-4 xl:col-span-3 p-2">
            <Product :product="p" />
        </article>
    </div>
</template>

<style scoped></style>
