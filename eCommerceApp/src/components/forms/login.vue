<script setup>
import { ref, reactive } from "vue";
import { Form } from "@primevue/forms";
import { InputText, Password, Button, Message } from "primevue";
import { validateEmail } from "@/utils/validator.js";
import FormField from "@/components/forms/form-field.vue";
import { useAuthStore } from "@/stores/auth.js";
import { authService } from "@/services/auth.js";
import { apiError } from "@/services/api.js";

const authStore = useAuthStore();
const errorMessage = ref("");
const initialValues = reactive({
    email: "",
    password: ""
});

const resolver = ({ values }) => {
    const errors = {};

    if (!values.email) {
        errors.email = [{ message: "Email is required." }];
    } else if (!validateEmail(values.email)) {
        errors.email = [{ message: "Enter a valid email address." }];
    }

    if (!values.password) {
        errors.password = [{ message: "Password is required." }];
    }

    return { values, errors };
};

const onFormSubmit = async ({ valid, values }) => {
    if (!valid) return;

    try {
        const token = await authService.login(values.email, values.password);
        const user = await authService.fetchUser(token.accessToken);
        authStore.set({ user, token: token.accessToken });
        errorMessage.value = "";
    } catch (error) {
        errorMessage.value = apiError(error, {
            401: "Invalid credentials"
        });
    }
};
</script>

<template>
    <Form v-slot="$form" :initialValues :resolver @submit="onFormSubmit" class="grid gap-4">
        <FormField v-slot="slot" :form="$form" name="email" label="Email" required>
            <InputText name="email" type="text" fluid autocomplete="email" :class="slot.class" />
        </FormField>

        <FormField v-slot="slot" :form="$form" name="password" label="Password" required>
            <Password name="password" fluid toggleMask :feedback="false" pt:pcinputtext:root:autocomplete="current-password" :inputClass="slot.class" />
        </FormField>

        <div class="grid gap-1">
            <Message v-if="errorMessage" severity="error" size="small" variant="simple" class="place-self-center">{{ errorMessage }}</Message>
            <Button type="submit" label="Continue" severity="contrast" rounded fluid class="py-2.5" />
        </div>
    </Form>
</template>

<style scoped></style>
