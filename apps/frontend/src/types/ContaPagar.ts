export interface CreateContaPagarRequest {
    userId: string;
    descricao: string;
    valor: number;
    dataVencimento: string; 
    categoria: string;
}

export interface UpdateContaPagarRequest {
    id: string;
    descricao: string;
    valor: number;
    dataVencimento: string; 
    categoria: string;
    status: 'Pendente' | 'Pago';
}

export interface ContaPagarDto {
    id: string;
    descricao: string;
    valor: number;
    dataVencimento: string; 
    categoria: string;
    status: 'Pendente' | 'Pago';
    createdAt: string; 
}

export interface Paginated<T> {
    items: T[];
}
