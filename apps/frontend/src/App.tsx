// apps/frontend/src/App.tsx
import {BrowserRouter, Routes, Route} from 'react-router-dom';
import { Header } from './components/Header';
import { DespesasPorCategoriaPage } from './pages/DespesasPorCategoriaPage';
import { SaldoMensalPage } from './pages/SaldoMensalPage';



function App() {
  return (
    <BrowserRouter>
      <Header />        
      <Routes>
        <Route
          path="/relatorios/saldo-mes/:ano/:mes"
          element={<SaldoMensalPage />}
        />
        <Route
          path="/relatorios/despesas-mes/:ano/:mes"
          element={<DespesasPorCategoriaPage />}
        />
        {/* outras rotas */}
      </Routes>
    </BrowserRouter>
  );
}

export default App;