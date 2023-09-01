<script lang="ts">
  import {
    ColorToHex,
    COLOR,
    type Product,
    ProductSchema,
    ColorKeys,
  } from "$lib";
  import { createEventDispatcher } from "svelte";
  import type { ZodFormattedError } from "zod";

  const dispatchSave = createEventDispatcher<{ save: Product }>();
  const dispatchDismiss = createEventDispatcher<{ dismiss: void }>();

  const saveProduct = (product: Product) => {
    if (product) {
      dispatchSave("save", product);
    }
  };

  const dismissForm = () => {
    dispatchDismiss("dismiss");
  };

  export let product: Product;

  let errors: ZodFormattedError<Product> = {
    _errors: [],
  };

  let enableSave = false;

  $: {
    enableSave = isValidateProduct(product);
  }

  const isValidateProduct = (product: Product): boolean => {
    const result = ProductSchema.safeParse(product);
    if (result.success) {
      errors = {
        _errors: [],
      };
      return true;
    } else {
      errors = result.error.format();
      return false;
    }
  };
</script>

<form>
  {#if product.id}
    <div class="mb-3">
      <label for="id" class="form-label">Id</label>
      <input
        type="text"
        class="form-control"
        id="id"
        disabled
        readonly
        bind:value={product.id}
      />
    </div>
  {/if}
  <div class="mb-3">
    <label for="name" class="form-label">Name</label>
    <input
      type="text"
      class="form-control"
      id="name"
      placeholder="Enter name"
      bind:value={product.name}
    />
    {#if errors.name}
      <small class="form-text text-danger">{errors.name._errors}</small>
    {/if}
  </div>
  <div class="mb-3">
    <label for="brand" class="form-label">Brand</label>
    <input
      type="text"
      class="form-control"
      id="brand"
      placeholder="Enter brand"
      bind:value={product.brand}
    />
    {#if errors.brand}
      <small class="form-text text-danger">{errors.brand._errors}</small>
    {/if}
  </div>
  <div class="mb-3">
    <label for="color" class="form-label">Color</label>
    <select
      class="form-select"
      id="color"
      bind:value={product.color}
      required
      style="background-color: {ColorToHex(product.color)};"
    >
      <option value="">Select color</option>
      {#each ColorKeys as color}
        <option value={color}>{color}</option>
      {/each}
    </select>
    {#if errors.color}
      <small class="form-text text-danger">{errors.color._errors}</small>
    {/if}
  </div>
  <div class="row justify-content-end modal-footer">
    <div class="col-auto">
      <button type="button" class="btn btn-secondary" on:click={dismissForm}
        >Close</button
      >
      <button
        class="btn btn-primary"
        on:click={() => saveProduct(product)}
        disabled={!enableSave}>Save Changes</button
      >
    </div>
  </div>
</form>
