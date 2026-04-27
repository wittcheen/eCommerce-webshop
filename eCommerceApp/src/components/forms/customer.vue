<script setup>
import { reactive } from "vue";
import { Form } from "@primevue/forms";
import { Button, InputText } from "primevue";
import { validateEmail } from "@/utils/validator.js";
import FormField from "@/components/forms/form-field.vue";

const emit = defineEmits(["customer"]);

const initialValues = reactive({
    firstName: "",
    lastName: "",
    email: "",
    address: "",
    city: ""
});

const resolver = ({ values }) => {
    const errors = {};

    if (!values.firstName) {
        errors.firstName = [{ message: "First name is required." }];
    }

    if (!values.lastName) {
        errors.lastName = [{ message: "Last name is required." }];
    }

    if (!values.email) {
        errors.email = [{ message: "Email is required." }];
    } else if (!validateEmail(values.email)) {
        errors.email = [{ message: "Enter a valid email address." }];
    }

    if (!values.address) {
        errors.address = [{ message: "Address is required." }];
    }

    if (!values.city) {
        errors.city = [{ message: "City is required." }];
    }

    return { values, errors };
};

const onFormSubmit = async ({ valid, values }) => {
    if (valid) {
        emit("customer", values);
    }
};
</script>

<template>
    <Form v-slot="$form" :initialValues :resolver @submit="onFormSubmit">
        <div class="grid gap-2 pb-2">
            <FormField v-slot="slot" :form="$form" name="firstName" label="First Name" required>
                <InputText name="firstName" type="text" fluid autocomplete="given-name" :class="slot.class" />
            </FormField>

            <FormField v-slot="slot" :form="$form" name="lastName" label="Last Name" required>
                <InputText name="lastName" type="text" fluid autocomplete="family-name" :class="slot.class" />
            </FormField>

            <FormField v-slot="slot" :form="$form" name="email" label="Email" required>
                <InputText name="email" type="text" fluid autocomplete="email" :class="slot.class" />
            </FormField>
        </div>
        <div class="grid grid-cols-2 gap-2 pb-2">
            <FormField v-slot="slot" :form="$form" name="address" label="Address" required>
                <InputText name="address" type="text" fluid autocomplete="street-address" :class="slot.class" />
            </FormField>

            <FormField v-slot="slot" :form="$form" name="city" label="City" required>
                <InputText name="city" type="text" fluid :class="slot.class" />
            </FormField>
        </div>
        <Button type="submit" label="Continue" severity="contrast" rounded fluid class="px-12 py-2.5 flex place-self-end" />
    </Form>
</template>

<style scoped></style>
