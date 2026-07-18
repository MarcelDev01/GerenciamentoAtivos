import api from './Api'

export interface LookupDto {
  id: string
  nome: string
}

export const lookupService = {
  getSegmentosLookup: async (): Promise<LookupDto[]> => {
    const { data } = await api.get<LookupDto[]>('/Lookup/Segmentos')
    return data
  },

  getAdministradorasLookup: async (): Promise<LookupDto[]> => {
    const { data } = await api.get<LookupDto[]>('/Lookup/Administradoras')
    return data
  },
}
