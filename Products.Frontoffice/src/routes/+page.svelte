<script lang="ts">
  import type { Product } from "$lib";
  import { createProduct, getAllProducts, updateProduct } from "$lib/api";
  import Modal from "./modal.svelte";
  import Table from "./table.svelte";
  import ProductForm from "./upsert-product-form.svelte";

  let showPopup = $state(false);
  let product = $state<Product>({ name: "", brand: "" });

  const resetProduct = () => {
    product = { name: "", brand: "" };
  };

  const closeModal = () => {
    showPopup = false;
  };

  const upsertProduct = async () => {
    if (product.id) {
      updateProduct(product);
    } else {
      createProduct(product);
    }
    closeModal();
  };

  const handleEdit = (p: Product) => {
    product = p;
    showPopup = true;
  };
</script>

<h1>Welcome to SvelteKit</h1>
<p>
  Visit <a href="https://svelte.dev/docs/kit">svelte.dev/docs/kit</a> to read the documentation
</p>

{#await getAllProducts()}
  <p>Finding products...</p>
{:then}
  <div class="row justify-content-end m-3">
    <div class="col-auto">
      <button
        type="button"
        class="btn btn-success"
        onclick={() => {
          showPopup = true;
          resetProduct();
        }}
      >
        Add Product
      </button>
    </div>
  </div>
  <Table onedit={handleEdit} />
  <Modal open={showPopup} onClose={closeModal}>
    {#snippet title()}
      <h5 class="modal-title" id="sampleModalLabel">
        {product.id ? "Edit Product" : "Add Product"}
      </h5>
    {/snippet}
    {#snippet body()}
      <ProductForm bind:product onsave={upsertProduct} ondismiss={closeModal} />
    {/snippet}
  </Modal>
{:catch error}
  <p style="color: red">{error.message}</p>
{/await}
