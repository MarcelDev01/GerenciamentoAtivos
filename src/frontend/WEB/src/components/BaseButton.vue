<template>
  <Button
    :class="[
      'font-medium !border-none !outline-hidden shadow-xs shrink-0 flex items-center justify-center gap-2 transition-colors duration-200',
      props.severity === 'primary' ? '!bg-blue-600 hover:!bg-blue-700 !text-white' : '',
      props.severity === 'secondary' ? '!bg-slate-100 hover:!bg-slate-200 !text-slate-700' : '',
      props.severity === 'danger' ? '!bg-red-600 hover:!bg-red-700 !text-white' : '',
      props.severity === 'warning' ? '!bg-amber-500 hover:!bg-amber-600 !text-white' : '',
      props.severity === 'success' ? '!bg-green-500 hover:!bg-green-600 !text-white' : '',
      customClass,
      getSizeClass,
    ]"
    :disabled="loading || disabled"
    v-bind="$attrs"
  >
    <i v-if="loading" :class="['mdi mdi-loading mdi-spin', getIconSizeClass]"></i>

    <i v-if="icon && iconPosition === 'left' && !loading" :class="[icon, getIconSizeClass]"></i>

    <span v-if="label">{{ label }}</span>

    <i v-if="icon && iconPosition === 'right' && !loading" :class="[icon, getIconSizeClass]"></i>
  </Button>
</template>

<script setup lang="ts">
import Button from 'primevue/button'
import { computed } from 'vue'

interface Props {
  label?: string
  icon?: string
  iconPosition?: 'left' | 'right'
  severity?: 'primary' | 'secondary' | 'danger' | 'warning' | 'success'
  size?: 'x-small' | 'small' | 'default' | 'large' | 'x-large'
  loading?: boolean
  disabled?: boolean
  customClass?: string
}

const props = withDefaults(defineProps<Props>(), {
  label: '',
  icon: '',
  iconPosition: 'left',
  severity: 'primary',
  size: 'default',
  loading: false,
  disabled: false,
  customClass: '',
})

const getSizeClass = computed(() => {
  const sizes = {
    'x-small': 'px-2 py-1 text-xs rounded-md',
    small: 'px-3 py-1.5 text-sm rounded-md',
    default: 'px-4 py-2.5 text-sm rounded-lg',
    large: 'px-5 py-3 text-base rounded-lg',
    'x-large': 'px-6 py-4 text-lg rounded-xl',
  }
  return sizes[props.size] || sizes.default
})

const getIconSizeClass = computed(() => {
  const iconSizes = {
    'x-small': 'text-sm',
    small: 'text-base',
    default: 'text-lg',
    large: 'text-xl',
    'x-large': 'text-2xl',
  }
  return iconSizes[props.size] || iconSizes.default
})
</script>
