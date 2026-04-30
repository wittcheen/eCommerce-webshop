<script setup>
import { useRouter } from "vue-router";
import { ref, reactive, onMounted } from "vue";
import { Form } from "@primevue/forms";
import { Button, InputText, InputNumber, Select } from "primevue";
import FormField from "@/components/forms/form-field.vue";
import Category from "@/components/forms/category.vue";
import { productService } from "@/services/product.js";
import { categoryService } from "@/services/category.js";
import { useAuthStore } from "@/stores/auth.js";

const router = useRouter();
const authStore = useAuthStore();
const categories = ref([]);
const initialValues = reactive({
    name: "",
    description: "",
    price: 0,
    stock: 0,
    categoryID: { id: 0 },
    images: [{ url: "" }]
});

onMounted(async () => {
    categories.value = await categoryService.getAll();
});

const resolver = ({ values }) => {
    const errors = {};

    if (!values.name) {
        errors.name = [{ message: "Name is required." }];
    }

    if (!values.description) {
        errors.description = [{ message: "Description is required." }];
    }

    if (values.price <= 0) {
        errors.price = [{ message: "Price is required." }];
    }

    if (values.stock < 0) {
        errors.stock = [{ message: "Stock is required." }];
    }

    if (values.categoryID.id < 1) {
        errors.categoryID = [{ message: "Category is required." }];
    }

    return { values, errors };
};

const onFormSubmit = async ({ valid, values }) => {
    if (!valid) return;

    values.categoryID = values.categoryID.id;
    await productService.create(values, authStore.token);
    router.push("/admin");
    alert("Product Created!");
};
</script>

<template>
    <Form v-slot="$form" :initialValues :resolver @submit="onFormSubmit">
        <div class="grid grid-cols-1 md:grid-cols-2 gap-2 md:gap-8 pb-2">
            <div class="flex flex-col gap-2">
                <FormField v-slot="slot" :form="$form" name="name" label="Name" required>
                    <InputText name="name" type="text" fluid :class="slot.class" />
                </FormField>

                <FormField v-slot="slot" :form="$form" name="description" label="Description" required>
                    <InputText name="description" type="text" fluid :class="slot.class" />
                </FormField>

                <FormField v-slot="slot" :form="$form" name="price" label="Price" required>
                    <InputNumber name="price" :minFractionDigits="2" fluid :inputClass="slot.class" />
                </FormField>
            </div>

            <div class="flex flex-col gap-2">
                <FormField v-slot="slot" :form="$form" name="stock" label="Stock" required>
                    <InputNumber name="stock" fluid :inputClass="slot.class" />
                </FormField>

                <div class="flex gap-1 items-center">
                    <FormField v-slot="slot" :form="$form" name="categoryID" label="Category" required class="flex-1">
                        <Select name="categoryID" :options="categories" optionLabel="name" placeholder="Select a Category" fluid :inputClass="slot.class" class="rounded-sm" />
                    </FormField>
                    <Category />
                </div>

                <FormField v-slot="slot" :form="$form" name="images[0].url" label="Image URL">
                    <InputText name="images[0].url" type="text" fluid :class="slot.class" />
                </FormField>
            </div>
        </div>
        <div class="grid">
            <Button type="submit" label="Continue" severity="contrast" rounded class="px-12 py-2.5 flex md:place-self-end" />
        </div>
    </Form>
</template>

<style scoped></style>
