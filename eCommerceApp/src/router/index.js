import { createRouter, createWebHistory } from 'vue-router';

const router = createRouter({
    history: createWebHistory(import.meta.env.BASE_URL),
    routes: [
        {
            path: "/",
            component: () => import("@/layout/layout.vue"),
            children: [
                {
                    path: "",
                    component: () => import("@/views/Products.vue")
                }
            ]
        }
    ]
});

export default router;
