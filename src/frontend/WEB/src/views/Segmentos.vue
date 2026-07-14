<template>
  <div class="p-6 max-w-7xl mx-auto space-y-6">
    <!-- Componente global para exibir mensagens de sucesso/erro (Toast) -->
    <Toast />

    <!-- Cabeçalho da Página -->
    <div
      class="flex flex-col sm:flex-row sm:items-center sm:justify-between gap-4 bg-white p-6 rounded-xl border border-slate-200 shadow-xs"
    >
      <div>
        <h1 class="text-2xl font-bold text-slate-900 tracking-tight">Gerenciamento de Segmentos</h1>
        <p class="text-sm text-slate-500 mt-1">
          Visualize, crie e gerencie os segmentos cadastrados no sistema.
        </p>
      </div>

      <BaseButton label="Novo Segmento" icon="mdi mdi-plus" />
    </div>

    <!-- Tabela de Dados (PrimeVue DataTable) -->
    <BaseTable
      :items="lstSegmentos"
      :columns="colunasSegmentos"
      @edit="editar"
      @delete="excluir"
      :hasActions="false"
    >
      <template #col-ativo="{ row }">
        <Badge
          :value="row.ativo ? 'Ativo' : 'Inativo'"
          :severity="row.ativo ? 'success' : 'danger'"
          class="font-semibold px-3 py-1"
        />
      </template>
    </BaseTable>
  </div>
</template>

<script setup lang="ts">
import { ref, onMounted } from 'vue'
//import { useToast } from 'primevue/usetoast'
import BaseButton from '../components/BaseButton.vue'
import BaseTable from '../components/BaseTable.vue'
import { segmentoService, type SegmentoDto } from '../services/SegmentoService.ts'
import Badge from 'primevue/badge'

//const toast = useToast()
const lstSegmentos = ref<SegmentoDto[]>([])
const loading = ref(false)

const getSegmentos = async () => {
  loading.value = true
  try {
    const result = await segmentoService.getAll()
    lstSegmentos.value = result
  } catch (error) {
    console.error('Erro ao buscar segmentos:', error)
    // toast.add({
    //   severity: 'error',
    //   summary: 'Erro',
    //   detail: 'Não foi possível carregar os segmentos.',
    //   life: 3000,
    // })
  } finally {
    loading.value = false
  }
}

// Defina quais colunas essa tela precisa mostrar
const colunasSegmentos = [
  { field: 'nome', header: 'Nome' },
  { field: 'ativo', header: 'Status' },
]

const editar = (item: any) => {
  console.log('Editando segmento:', item)
}
const excluir = (item: any) => {
  console.log('Excluindo segmento:', item)
}

onMounted(() => {
  getSegmentos()
})
</script>
