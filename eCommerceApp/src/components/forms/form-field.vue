<script setup>
import { Message } from "primevue";

defineProps({
    form: {
        type: Object, required: true
    },
    name: {
        type: String, required: true
    },
    label: {
        type: String, required: true
    },
    required: {
        type: Boolean, default: false
    }
});
</script>

<template>
    <label>
        <span class="inline-block mb-1">{{ label }}</span>
        <span v-if="required" class="pl-1 text-sm select-none">*</span>
        <slot :class="'rounded-sm py-1 focus:border-surface-800'" />
        <Message class="min-h-5.25 whitespace-pre-line" severity="error" variant="simple" size="small">{{ form?.[name]?.error?.message }}</Message>
    </label>
</template>

<style scoped></style>
