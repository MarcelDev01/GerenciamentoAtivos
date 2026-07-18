<template>
  <Dialog
    v-model:visible="isOpen"
    :header="isEdit ? 'Editar Ativo' : 'Novo Ativo'"
    :modal="true"
    :draggable="false"
    class="w-full max-w-md mx-4"
    @hide="onClose"
  >
    <div class="flex flex-col gap-4 pt-2">
      <BaseSelect
        v-model="form.segmentoId"
        label="Segmento"
        placeholder="Selecione o segmento..."
        :options="listaSegmentos"
        option-label="nome"
        option-value="id"
      />

      <BaseSelect
        v-model="form.administradoraId"
        label="Administradora"
        placeholder="Selecione a administradora..."
        :options="listaAdministradoras"
        option-label="nome"
        option-value="id"
      />

      <BaseInputText
        id="codigoFii"
        v-model="form.codigoFii"
        label="Código FII"
        :required="true"
        :autofocus="true"
        :error="submitted && !form.codigoFii"
        error-message="O Campo Código FII é Obrigatório."
      />

      <BaseInputText
        id="qtdeCotas"
        v-model="form.qtdeCotas"
        label="Quantidade de Cotas"
        :required="true"
        :autofocus="true"
        :error="submitted && !form.qtdeCotas"
        error-message="O Campo Quantidade de Cotas é Obrigatório."
      />

      <BaseInputText
        id="rendimentoUnitario"
        v-model="form.rendimentoUnitario"
        label="Rendimento Unitário"
        :required="true"
        :autofocus="true"
        :error="submitted && !form.rendimentoUnitario"
        error-message="O Campo Rendimento Unitário é Obrigatório."
      />

      <BaseInputText
        id="precoCota"
        v-model="form.precoCota"
        label="Preço da Cota"
        :required="true"
        :autofocus="true"
        :error="submitted && !form.precoCota"
        error-message="O Campo Preço da Cota é Obrigatório."
      />

      <BaseInputText
        id="valorPatrimonial"
        v-model="form.valorPatrimonial"
        label="Valor Patrimonial"
        :required="true"
        :autofocus="true"
        :error="submitted && !form.valorPatrimonial"
        error-message="O Campo Valor Patrimonial é Obrigatório."
      />

      <BaseInputSwitch v-if="isEdit" id="ativo" v-model="form.ativo" label="Ativo" />
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
import { ref, watch, onMounted } from 'vue'
import Dialog from 'primevue/dialog'
import BaseButton from '../BaseButton.vue'
import BaseInputText from '../BaseInputText.vue'
import BaseInputSwitch from '../BaseInputSwitch.vue'
import BaseSelect from '../BaseSelect.vue'
import { type AtivoForm } from '@/services/AtivoService.ts'

import { lookupService, type LookupDto } from '@/services/LookupService.ts'

interface Props {
  visible: boolean
  ativoForm?: AtivoForm | null
  loading?: boolean
}

const props = withDefaults(defineProps<Props>(), {
  visible: false,
  ativoForm: null,
  loading: false,
})

const emit = defineEmits<{
  (e: 'update:visible', value: boolean): void
  (e: 'save', data: AtivoForm): void
}>()

const isOpen = ref(false)
const isEdit = ref(false)
const submitted = ref(false)
const listaSegmentos = ref<LookupDto[]>([])
const listaAdministradoras = ref<LookupDto[]>([])
const loadingSelects = ref(false)

const form = ref<AtivoForm>({
  id: null,
  segmentoId: '',
  administradoraId: '',
  codigoFii: '',
  qtdeCotas: 0,
  rendimentoUnitario: 0,
  precoCota: 0,
  valorPatrimonial: 0,
  ativo: true,
})

watch(
  () => props.visible,
  (newVal) => {
    isOpen.value = newVal
    if (newVal) {
      submitted.value = false
      if (props.ativoForm) {
        form.value = {
          id: props.ativoForm.id,
          segmentoId: props.ativoForm.segmentoId,
          administradoraId: props.ativoForm.administradoraId,
          codigoFii: props.ativoForm.codigoFii,
          qtdeCotas: props.ativoForm.qtdeCotas,
          rendimentoUnitario: props.ativoForm.rendimentoUnitario,
          precoCota: props.ativoForm.precoCota,
          valorPatrimonial: props.ativoForm.valorPatrimonial,
          ativo: props.ativoForm.ativo,
        }
        isEdit.value = true
      } else {
        form.value = {
          id: null,
          segmentoId: '',
          administradoraId: '',
          codigoFii: '',
          qtdeCotas: 0,
          rendimentoUnitario: 0,
          precoCota: 0,
          valorPatrimonial: 0,
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
  if (
    !form.value.segmentoId ||
    !form.value.administradoraId ||
    !form.value.codigoFii ||
    !form.value.qtdeCotas ||
    !form.value.rendimentoUnitario ||
    !form.value.precoCota ||
    !form.value.valorPatrimonial
  ) {
    return
  }
  emit('save', { ...form.value })
}

const carregarDropdowns = async () => {
  try {
    loadingSelects.value = true

    const [segmentos, administradoras] = await Promise.all([
      lookupService.getSegmentosLookup(),
      lookupService.getAdministradorasLookup(),
    ])

    listaSegmentos.value = segmentos
    listaAdministradoras.value = administradoras
  } catch (error) {
    console.error('Erro ao carregar listagens do formulário:', error)
  } finally {
    loadingSelects.value = false
  }
}

onMounted(async () => {
  await carregarDropdowns()
})
</script>
