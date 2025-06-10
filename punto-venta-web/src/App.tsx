import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import ProductosPage from './pages/ProductosPage';
import OfertasPage from './pages/OfertasPage';
import InventarioPage from './pages/InventarioPage';
import PedidosPage from './pages/PedidosPage';
import DependientesPage from './pages/DependientesPage';
import FacturasPage from './pages/FacturasPage';
import HomePage from './pages/HomePage';
import NavBar from './components/Navbar'; 

const App = () => {
  return (
    <Router>
      <NavBar />
      <div className="p-6">
        <Routes>
          <Route path="/" element={<HomePage />} />
          <Route path="/productos" element={<ProductosPage />} />
          <Route path="/ofertas" element={<OfertasPage />} />
          <Route path="/inventario" element={<InventarioPage />} />
          <Route path="/pedidos" element={<PedidosPage />} />
          <Route path="/dependientes" element={<DependientesPage />} />
          <Route path="/facturas" element={<FacturasPage />} />
        </Routes>
      </div>
    </Router>
  );
};

export default App;
