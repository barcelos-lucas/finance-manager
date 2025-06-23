import { useParams } from 'react-router-dom';
import { useDespesasPorCategoria } from '../hooks/useDespesasPorCategoria';

export function DespesasPorCategoriaPage() {
  const { ano, mes } = useParams<{ ano: string; mes: string }>();
  const { data, loading, error } = useDespesasPorCategoria(
    Number(ano),
    Number(mes)
  );

  if (loading) return <p>Carregando...</p>;
  if (error)   return <p style={{ color: 'red' }}>{error}</p>;

  return (
    <div>
      <h1>Despesas por Categoria</h1>
      <table>
        <thead>
          <tr>
            <th>Categoria</th>
            <th>Total</th>
          </tr>
        </thead>
        <tbody>
          {data.map((d) => (
            <tr key={d.categoria}>
              <td>{d.categoria}</td>
              <td>{d.total.toLocaleString('pt-BR', { style: 'currency', currency: 'BRL' })}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}