import { createRouter, createWebHistory } from 'vue-router'
import MainLayout from '../layouts/Main.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      component: MainLayout,
      redirect: '/segmentos', // Ao abrir o sistema, manda direto para segmentos por enquanto
      children: [
        {
          path: 'segmentos',
          name: 'segmentos',
          component: () => import('../views/Segmentos.vue')
        },
        {
          path: 'ativos',
          name: 'ativos',
          component: () => import('../views/Ativos.vue')
        },
        {
          path: 'administradoras',
          name: 'administradoras',
          component: () => import('../views/Administradora.vue')
        }
      ]
    }
  ],
})

export default router
