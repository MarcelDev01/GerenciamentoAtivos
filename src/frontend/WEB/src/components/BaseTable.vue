<template>
  <div class="bg-white rounded-xl border border-slate-200 shadow-xs overflow-hidden">
    <DataTable
      :value="items"
      stripedRows
      responsiveLayout="scroll"
      class="p-datatable-sm text-sm"
      :loading="loading"
      :rows="rows"
      :paginator="items.length > rows"
      paginatorTemplate="FirstPageLink PrevPageLink PageLinks NextPageLink LastPageLink CurrentPageReport"
      currentPageReportTemplate="Exibindo {first} a {last} de {totalRecords}"
      :pt="{
        thead: { class: 'bg-slate-50 border-b border-slate-200' },
        headerRow: { class: 'bg-slate-50' },
      }"
    >
      <template #empty>
        <div class="p-8 text-center text-slate-500 bg-white">
          <i class="mdi mdi-database-outline text-3xl block mb-2 text-slate-300"></i>
          {{ emptyMessage }}
        </div>
      </template>

      <Column
        v-for="col in columns"
        :key="col.field"
        :field="col.field"
        :header="col.header.toUpperCase()"
        :sortable="col.sortable"
        :pt="{
          headerCell: {
            class: 'bg-slate-50 border-b border-slate-200 text-slate-700 py-3.5 font-semibold',
          },
          columnHeaderContent: { class: 'justify-center text-center' },
          bodyCell: {
            class:
              'text-center! justify-center text-slate-700 py-3.5 bg-white border-b border-slate-100',
          },
        }"
      >
        <template #body="slotProps">
          <slot :name="`col-${col.field}`" :row="slotProps.data">
            {{ slotProps.data[col.field] }}
          </slot>
        </template>
      </Column>

      <Column
        v-if="hasActions"
        header="AÇÕES"
        class="w-32"
        :pt="{
          headerCell: {
            class: 'bg-slate-50 border-b border-slate-200 text-slate-700 py-3.5 font-semibold',
          },
          columnHeaderContent: { class: 'justify-center text-center' },
          bodyCell: {
            class: 'text-center! justify-center py-3.5 bg-white border-b border-slate-100',
          },
        }"
      >
        <template #body="slotProps">
          <div class="flex items-center justify-center gap-1.5">
            <slot name="actions" :row="slotProps.data">
              <Button
                icon="pi pi-pencil"
                class="p-button-rounded p-button-text text-amber-600 hover:bg-amber-50! w-8 h-8 p-0"
                @click="$emit('edit', slotProps.data)"
              />
              <Button
                icon="pi pi-trash"
                class="p-button-rounded p-button-text text-red-600 hover:bg-red-50! w-8 h-8 p-0"
                @click="$emit('delete', slotProps.data)"
              />
            </slot>
          </div>
        </template>
      </Column>
    </DataTable>
  </div>
</template>

<script setup lang="ts">
import DataTable from 'primevue/datatable'
import Column from 'primevue/column'
import Button from 'primevue/button'

interface TableColumn {
  field: string
  header: string
  sortable?: boolean
}

interface Props {
  items: any[]
  columns: TableColumn[]
  loading?: boolean
  hasActions?: boolean
  rows?: number
  emptyMessage?: string
}

withDefaults(defineProps<Props>(), {
  items: () => [],
  columns: () => [],
  loading: false,
  hasActions: true,
  rows: 10,
  emptyMessage: 'Nenhum registro encontrado.',
})

defineEmits<{
  (e: 'edit', item: any): void
  (e: 'delete', item: any): void
}>()
</script>
