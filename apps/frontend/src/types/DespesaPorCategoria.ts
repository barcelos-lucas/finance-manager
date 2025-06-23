export interface DespesaPorCategoria {
    categoria: string;
    total: number;
}

export interface DespesaPorCategoriaResponse {
    items: DespesaPorCategoria[];
}
