<template>
  <Dialog
    v-model:visible="isOpen"
    header="Atenção!"
    :modal="true"
    :draggable="false"
    class="w-full max-w-md mx-4"
    @hide="onClose"
  >
    <div class="flex flex-col gap-4 pt-2">
      <p>
        Deseja confirmar a exclusão do registro, após a confirmação não será possível reverter a
        alteração.
      </p>
    </div>

    <template #footer>
      <div class="flex items-center justify-end gap-2 mt-4">
        <BaseButton
          label="Cancelar"
          icon="mdi mdi-close"
          @click="onClose"
          severity="danger"
          size="x-small"
        />
        <BaseButton
          label="Confirmar"
          icon="mdi mdi-check"
          @click="handleSave"
          severity="success"
          size="x-small"
        />
      </div>
    </template>
  </Dialog>
</template>

<script setup lang="ts">
import { ref, watch } from 'vue'
import Dialog from 'primevue/dialog'
import BaseButton from '../BaseButton.vue'

interface Props {
  visible: boolean
  loading?: boolean
}

const props = withDefaults(defineProps<Props>(), {
  visible: false,
  loading: false,
})

const isOpen = ref(false)

const emit = defineEmits<{
  (e: 'update:visible', value: boolean): void
  (e: 'save', value: boolean): void
}>()

watch(
  () => props.visible,
  (newVal) => {
    isOpen.value = newVal
  },
)

watch(isOpen, (newVal) => {
  emit('update:visible', newVal)
})

const onClose = () => {
  isOpen.value = false
}

const handleSave = () => {
  isOpen.value = false
  emit('save', true)
}
</script>
