// src/pages/SaldoMensalPage.tsx
import React from 'react';
import { useParams } from 'react-router-dom';
import { useSaldoMensal } from '../hooks/useSaldoMensal';

export function SaldoMensalPage() {
  // extrai "ano" e "mes" da URL
  const { ano, mes } = useParams<{ ano: string; mes: string }>();
  // converte pra número
  const anoNum = Number(ano);
  const mesNum = Number(mes);

  const { saldo, loading } = useSaldoMensal(anoNum, mesNum);

  // Extrai totalReceitas e totalDespesas do saldo, se saldo não for nulo
  const totalReceitas = saldo ? saldo.totalReceitas : 0;
  const totalDespesas = saldo ? saldo.totalDespesas : 0;

  if (loading) return <p>Carregando saldo mensal...</p>;

  return (
    <div>
      <h1>Saldo Mensal</h1>
      <dl>
        <dt>Ano</dt>
        <dd>{anoNum}</dd>
        <dt>Mês</dt>
        <dd>{mesNum}</dd>
        <dt>Total de Receitas</dt>
        <dd>R$ {totalReceitas.toFixed(2)}</dd>
        <dt>Total de Despesas</dt>
        <dd>R$ {totalDespesas.toFixed(2)}</dd>
        <dt>Saldo</dt>
        <dd>R$ {(saldo ? saldo.saldo.toFixed(2) : '0.00')}</dd>
      </dl>
    </div>
  );
}
