<template>
  <div class="flex flex-col gap-1.5 w-full text-left">
    <label v-if="label" class="text-sm font-medium text-slate-700">
      {{ label }}
    </label>

    <Select
      :model-value="modelValue"
      @update:model-value="emit('update:modelValue', $event)"
      :options="options"
      :option-label="optionLabel"
      :option-value="optionValue"
      :placeholder="placeholder"
      :disabled="disabled"
      :loading="loading"
      :filter="filter"
      filter-placeholder="Pesquisar..."
      :class="[
        'w-full !border !border-slate-300 !bg-white !rounded-lg !shadow-xs transition-colors duration-200',
        '!outline-hidden focus-within:!ring-2 focus-within:!ring-blue-500/20 focus-within:!border-blue-500',
        disabled ? 'opacity-50 cursor-not-allowed bg-slate-50' : '',
        customClass,
      ]"
      v-bind="$attrs"
    />
  </div>
</template>

<script setup lang="ts">
import Select from 'primevue/select'

interface Props {
  modelValue: any
  label?: string
  options: any[]
  optionLabel?: string // Qual propriedade exibir textualmente (padrão: 'nome')
  optionValue?: string // Qual propriedade capturar como valor (padrão: 'id')
  placeholder?: string
  disabled?: boolean
  loading?: boolean
  filter?: boolean
  customClass?: string
}

const props = withDefaults(defineProps<Props>(), {
  label: '',
  optionLabel: 'nome', // Se seus DTOs usam 'nome', já fica automático
  optionValue: 'id', // Captura apenas o ID para o DTO pai
  placeholder: 'Selecione...',
  disabled: false,
  loading: false,
  filter: true,
  customClass: '',
})

const emit = defineEmits<{
  (e: 'update:modelValue', value: any): void
}>()
</script>
