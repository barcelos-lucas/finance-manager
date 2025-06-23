export interface CreateContaReceberRequest {
    userId: string;
    descricao: string;
    valor: number;
    dataRecebimento: string; // ISO date
    categoria: string;
}

export interface UpdateContaReceberRequest {
    id: string;
    descricao: string;
    valor: number;
    dataRecebimento: string; // ISO date
    categoria: string;
    status: 'Pendente' | 'Recebido';
}

export interface ContaReceberDto {
    id: string;
    descricao: string;
    valor: number;
    dataRecebimento: string;
    categoria: string;
    status: 'Pendente' | 'Recebido';
    createdAt: string;
}
