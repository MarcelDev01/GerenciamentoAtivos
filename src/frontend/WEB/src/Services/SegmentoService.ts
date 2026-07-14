import api from './Api'

//#region Dto's
export interface SegmentoDto {
  id: string
  nome: string
  ativo: boolean
  created: string
  updated?: string
}

export interface CriarSegmentoDto {
  nome: string
}

export interface AtualizarSegmentoDto {
  id: string
  nome: string
  ativo: boolean
}
//#endregion

export const segmentoService = {
  getAll: async (): Promise<SegmentoDto[]> => {
    const response = await api.get<SegmentoDto[]>('/Segmento/Segmentos/')
    return response.data
  },

  getById: async (id: string): Promise<SegmentoDto> => {
    const response = await api.get<SegmentoDto>(`/Segmento/SegmentoByID/${id}`)
    return response.data
  },

  create: async (segmento: CriarSegmentoDto): Promise<CriarSegmentoDto> => {
    const response = await api.post<CriarSegmentoDto>('/Segmento/CriarSegmento/', segmento)
    return response.data
  },

  update: async (segmento: AtualizarSegmentoDto): Promise<void> => {
    await api.patch<SegmentoDto>('/Segmento/AtualizarSegmento/', segmento)
  },

  delete: async (id: string): Promise<void> => {
    await api.delete(`/Segmento/ExcluirSegmento/${id}`)
  },
}
