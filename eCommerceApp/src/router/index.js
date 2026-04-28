import { createRouter, createWebHistory } from 'vue-router';

const router = createRouter({
    history: createWebHistory(import.meta.env.BASE_URL),
    routes: [
        {
            path: "/dashboard",
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

export default router;
