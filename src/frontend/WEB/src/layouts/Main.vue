<template>
  <div class="min-h-screen flex flex-row">
    <aside class="w-64 bg-slate-900 text-slate-200 flex flex-col p-4 border-r border-slate-800">
      <div class="text-xl font-bold text-white mb-8 px-2 flex items-center gap-2">
        <span>💼 Investimentos</span>
      </div>
      
      <nav class="flex-1 flex flex-col gap-1">
        <RouterLink 
          to="/segmentos" 
          class="flex items-center gap-2 px-3 py-2.5 rounded-lg hover:bg-slate-800 text-slate-300 hover:text-white transition-colors"
          active-class="bg-blue-600! text-white!"
        >
          📁 Segmentos
        </RouterLink>

        <RouterLink 
          to="/ativos" 
          class="flex items-center gap-2 px-3 py-2.5 rounded-lg hover:bg-slate-800 text-slate-300 hover:text-white transition-colors"
          active-class="bg-blue-600! text-white!"
        >
          📈 Ativos
        </RouterLink>

        <RouterLink 
          to="/administradoras" 
          class="flex items-center gap-2 px-3 py-2.5 rounded-lg hover:bg-slate-800 text-slate-300 hover:text-white transition-colors"
          active-class="bg-blue-600! text-white!"
        >
          🏢 Administradoras
        </RouterLink>
      </nav>
    </aside>

    <main class="flex-1 bg-slate-50 flex flex-col">
      <header class="h-16 bg-white border-b border-slate-200 flex items-center px-6 justify-between">
        <span class="text-sm font-medium text-slate-500">Dashboard / Sistema</span>
        <div class="w-8 h-8 rounded-full bg-slate-300 flex items-center justify-center font-bold text-sm text-slate-700">D</div>
      </header>

      <div class="flex-1">
        <RouterView />
      </div>
    </main>
  </div>
</template>