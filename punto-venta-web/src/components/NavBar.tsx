import { Link } from 'react-router-dom';

const NavBar = () => {
  return (
    <nav className="bg-blue-800 text-white px-6 py-4 shadow-lg">
      <div className="flex justify-between items-center max-w-7xl mx-auto">
        <h1 className="text-xl font-bold">🛒 Punto de Venta</h1>
        <div className="flex space-x-6">
          <Link to="/" className="hover:text-yellow-300">Inicio</Link>
          <Link to="/productos" className="hover:text-yellow-300">Productos</Link>
          <Link to="/ofertas" className="hover:text-yellow-300">Ofertas</Link>
          <Link to="/inventario" className="hover:text-yellow-300">Inventario</Link>
          <Link to="/pedidos" className="hover:text-yellow-300">Pedidos</Link>
          <Link to="/dependientes" className="hover:text-yellow-300">Dependientes</Link>
          <Link to="/facturas" className="hover:text-yellow-300">Facturas</Link>
        </div>
      </div>
    </nav>
  );
};

export default NavBar;
