<script lang="ts">
  import { fade, fly } from "svelte/transition";
  import { quintOut } from "svelte/easing";

  export let open = false;
  export let showBackdrop = true;

  export let onClose = () => {};

  const modalClose = () => {
    open = false;
    if (onClose) {
      onClose();
    }
  };
</script>

{#if open}
  <div
    class="modal"
    id="sampleModal"
    tabindex="-1"
    role="dialog"
    aria-labelledby="modalTitle"
    aria-hidden={false}
  >
    <div
      class="modal-dialog"
      role="document"
      in:fly={{ y: -50, duration: 300 }}
      out:fly={{ y: -50, duration: 300, easing: quintOut }}
    >
      <div class="modal-content">
        <div class="modal-header">
          <slot name="title">
            <h5 class="modal-title" id="modalTitle">Default Modal Title</h5>
          </slot>
          <button
            type="button"
            class="btn-close"
            on:click={modalClose}
            aria-label="Close"
          ></button>
        </div>
        <div class="modal-body">
          <slot name="body" />
        </div>
      </div>
    </div>
  </div>
  {#if showBackdrop}
    <div class="modal-backdrop show" transition:fade={{ duration: 150 }} />
  {/if}
{/if}

<style>
  .modal {
    display: block;
  }
</style>
