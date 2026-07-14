<template>
  <Button
    :class="[
      'font-medium border-none shadow-xs px-4 py-2.5 rounded-lg shrink-0 flex items-center justify-center gap-2 transition-colors duration-200',
      // Cores dinâmicas baseadas na Prop 'severity'
      severity === 'primary' ? 'bg-blue-600 hover:bg-blue-700 text-white' : '',
      severity === 'secondary' ? 'bg-slate-100 hover:bg-slate-200 text-slate-700' : '',
      severity === 'danger' ? 'bg-red-600 hover:bg-red-700 text-white' : '',
      severity === 'warning' ? 'bg-amber-500 hover:bg-amber-600 text-white' : '',
      // Se passar classes customizadas na chamada, elas se somam aqui
      customClass,
    ]"
    :disabled="loading || disabled"
    v-bind="$attrs"
  >
    <i v-if="loading" class="mdi mdi-loading mdi-spin text-lg"></i>

    <i v-if="icon && iconPosition === 'left' && !loading" :class="[icon, 'text-lg']"></i>

    <span v-if="label">{{ label }}</span>

    <i v-if="icon && iconPosition === 'right' && !loading" :class="[icon, 'text-lg']"></i>
  </Button>
</template>

<script setup lang="ts">
import Button from 'primevue/button'

// Definição das propriedades (Props) que o botão vai aceitar
interface Props {
  label?: string // Texto do botão
  icon?: string // Classe do ícone (ex: 'mdi mdi-plus')
  iconPosition?: 'left' | 'right' // Posição do ícone
  severity?: 'primary' | 'secondary' | 'danger' | 'warning' // Estilo visual predefinido
  loading?: boolean // Estado de carregamento (mostra spinner)
  disabled?: boolean // Desabilitar o botão
  customClass?: string // Classes CSS extras do Tailwind
}

// Valores padrão (Defaults) para quando as props não forem passadas
withDefaults(defineProps<Props>(), {
  label: '',
  icon: '',
  iconPosition: 'left',
  severity: 'primary',
  loading: false,
  disabled: false,
  customClass: '',
})
</script>
