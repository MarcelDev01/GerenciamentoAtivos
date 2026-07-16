<template>
  <div class="p-6 max-w-7xl mx-auto space-y-6">
    <!-- Componente global para exibir mensagens de sucesso/erro (Toast) -->
    <Toast />

    <!-- Cabeçalho da Página -->
    <div
      class="flex flex-col sm:flex-row sm:items-center sm:justify-between gap-4 bg-white p-6 rounded-xl border border-slate-200 shadow-xs"
    >
      <div>
        <h1 class="text-2xl font-bold text-slate-900 tracking-tight">
          Gerenciamento de Administradoras
        </h1>
        <p class="text-sm text-slate-500 mt-1">Tela de controle das administradoras de fundos.</p>
      </div>

      <BaseButton label="Nova Administradora" icon="mdi mdi-plus" size="x-small" />
    </div>

    <!-- Tabela de Dados (PrimeVue DataTable) -->
    <BaseTable
      :items="lstAdministradoras"
      :columns="colunasAdministradoras"
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
import { administradoraService, type AdministradoraDto } from '../services/Administradora.ts'
import Badge from 'primevue/badge'

//const toast = useToast()
const lstAdministradoras = ref<AdministradoraDto[]>([])
const loading = ref(false)

const getAdministradoras = async () => {
  loading.value = true
  try {
    const result = await administradoraService.getAll()
    lstAdministradoras.value = result
    console.log(lstAdministradoras.value)
  } catch (error) {
    console.error('Erro ao buscar administradoras:', error)
    // toast.add({
    //   severity: 'error',
    //   summary: 'Erro',
    //   detail: 'Não foi possível carregar as administradoras.',
    //   life: 3000,
    // })
  } finally {
    loading.value = false
  }
}

// Defina quais colunas essa tela precisa mostrar
const colunasAdministradoras = [
  { field: 'nomeFantasia', header: 'Nome Fantasia' },
  { field: 'cnpjEmpresa', header: 'CNPJ Empresa' },
  { field: 'cnpjFundo', header: 'CNPJ Dono' },
  { field: 'ativo', header: 'Status' },
]

const editar = (item: any) => {
  console.log('Editando administradora:', item)
}
const excluir = (item: any) => {
  console.log('Excluindo administradora:', item)
}

onMounted(() => {
  getAdministradoras()
})
</script>
