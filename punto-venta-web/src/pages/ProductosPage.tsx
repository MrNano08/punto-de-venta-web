import { useEffect, useState } from 'react';
import type { Producto } from '../types/producto';
import { obtenerProductos, agregarProducto, eliminarProducto } from '../services/productoService';

const ProductosPage = () => {
  const [productos, setProductos] = useState<Producto[]>([]);
  const [nuevo, setNuevo] = useState<Omit<Producto, 'id'>>({
    nombre: '',
    descripcion: '',
    tipo: 'Unidad',
    precio: 0,
    stock: 0,
  });

  const cargar = async () => {
    const data = await obtenerProductos();
    setProductos(data);
  };

  useEffect(() => {
    cargar();
  }, []);

  const handleAgregar = async () => {
    if (!nuevo.nombre) return;
    await agregarProducto(nuevo);
    await cargar();
    setNuevo({ nombre: '', descripcion: '', tipo: 'Unidad', precio: 0, stock: 0 });
  };

  const handleEliminar = async (id: number) => {
    await eliminarProducto(id);
    await cargar();
  };

  return (
    <div className="p-6 bg-gray-100 min-h-screen">
      <h2 className="text-3xl font-bold text-center text-gray-800 mb-8">Gestión de Productos</h2>

      <div className="bg-white p-6 rounded-xl shadow-md max-w-5xl mx-auto mb-10 space-y-4">
        <h4 className="text-xl font-semibold text-gray-700">Agregar nuevo producto</h4>
        <div className="grid grid-cols-1 md:grid-cols-3 gap-4">
          <input
            type="text"
            placeholder="Nombre"
            value={nuevo.nombre}
            onChange={e => setNuevo({ ...nuevo, nombre: e.target.value })}
            className="p-3 border border-gray-300 rounded-md"
          />
          <input
            type="text"
            placeholder="Descripción"
            value={nuevo.descripcion}
            onChange={e => setNuevo({ ...nuevo, descripcion: e.target.value })}
            className="p-3 border border-gray-300 rounded-md"
          />
          <select
            value={nuevo.tipo}
            onChange={e => setNuevo({ ...nuevo, tipo: e.target.value })}
            className="p-3 border border-gray-300 rounded-md"
          >
            <option value="Unidad">Unidad</option>
            <option value="Lote">Lote</option>
          </select>
          <input
            type="number"
            placeholder="Precio"
            value={nuevo.precio}
            onChange={e => setNuevo({ ...nuevo, precio: parseFloat(e.target.value) })}
            className="p-3 border border-gray-300 rounded-md"
          />
          <input
            type="number"
            placeholder="Stock"
            value={nuevo.stock}
            onChange={e => setNuevo({ ...nuevo, stock: parseInt(e.target.value) })}
            className="p-3 border border-gray-300 rounded-md"
          />
        </div>
        <div className="flex justify-end">
          <button
            onClick={handleAgregar}
            className="bg-blue-600 hover:bg-blue-700 text-white px-6 py-2 rounded-lg transition-all"
          >
            Agregar
          </button>
        </div>
      </div>

      <div className="overflow-x-auto max-w-6xl mx-auto">
        <h4 className="text-2xl font-semibold text-gray-700 mb-4 text-center">Productos Registrados</h4>
        <table className="w-full bg-white shadow-md rounded-xl overflow-hidden">
          <thead className="bg-blue-600 text-white">
            <tr>
              <th className="py-3 px-4 text-left">ID</th>
              <th className="py-3 px-4 text-left">Nombre</th>
              <th className="py-3 px-4 text-left">Descripción</th>
              <th className="py-3 px-4 text-left">Tipo</th>
              <th className="py-3 px-4 text-left">Precio</th>
              <th className="py-3 px-4 text-left">Stock</th>
              <th className="py-3 px-4 text-left">Acción</th>
            </tr>
          </thead>
          <tbody>
            {productos.map(prod => (
              <tr key={prod.id} className="border-b hover:bg-gray-50">
                <td className="py-3 px-4">{prod.id}</td>
                <td className="py-3 px-4">{prod.nombre}</td>
                <td className="py-3 px-4">{prod.descripcion}</td>
                <td className="py-3 px-4">{prod.tipo}</td>
                <td className="py-3 px-4">₡{prod.precio.toFixed(2)}</td>
                <td className="py-3 px-4">{prod.stock}</td>
                <td className="py-3 px-4">
                  <button
                    onClick={() => handleEliminar(prod.id)}
                    className="text-red-600 hover:text-red-800 font-semibold"
                  >
                    Eliminar
                  </button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
  );
};

export default ProductosPage;
