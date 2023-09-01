import type { Product } from "$lib";

import axios from "axios";
import { products } from "./store";

export const deleteProduct = async (id?: number) => {
  await axios.delete<void>(`http://localhost:5192/api/products/${id}`);
  products.remove(id);
};

export const getAllProducts = async () => {
  const { data } = await axios.get("http://localhost:5192/api/products");
  products.set(data);
};

export const updateProduct = async (modalProduct: Product) => {
  const { data: updatedProduct } = await axios.put<Product>(
    `http://localhost:5192/api/products/${modalProduct.id}`,
    modalProduct,
  );
  products.update(updatedProduct);
};

export const createProduct = async (modalProduct: Product) => {
  const { data: createdProduct } = await axios.post<Product>(
    "http://localhost:5192/api/products",
    modalProduct,
  );
  products.append(createdProduct);
};
