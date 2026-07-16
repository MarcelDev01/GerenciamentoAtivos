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

      <BaseInputSwitch v-if="isEdit" id="ativo" v-model="form.ativo" label="Ativo Ativo" />
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

const isOpen = ref(false)
const isEdit = ref(false)
const submitted = ref(false)
</script>
