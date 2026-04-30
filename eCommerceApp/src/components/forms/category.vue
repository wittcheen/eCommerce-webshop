<script setup>
import { ref, reactive } from "vue";
import { Form } from "@primevue/forms";
import { Button, Dialog, InputText } from "primevue";
import FormField from "@/components/forms/form-field.vue";
import { categoryService } from "@/services/category.js";
import { useAuthStore } from "@/stores/auth.js";

const visible = ref(false);

const authStore = useAuthStore();
const initialValues = reactive({
    name: ""
});

const resolver = ({ values }) => {
    const errors = {};

    if (!values.name) {
        errors.name = [{ message: "Name is required." }];
    }

    return { values, errors };
};

const onFormSubmit = async ({ valid, values }) => {
    if (!valid) return;

    await categoryService.create(values, authStore.token);
    visible.value = false;
};
</script>

<template>
    <Button aria-label="New Category" icon="pi pi-plus" severity="secondary" @click="visible = true" size="small" class="mt-1.5 size-8" />
    <Dialog v-model:visible="visible" modal :draggable="false" blockScroll header="New Category" class="w-[25rem] text-surface-950">
        <Form v-slot="$form" :initialValues :resolver @submit="onFormSubmit">
            <FormField v-slot="slot" :form="$form" name="name" label="Name" required>
                <InputText name="name" type="text" fluid :class="slot.class" />
            </FormField>
            <div class="flex justify-end gap-2">
                <Button type="button" label="Cancel" severity="secondary" @click="visible = false" />
                <Button type="submit" label="Continue" severity="contrast" />
            </div>
        </Form>
    </Dialog>
</template>

<style scoped></style>
