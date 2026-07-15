<template>
  <Dialog
    v-model:visible="isOpen"
    :header="isEdit ? 'Editar Segmento' : 'Novo Segmento'"
    :modal="true"
    :draggable="false"
    class="w-full max-w-md mx-4"
    @hide="onClose"
  >
    <div class="flex flex-col gap-4 pt-2">
      <BaseInputText
        id="nome"
        v-model="form.nome"
        label="Nome"
        placeholder="Ex: Fundos Imobiliários"
        :required="true"
        :autofocus="true"
        :error="submitted && !form.nome"
        error-message="O campo Nome é obrigatório."
      />

      <BaseInputSwitch v-if="isEdit" id="ativo" v-model="form.ativo" label="Segmento Ativo" />
    </div>

    <template #footer>
      <div class="flex items-center justify-end gap-2 mt-4">
        <BaseButton
          label="Cancelar"
          icon="mdi mdi-close"
          variant="text"
          class="text-slate-500 hover:bg-slate-100! font-semibold"
          @click="onClose"
        />
        <BaseButton
          :label="isEdit ? 'Salvar Alterações' : 'Cadastrar'"
          icon="mdi mdi-check"
          :loading="loading"
          @click="handleSave"
        />
      </div>
    </template>
  </Dialog>
</template>

<script setup lang="ts">
import { ref, watch } from 'vue'
import Dialog from 'primevue/dialog'
import BaseButton from '../BaseButton.vue'
import BaseInputText from '../BaseInputText.vue'
import BaseInputSwitch from '../BaseInputSwitch.vue'
import { type SegmentoForm } from '@/services/SegmentoService.ts'

interface Props {
  visible: boolean
  segmentoData?: SegmentoForm | null
  loading?: boolean
}

const props = withDefaults(defineProps<Props>(), {
  visible: false,
  segmentoData: null,
  loading: false,
})

const emit = defineEmits<{
  (e: 'update:visible', value: boolean): void
  (e: 'save', data: SegmentoForm): void
}>()

const isOpen = ref(false)
const isEdit = ref(false)
const submitted = ref(false)

const form = ref<SegmentoForm>({
  id: null,
  nome: '',
  ativo: true,
})

watch(
  () => props.visible,
  (newVal) => {
    isOpen.value = newVal
    if (newVal) {
      submitted.value = false
      if (props.segmentoData) {
        form.value = {
          id: props.segmentoData.id,
          nome: props.segmentoData.nome,
          ativo: props.segmentoData.ativo,
        }
        isEdit.value = true
      } else {
        form.value = { id: null, nome: '', ativo: true }
        isEdit.value = false
      }
    }
  },
)

watch(isOpen, (newVal) => {
  emit('update:visible', newVal)
})

const onClose = () => {
  isOpen.value = false
}

const handleSave = () => {
  submitted.value = true
  if (!form.value.nome) {
    return
  }
  emit('save', { ...form.value })
}
</script>
