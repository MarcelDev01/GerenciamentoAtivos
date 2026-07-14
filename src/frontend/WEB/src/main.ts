import { createApp } from 'vue'
import PrimeVue from 'primevue/config'
import Aura from '@primevue/themes/aura' // Tema moderno do PrimeVue
import './assets/index.css'
import App from './App.vue'
import router from './router'

const app = createApp(App)

// Configura o PrimeVue usando o tema Aura
app.use(PrimeVue, {
  theme: {
    preset: Aura,
    options: {
      // 🚀 ISSO AQUI É O SEGREDO: Força o PrimeVue a NUNCA usar o modo escuro!
      darkModeSelector: 'none',
    },
  },
})

app.use(router)

app.mount('#app')
