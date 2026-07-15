<template>
  <div
    class="flex items-center gap-3 bg-slate-50 p-3 rounded-lg border border-slate-100 transition-colors hover:bg-slate-100/50 cursor-pointer select-none w-full"
    @click="toggleValue"
  >
    <!-- Componente do PrimeVue -->
    <!-- Nota: No PrimeVue v4, o componente chama-se ToggleSwitch. Se estiver na v3 ou usando compatibilidade, use InputSwitch. -->
    <ToggleSwitch :id="id" v-model="modelValue" :disabled="disabled" @click.stop />

    <!-- Label descritiva -->
    <label
      v-if="label"
      :for="id"
      class="text-sm font-medium text-slate-700 cursor-pointer"
      @click.prevent
    >
      {{ label }}
    </label>
  </div>
</template>

<script setup lang="ts">
// Importação para PrimeVue v4 (ToggleSwitch). Caso use v3, troque para InputSwitch.
import ToggleSwitch from 'primevue/toggleswitch'

interface Props {
  id?: string
  label?: string
  disabled?: boolean
}

const props = withDefaults(defineProps<Props>(), {
  id: () => `switch-${Math.random().toString(36).substring(2, 9)}`,
  label: '',
  disabled: false,
})

const modelValue = defineModel<boolean>({ default: true })

// Permite ligar/desligar ao clicar em qualquer lugar da caixinha (div pai)
const toggleValue = () => {
  if (!props.disabled) {
    modelValue.value = !modelValue.value
  }
}
</script>
