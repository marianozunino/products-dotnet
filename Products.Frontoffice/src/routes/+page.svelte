<script lang="ts">
  import type { Product } from "$lib";
  import { createProduct, getAllProducts, updateProduct } from "$lib/api";
  import Modal from "./modal.svelte";
  import Table from "./table.svelte";
  import ProductForm from "./upsert-product-form.svelte";

  let showPopup = false;
  let product: Product;

  const resetProduct = () => {
    product = {
      name: "",
      brand: "",
    };
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
    showPopup = false;
    closeModal();
  };

  const handleEdit = (event: CustomEvent<Product>) => {
    product = event.detail;
    showPopup = true;
  };
</script>

<h1>Welcome to SvelteKit</h1>
<p>
  Visit <a href="https://kit.svelte.dev">kit.svelte.dev</a> to read the documentation
</p>

{#await getAllProducts()}
  <p>Finding products...</p>
{:then}
  <div class="row justify-content-end m-3">
    <div class="col-auto">
      <button
        type="button"
        class="btn btn-success"
        on:click={() => {
          showPopup = true;
          resetProduct();
        }}
      >
        Add Product
      </button>
    </div>
  </div>
  <Table on:edit={handleEdit} />
  <Modal open={showPopup} onClose={closeModal}>
    <h5 class="modal-title" id="sampleModalLabel" slot="title">
      {product.id ? "Edit Product" : "Add Product"}
    </h5>
    <ProductForm
      {product}
      on:save={upsertProduct}
      on:dismiss={() => closeModal()}
      slot="body"
    />
  </Modal>
{:catch error}
  <p style="color: red">{error.message}</p>
{/await}
