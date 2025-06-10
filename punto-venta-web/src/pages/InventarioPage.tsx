import { useEffect, useState } from 'react';
import { obtenerInventario, agregarInventario } from '../services/inventarioService';
import type { Inventario } from '../types/inventario';

const InventarioPage = () => {
  const [inventario, setInventario] = useState<Inventario[]>([]);
  const [nuevo, setNuevo] = useState<Omit<Inventario, 'id'>>({
    fecha: new Date().toISOString().split('T')[0],
    observacion: '',
    idProducto: 1,
  });

  const cargar = async () => {
    const data = await obtenerInventario();
    setInventario(data);
  };

  useEffect(() => {
    cargar();
  }, []);

  const guardar = async () => {
    await agregarInventario(nuevo);
    await cargar();
    setNuevo({ fecha: new Date().toISOString().split('T')[0], observacion: '', idProducto: 1 });
  };

  return (
    <div className="p-6 bg-gray-100 min-h-screen">
      <h2 className="text-3xl font-bold text-center text-gray-800 mb-8">Registro de Inventario</h2>

      <div className="bg-white p-6 rounded-xl shadow-md max-w-4xl mx-auto mb-10 space-y-4">
        <h4 className="text-xl font-semibold text-gray-700">Agregar entrada</h4>
        <div className="grid grid-cols-1 md:grid-cols-3 gap-4">
          <input
            type="date"
            value={nuevo.fecha}
            onChange={(e) => setNuevo({ ...nuevo, fecha: e.target.value })}
            className="p-3 border border-gray-300 rounded-md"
          />
          <input
            type="text"
            placeholder="Observación"
            value={nuevo.observacion}
            onChange={(e) => setNuevo({ ...nuevo, observacion: e.target.value })}
            className="p-3 border border-gray-300 rounded-md"
          />
          <input
            type="number"
            placeholder="ID Producto"
            value={nuevo.idProducto}
            onChange={(e) => setNuevo({ ...nuevo, idProducto: parseInt(e.target.value) })}
            className="p-3 border border-gray-300 rounded-md"
          />
        </div>
        <div className="flex justify-end">
          <button
            onClick={guardar}
            className="bg-blue-600 hover:bg-blue-700 text-white px-6 py-2 rounded-lg transition-all"
          >
            Guardar
          </button>
        </div>
      </div>

      <div className="overflow-x-auto max-w-6xl mx-auto">
        <h4 className="text-2xl font-semibold text-gray-700 mb-4 text-center">Historial de Inventario</h4>
        <table className="w-full bg-white shadow-md rounded-xl overflow-hidden">
          <thead className="bg-blue-600 text-white">
            <tr>
              <th className="py-3 px-4 text-left">ID</th>
              <th className="py-3 px-4 text-left">Fecha</th>
              <th className="py-3 px-4 text-left">Producto</th>
              <th className="py-3 px-4 text-left">Observación</th>
            </tr>
          </thead>
          <tbody>
            {inventario.map((i) => (
              <tr key={i.id} className="border-b hover:bg-gray-50">
                <td className="py-3 px-4">{i.id}</td>
                <td className="py-3 px-4">{i.fecha.split('T')[0]}</td>
                <td className="py-3 px-4">{i.idProducto}</td>
                <td className="py-3 px-4">{i.observacion}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
  );
};

export default InventarioPage;
