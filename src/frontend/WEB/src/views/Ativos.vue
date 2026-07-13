<template>
  <div class="p-6 max-w-7xl mx-auto space-y-6">
    <!-- Componente global para exibir mensagens de sucesso/erro (Toast) -->
    <Toast />

    <!-- Cabeçalho da Página -->
    <div class="flex flex-col sm:flex-row sm:items-center sm:justify-between gap-4 bg-white p-6 rounded-xl border border-slate-200 shadow-xs">
      <div>
        <h1 class="text-2xl font-bold text-slate-900 tracking-tight">Gerenciamento de Ativos</h1>
        <p class="text-sm text-slate-500 mt-1">Tela de controle de ativos (FIIs, Ações, etc.).</p>
      </div>
      <Button class="bg-blue-600 hover:bg-blue-700 text-white font-medium border-none shadow-sm px-4 py-2 rounded-lg shrink-0 flex items-center gap-2">
        <i class="mdi mdi-plus text-lg"></i>
        <span>Novo Ativo</span>
      </Button>
    </div>

    <!-- Tabela de Dados (PrimeVue DataTable) -->
    <div class="bg-white rounded-xl border border-slate-200 shadow-xs overflow-hidden">
      <DataTable
        :value="[]"
        stripedRows 
        responsiveLayout="scroll"
        class="p-datatable-sm text-sm"
        placeholder="Nenhum ativo encontrado."
      >
        <Column field="nome" header="Nome" sortable class="font-medium text-slate-700"></Column>
        <Column field="codigoFii" header="Qtde. Cotas" class="text-slate-500"></Column>
        <Column field="rendimentoUnitário" header="Rendimento Unitário" class="text-slate-500"></Column>
        <Column field="precoCota" header="Preço Cota" class="text-slate-500"></Column>
        <Column field="valorPatrimonial" header="Valor Patrimonial" class="text-slate-500"></Column>
        <Column field="ativo" header="Status" class="text-slate-500"></Column>
        
        <!-- Coluna de Ações (Editar / Excluir) -->
        <Column header="Ações" class="w-32 text-center" headerClass="text-center">
          <template #body="slotProps">
            <div class="flex items-center justify-center gap-2">
              <Button 
                icon="pi pi-pencil" 
                class="p-button-rounded p-button-text text-amber-600 hover:bg-amber-50! w-8 h-8 p-0" 
              />
              <Button 
                icon="pi pi-trash" 
                class="p-button-rounded p-button-text text-red-600 hover:bg-red-50! w-8 h-8 p-0" 
              />
            </div>
          </template>
        </Column>
      </DataTable>
    </div>
  </div>
</template>