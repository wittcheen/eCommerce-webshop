<script setup>
import { Button } from "primevue";

defineProps({
    categories: {
        type: Array, required: true
    },
    modelValue: {
        type: Number
    }
});

defineEmits(["update:modelValue"]);
</script>

<template>
    <div class="flex gap-2 flex-wrap">
        <Button label="All" :severity="!modelValue ? 'contrast' : 'secondary'" rounded raised @click="$emit('update:modelValue', null)" class="px-4 py-2" />
        <Button v-for="c in categories" :key="c.id" :label="c.name" :severity="modelValue === c.id ? 'contrast' : 'secondary'" rounded raised @click="$emit('update:modelValue', c.id)" class="px-4 py-2" />
    </div>
</template>

<style scoped></style>
