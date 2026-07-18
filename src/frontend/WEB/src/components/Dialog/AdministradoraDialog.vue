<template>
  <Dialog
    v-model:visible="isOpen"
    :header="isEdit ? 'Editar Administradora' : 'Nova Administradora'"
    :modal="true"
    :draggable="false"
    class="w-full max-w-md mx-4"
    @hide="onClose"
  >
    <div class="flex flex-col gap-4 pt-2">
      <BaseInputText
        id="nomeFantasia"
        label="Nome Fantasia"
        v-model="form.nomeFantasia"
        placeholder="Nome Fantasia"
        :required="true"
        :autofocus="true"
        :error="submitted && !form.nomeFantasia"
        error-message="O Campo Nome Fantasia é Obrigatório."
      />

      <BaseInputText
        id="cnpjEmpresa"
        label="Empresa"
        v-model="form.cnpjEmpresa"
        placeholder="Empresa"
        :required="true"
        :autofocus="true"
        :error="submitted && !form.cnpjEmpresa"
        error-message="O Campo Empresa é Obrigatório."
      />

      <BaseInputText
        id="cnpjDono"
        label="CNPJ"
        v-model="form.cnpjDono"
        placeholder="CNPJ"
        :required="true"
        :autofocus="true"
        :error="submitted && !form.cnpjDono"
        error-message="O Campo CNPJ é Obrigatório."
      />

      <BaseInputSwitch v-if="isEdit" id="ativo" v-model="form.ativo" label="Administradora Ativa" />
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
          :label="isEdit ? 'Salvar Alterações' : 'Cadastrar'"
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
import BaseInputText from '../BaseInputText.vue'
import BaseInputSwitch from '../BaseInputSwitch.vue'
import { type AdministradoraForm } from '@/services/AdministradoraService.ts'

interface Props {
  visible: boolean
  administradoraData?: AdministradoraForm | null
  loading?: boolean
}

const props = withDefaults(defineProps<Props>(), {
  visible: false,
  administradoraData: null,
  loading: false,
})

const emit = defineEmits<{
  (e: 'update:visible', value: boolean): void
  (e: 'save', data: AdministradoraForm): void
}>()

const isOpen = ref(false)
const isEdit = ref(false)
const submitted = ref(false)

const form = ref<AdministradoraForm>({
  id: null,
  nomeFantasia: '',
  cnpjEmpresa: '',
  cnpjDono: '',
  ativo: true,
})

watch(
  () => props.visible,
  (newVal) => {
    isOpen.value = newVal
    if (newVal) {
      submitted.value = false
      if (props.administradoraData) {
        form.value = {
          id: props.administradoraData.id,
          nomeFantasia: props.administradoraData.nomeFantasia,
          cnpjEmpresa: props.administradoraData.cnpjEmpresa,
          cnpjDono: props.administradoraData.cnpjDono,
          ativo: props.administradoraData.ativo,
        }
        isEdit.value = true
      } else {
        form.value = {
          id: null,
          nomeFantasia: '',
          cnpjEmpresa: '',
          cnpjDono: '',
          ativo: true,
        }
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
  if (!form.value.nomeFantasia || !form.value.cnpjEmpresa || !form.value.cnpjDono) {
    return
  }
  emit('save', { ...form.value })
}
</script>
