import { createApp } from 'vue';
import App from './App.vue';
import router from './router';
import { createPinia } from 'pinia';

import PrimeVue from 'primevue/config';
import Aura from '@/assets/theme.js';

import './assets/styles.css';

const app = createApp(App);
app.use(router);
app.use(createPinia());

app.use(PrimeVue, {
    theme: {
        preset: Aura,
        options: {
            darkModeSelector: false,
            cssLayer: {
                name: "primevue",
                order: "theme, base, primevue"
            }
        }
    }
});

app.mount("#app");
