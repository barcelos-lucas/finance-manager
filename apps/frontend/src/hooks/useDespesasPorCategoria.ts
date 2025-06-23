import { useEffect, useState } from 'react';
import api from '../api/api'
import { DespesaPorCategoria } from '../types/DespesaPorCategoria'

interface DespesaResponse {
  items: DespesaPorCategoria[];
}

export function useDespesasPorCategoria(ano: number, mes: number) {
  const [data, setData] = useState<DespesaPorCategoria[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    api
      .get<DespesaResponse>(`/relatorios/despesas-mes/${ano}/${mes}`)
      .then(res => {
        setData(res.data.items);
      })
      .catch(err => {
        setError(err.message || 'Erro ao carregar despesas por categoria');
      })
      .then(() => {
        setLoading(false);
      });  


  }, [ano, mes]);


  return { data, loading, error };
}
