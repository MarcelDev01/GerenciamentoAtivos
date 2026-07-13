import api from './api'

//#region Dto's
export interface AtivoDto {
    id: string,
    segmentoId: string,
    administradoraId: string,
    codigoFii: string,
    qtdeCotas: number,
    rendimentoUnitario: number,
    precoCota: number,
    valorPatrimonial: number,
    ativo: boolean,
    created: string,
    updated?: string
}

export interface CriarAtivoDto {
    segmentoId: string,
    administradoraId: string,
    codigoFii: string,
    qtdeCotas: number,
    rendimentoUnitario: number,
    precoCota: number,
    valorPatrimonial: number,
}

export interface AtualizarAtivoDto {
    id: string,
    segmentoId: string,
    administradoraId: string,
    codigoFii: string,
    qtdeCotas: number,
    rendimentoUnitario: number,
    precoCota: number,
    valorPatrimonial: number,
    ativo: boolean,
}
//#endregion

export const ativoSegmento = {
    getAll: async (): Promise<AtivoDto[]> => {
        const response = await api.get<AtivoDto[]>('/Ativo/Ativos/')
        return response.data
    },

    getById: async (id: string): Promise<AtivoDto> => {
        const response = await api.get<AtivoDto>(`/Ativo/AtivoByID/${id}`)
        return response.data
    },

    create: async (ativo: CriarAtivoDto): Promise<CriarAtivoDto> => {
        const response = await api.post<CriarAtivoDto>('/Ativo/CriarAtivo/', ativo)
        return response.data
    },

    update: async (ativo: AtualizarAtivoDto): Promise<void> => {
        await api.patch<AtivoDto>('/Ativo/AtualizarAtivo/', ativo)
    },

    delete: async (id: string): Promise<void> => {
        await api.delete(`/Ativo/ExcluirAtivo/${id}`)
    }
}