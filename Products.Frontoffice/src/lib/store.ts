import type { Product } from "$lib";
import { writable } from "svelte/store";

function createProducts() {
  const { subscribe, set, update } = writable<Product[]>([]);

  return {
    subscribe,
    set,
    append: (product: Product) => {
      update((products) => [...products, product]);
    },
    remove: (id?: number) => {
      update((products) => {
        const index = products.findIndex((product) => product.id === id);
        products.splice(index, 1);
        return products;
      });
    },
    update: (modalProduct: Product) => {
      update((products) => {
        const index = products.findIndex(
          (product) => product.id === modalProduct.id,
        );
        products[index] = modalProduct;
        return products;
      });
    },
  };
}

export const products = createProducts();
