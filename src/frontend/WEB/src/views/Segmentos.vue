<template>
  <div class="p-6 max-w-7xl mx-auto space-y-6">
    <Toast />

    <div
      class="flex flex-col sm:flex-row sm:items-center sm:justify-between gap-4 bg-white p-6 rounded-xl border border-slate-200 shadow-xs"
    >
      <div>
        <h1 class="text-2xl font-bold text-slate-900 tracking-tight">Gerenciamento de Segmentos</h1>
        <p class="text-sm text-slate-500 mt-1">
          Visualize, crie e gerencie os segmentos cadastrados no sistema.
        </p>
      </div>

      <BaseButton label="Novo Segmento" icon="mdi mdi-plus" @click="openNewSegmento" />
    </div>

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

    <SegmentoDialog
      v-model:visible="modalAberto"
      :segmento-data="segmentoSelecionado"
      :loading="salvandoDados"
      @save="saveSegmento"
    />
  </div>
</template>

<script setup lang="ts">
import { ref, onMounted } from 'vue'
import BaseButton from '../components/BaseButton.vue'
import BaseTable from '../components/BaseTable.vue'
import { segmentoService } from '../services/SegmentoService.ts'
import Badge from 'primevue/badge'
import SegmentoDialog from '../components/Dialog/SegmentoDialog.vue'

import type { SegmentoDto, SegmentoForm } from '../services/SegmentoService.ts'

const lstSegmentos = ref<SegmentoDto[]>([])
const loading = ref(false)
const modalAberto = ref(false)
const segmentoSelecionado = ref<SegmentoDto | null>(null)
const salvandoDados = ref(false)

// Defina quais colunas essa tela precisa mostrar
const colunasSegmentos = [
  { field: 'nome', header: 'Nome' },
  { field: 'ativo', header: 'Status' },
]

const getSegmentos = async () => {
  loading.value = true
  try {
    const result = await segmentoService.getAll()
    lstSegmentos.value = result
  } catch (error) {
    console.error('Erro ao buscar segmentos:', error)
  } finally {
    loading.value = false
  }
}

const openNewSegmento = () => {
  segmentoSelecionado.value = null
  modalAberto.value = true
}

const editar = (item: any) => {
  segmentoSelecionado.value = { ...item }
  modalAberto.value = true
}

const excluir = (item: any) => {
  console.log('Excluir segmento:', item)
}

const saveSegmento = async (dados: SegmentoForm) => {
  salvandoDados.value = true
  try {
    if (dados.id) {
      await segmentoService.update({
        id: dados.id,
        nome: dados.nome,
        ativo: dados.ativo,
      })
    } else {
      await segmentoService.create({
        nome: dados.nome,
      })
    }

    modalAberto.value = false
    await getSegmentos()
  } catch (error) {
    console.error('Erro ao salvar segmento:', error)
  } finally {
    salvandoDados.value = false
  }
}

onMounted(() => {
  getSegmentos()
})
</script>
