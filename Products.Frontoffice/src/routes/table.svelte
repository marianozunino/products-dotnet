<script lang="ts">
  import { ColorToHex, type Product } from "$lib";

  import { deleteProduct } from "$lib/api";
  import { products } from "$lib/store";

  let { onedit }: { onedit: (product: Product) => void } = $props();

  const editProduct = (product: Product) => {
    if (product) {
      onedit(product);
    }
  };
</script>

<table class="table">
  <thead>
    <tr>
      <th scope="col">ID</th>
      <th scope="col">Name</th>
      <th scope="col">Brand</th>
      <th scope="col">Color</th>
      <th scope="col">Action</th>
    </tr>
  </thead>
  <tbody>
    {#if $products.length === 0}
      <tr>
        <td colspan="5">No products found</td>
      </tr>
    {:else}
      {#each $products as product (product.id)}
        <tr>
          <td>{product.id}</td>
          <td>{product.name}</td>
          <td>{product.brand}</td>
          <td
            style="background-color: {ColorToHex(product.color)};"
            class="text-black">{product.color}</td
          >
          <td>
            <button
              onclick={() => editProduct(product)}
              class="btn btn-primary"
              data-bs-toggle="modal">Edit</button
            >
            <button
              onclick={() => deleteProduct(product.id)}
              class="btn btn-danger">Delete</button
            >
          </td>
        </tr>
      {/each}
    {/if}
  </tbody>
</table>
