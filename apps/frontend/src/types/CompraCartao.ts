export interface CreateCompraCartaoRequest {
    userId: string;
    descricao: string;
    valor: number;
    dataCompra: string; 
    categoria: string;
    cartao: string;
    parcelas: number;
}

export interface UpdateCompraCartaoRequest {
    id: string;
    descricao: string;
    valor: number;
    dataCompra: string;
    categoria: string;
    cartao: string;
    parcelas: number;
    status: 'Pendente' | 'Pago';
}

export interface CompraCartaoDto {
    id: string;
    descricao: string;
    valor: number;
    dataCompra: string;
    categoria: string;
    cartao: string;
    parcelas: number;
    createdAt: string;
}
