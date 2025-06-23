import  { Link } from 'react-router-dom';

export function Header() {

  return (
    <header>
      <nav>
        <ul>
          <li><Link to="/relatorios/saldo-mes/2025/6">Saldo Mes</Link></li>
          <li><Link to="/relatorios/despesas-mes/2025/6">Despesas Por Categoria</Link></li>
        </ul>
      </nav>
    </header>
  );

}