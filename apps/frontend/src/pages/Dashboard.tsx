import React, { useEffect, useState } from 'react';
import api from '../api/api';


interface SaldoResponse {
    totalReceitas: number;
    totalDespesas: number;
    saldo: number;
}

export const Dashboard: React.FC = () => {
    const [saldo, setSaldo] = useState<SaldoResponse | null>(null);

    useEffect(() => {
        api
            .get<SaldoResponse>('/api/relatorios/saldo-mes/2025/6')
            .then(res => setSaldo(res.data))
            .catch(console.error);
    }, []);

    if (!saldo) return <div>Carregando...</div>;

    return (
        <div>
            <h1>Dashboard Financeiro</h1>
            <p>Total Receitas: R$ {saldo.totalReceitas.toFixed(2)}</p>
            <p>Total Despesas: R$ {saldo.totalDespesas.toFixed(2)}</p>
            <p>
                <strong>Saldo: R$ {saldo.saldo.toFixed(2)}</strong>
            </p>
        </div>
    );
};
