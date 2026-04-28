import { createRouter, createWebHistory } from 'vue-router';
import { useAuthStore } from '@/stores/auth.js';

const router = createRouter({
    history: createWebHistory(import.meta.env.BASE_URL),
    routes: [
        {
            path: "/admin",
            component: () => import("@/views/Dashboard.vue"),
            meta: { requiresAdmin: true }
        },
        {
            path: "/",
            component: () => import("@/layout/layout.vue"),
            children: [
                {
                    path: "",
                    component: () => import("@/views/Products.vue")
                }
            ]
        },
        {
            path: "/checkout",
            component: () => import("@/views/Checkout.vue")
        },
    ]
});

router.beforeEach(async () => {
    const authStore = useAuthStore();
    if (!authStore.isInitialized) {
        await authStore.init();
    }
});

export default router;
