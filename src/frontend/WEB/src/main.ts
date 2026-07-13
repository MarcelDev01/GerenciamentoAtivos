import { createApp } from 'vue'
import PrimeVue from 'primevue/config'
import Aura from '@primevue/themes/aura' // Tema moderno do PrimeVue
import './assets/index.css' // Importa o Tailwind que criamos no Passo 2
import App from './App.vue'
import router from './router'

const app = createApp(App)

// Configura o PrimeVue usando o tema Aura
app.use(PrimeVue, {
    theme: {
        preset: Aura
    }
})

app.use(router)

app.mount('#app')