import axios from 'axios'

const api = axios.create({
  // Ajuste a porta (5001, 7000, etc.) para bater exatamente com o HTTPS da sua API .NET
  baseURL: 'https://localhost:7001/api',
  headers: {
    'Content-Type': 'application/json',
  },
})

export default api
