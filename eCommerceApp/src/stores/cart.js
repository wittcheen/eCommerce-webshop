import { defineStore } from 'pinia';
import { ref, computed } from 'vue';

export const useCartStore = defineStore("cart", () => {
    const items = ref([]);
    // sum all item quantities into a single value
    const totalItems = computed(() =>
        items.value.reduce((sum, i) => sum + i.quantity, 0)
    );
    // sum all item quantity prices into a single value
    const totalPrice = computed(() =>
        items.value.reduce((sum, i) => sum + i.quantity * i.price, 0)
    );

    const add = (product, quantity = 1) => {
        const existing = items.value.find(i => i.id === product.id);

        const current = existing ? existing.quantity : 0;
        if (current >= product.stock) return;

        if (existing) {
            existing.quantity += quantity;
        } else {
            items.value.push({ ...product, quantity: quantity });
        }
    };

    const remove = (id) => {
        const item = items.value.find(i => i.id === id);
        if (!item) return;

        if (item.quantity > 1) {
            item.quantity--;
        } else {
            items.value = items.value.filter(i => i.id !== id);
        }
    };

    const clear = () => {
        items.value = [];
    };

    return {
        items,
        totalItems,
        totalPrice,
        add,
        remove,
        clear
    };
});
