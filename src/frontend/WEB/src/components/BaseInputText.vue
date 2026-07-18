<template>
  <div class="flex flex-col gap-1.5 w-full">
    <!-- Label opcional -->
    <label v-if="label" :for="id" class="text-sm font-semibold text-slate-700">
      {{ label }}
      <span v-if="required" class="text-red-500">*</span>
    </label>

    <!-- InputText do PrimeVue -->
    <InputText
      :id="id"
      v-model="modelValue"
      :placeholder="placeholder"
      :autofocus="autofocus"
      :disabled="disabled"
      class="w-full p-2 border rounded-lg focus:ring-2 focus:ring-blue-500/20 focus:border-blue-500 transition-colors duration-150 outline-hidden"
      :class="[
        error
          ? 'border-red-500! bg-red-50/20 focus:ring-red-500/20 focus:border-red-500!'
          : 'border-slate-200 hover:border-slate-300 focus:border-blue-500',
      ]"
    />

    <!-- Mensagem de erro opcional -->
    <small v-if="error && errorMessage" class="text-red-500 text-xs font-medium">
      {{ errorMessage }}
    </small>
  </div>
</template>

<script setup lang="ts">
import InputText from 'primevue/inputtext'

interface Props {
  id?: string
  label?: string
  placeholder?: string
  required?: boolean
  autofocus?: boolean
  disabled?: boolean
  error?: boolean
  errorMessage?: string
}

withDefaults(defineProps<Props>(), {
  id: () => `input-${Math.random().toString(36).substring(2, 9)}`,
  label: '',
  placeholder: '',
  required: false,
  autofocus: false,
  disabled: false,
  error: false,
  errorMessage: '',
})

// Define o v-model de forma nativa no Vue 3
const modelValue = defineModel<any>()
</script>
