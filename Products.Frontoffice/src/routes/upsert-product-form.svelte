<script lang="ts">
  import {
    ColorToHex,
    COLOR,
    type Product,
    ProductSchema,
    ColorKeys,
  } from "$lib";

  interface Props {
    product: Product;
    onsave?: () => void;
    ondismiss?: () => void;
  }

  let { product = $bindable(), onsave, ondismiss }: Props = $props();

  let validationResult = $derived(ProductSchema.safeParse(product));
  let errors = $derived(
    validationResult.success ? { _errors: [] } : validationResult.error.format(),
  );
  let enableSave = $derived(validationResult.success);
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
      <button type="button" class="btn btn-secondary" onclick={ondismiss}
        >Close</button
      >
      <button
        class="btn btn-primary"
        onclick={onsave}
        disabled={!enableSave}>Save Changes</button
      >
    </div>
  </div>
</form>
