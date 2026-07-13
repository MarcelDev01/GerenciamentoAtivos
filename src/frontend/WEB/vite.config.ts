import { defineConfig } from 'vite'
import vue from '@vitejs/plugin-vue'
import tailwindcss from '@tailwindcss/vite' // <-- Importe aqui

export default defineConfig({
  plugins: [
    vue(),
    tailwindcss() // <-- Adicione aqui nos plugins
  ],
})