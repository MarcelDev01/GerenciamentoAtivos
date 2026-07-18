<template>
  <div class="p-6 max-w-7xl mx-auto space-y-6">
    <!-- Componente global para exibir mensagens de sucesso/erro (Toast) -->
    <Toast />

    <!-- Cabeçalho da Página -->
    <div
      class="flex flex-col sm:flex-row sm:items-center sm:justify-between gap-4 bg-white p-6 rounded-xl border border-slate-200 shadow-xs"
    >
      <div>
        <h1 class="text-2xl font-bold text-slate-900 tracking-tight">Gerenciamento de Ativos</h1>
        <p class="text-sm text-slate-500 mt-1">Tela de controle de ativos (FIIs, Ações, etc.).</p>
      </div>

      <BaseButton label="Novo Ativo" icon="mdi mdi-plus" size="x-small" @click="openNewAtivo" />
    </div>

    <!-- Tabela de Dados (PrimeVue DataTable) -->
    <BaseTable
      :items="lstAtivos"
      :columns="colunasAtivos"
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

    <AtivoDialog
      v-model:visible="modalAberto"
      :ativo-data="ativoSelecionado"
      :loading="salvandoDados"
      @save="saveAtivo"
    />
  </div>
</template>

<script setup lang="ts">
import { ref, onMounted } from 'vue'
import { ativoService } from '@/services/AtivoService.ts'
import BaseButton from '../components/BaseButton.vue'
import BaseTable from '../components/BaseTable.vue'
import Badge from 'primevue/badge'
import AtivoDialog from '../components/Dialog/AtivoDialog.vue'

import { type AtivoDto, type AtivoForm } from '@/services/AtivoService.ts'

const lstAtivos = ref<AtivoDto[]>([])
const loading = ref(false)
const modalAberto = ref(false)
const ativoSelecionado = ref<AtivoDto | null>(null)
const salvandoDados = ref(false)

const getAtivos = async () => {
  loading.value = true
  try {
    const result = await ativoService.getAll()
    lstAtivos.value = result
  } catch (error) {
    console.error('Erro ao buscar ativos:', error)
  } finally {
    loading.value = false
  }
}

// Defina quais colunas essa tela precisa mostrar
const colunasAtivos = [
  { field: 'codigoFII', header: 'Código FII' },
  { field: 'qtdeCotas', header: 'Qtde. Cotas' },
  { field: 'rendimentoUnitario', header: 'Rendimento Unitário' },
  { field: 'precoCota', header: 'Preço Cota' },
  { field: 'valorPatrimonial', header: 'Valor Patrimonial' },
  { field: 'ativo', header: 'Status' },
]

const openNewAtivo = () => {
  ativoSelecionado.value = null
  modalAberto.value = true
}

const editar = (item: any) => {
  console.log('Editando ativo:', item)
}

const excluir = (item: any) => {
  console.log('Excluindo ativo:', item)
}

const saveAtivo = async (dados: AtivoForm) => {
  salvandoDados.value = true
  try {
    if (dados.id) {
      await ativoService.update({
        id: dados.id,
        segmentoId: dados.segmentoId,
        administradoraId: dados.administradoraId,
        codigoFii: dados.codigoFii,
        qtdeCotas: dados.qtdeCotas,
        rendimentoUnitario: dados.rendimentoUnitario,
        precoCota: dados.precoCota,
        valorPatrimonial: dados.valorPatrimonial,
        ativo: dados.ativo,
      })
    } else {
      await ativoService.create({
        segmentoId: dados.segmentoId,
        administradoraId: dados.administradoraId,
        codigoFii: dados.codigoFii,
        qtdeCotas: dados.qtdeCotas,
        rendimentoUnitario: dados.rendimentoUnitario,
        precoCota: dados.precoCota,
        valorPatrimonial: dados.valorPatrimonial,
      })
    }

    modalAberto.value = false
    await getAtivos()
  } catch (error) {
    console.error('Erro ao salvar ativo:', error)
  } finally {
    salvandoDados.value = false
  }
}

onMounted(() => {
  getAtivos()
})
</script>
