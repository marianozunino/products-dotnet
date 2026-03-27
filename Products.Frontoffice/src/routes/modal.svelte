<script lang="ts">
  import type { Snippet } from "svelte";
  import { fade, fly } from "svelte/transition";
  import { quintOut } from "svelte/easing";

  interface Props {
    open: boolean;
    showBackdrop?: boolean;
    onClose?: () => void;
    title?: Snippet;
    body?: Snippet;
  }

  let { open, showBackdrop = true, onClose = () => {}, title, body }: Props = $props();

  const modalClose = () => {
    onClose();
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
          {#if title}
            {@render title()}
          {:else}
            <h5 class="modal-title" id="modalTitle">Default Modal Title</h5>
          {/if}
          <button
            type="button"
            class="btn-close"
            onclick={modalClose}
            aria-label="Close"
          ></button>
        </div>
        <div class="modal-body">
          {@render body?.()}
        </div>
      </div>
    </div>
  </div>
  {#if showBackdrop}
    <div class="modal-backdrop show" transition:fade={{ duration: 150 }}></div>
  {/if}
{/if}

<style>
  .modal {
    display: block;
  }
</style>
