import api from './api'

//#region Dto's
export interface AdministradoraDto {
    id: string,
    nomeFantasia: string,
    cnpjEmpresa: string,
    cnpjDono: string,
    ativo: boolean,
    created: string,
    updated?: string
}

export interface CriarAdministradoraDto {
    nomeFantasia: string,
    cnpjEmpresa: string,
    cnpjDono: string,
}

export interface AtualizarAdministradoraDto {
    id: string,
    nomeFantasia: string,
    cnpjEmpresa: string,
    cnpjDono: string,
    ativo: boolean,
}
//#endregion

export const administradoraService = {
    getAll: async (): Promise<AdministradoraDto[]> => {
        const response = await api.get<AdministradoraDto[]>('/Administradora/Administradoras/')
        return response.data
    },

    getById: async (id: string): Promise<AdministradoraDto> => {
        const response = await api.get<AdministradoraDto>(`/Administradora/AdministradoraByID/${id}`)
        return response.data
    },

    create: async (administradora: CriarAdministradoraDto): Promise<CriarAdministradoraDto> => {
        const response = await api.post<CriarAdministradoraDto>('/Administradora/CriarAdministradora/', administradora)
        return response.data
    },

    update: async (administradora: AtualizarAdministradoraDto): Promise<void> => {
        await api.patch<AdministradoraDto>('/Administradora/AtualizarAdministradora/', administradora)
    },

    delete: async (id: string): Promise<void> => {
        await api.delete(`/Administradora/ExcluirAdministradora/${id}`)
    }
}