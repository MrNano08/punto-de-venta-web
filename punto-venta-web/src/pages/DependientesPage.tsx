import { useEffect, useState } from 'react';
import { obtenerDependientes, agregarDependiente } from '../services/dependienteService';
import type { Dependiente } from '../types/dependiente';

const DependientesPage = () => {
  const [dependientes, setDependientes] = useState<Dependiente[]>([]);
  const [nuevo, setNuevo] = useState<Omit<Dependiente, 'id'>>({
    nombre: '',
    apellidos: '',
    identificacion: '',
    origen: '',
  });

  const cargar = async () => {
    const data = await obtenerDependientes();
    setDependientes(data);
  };

  useEffect(() => {
    cargar();
  }, []);

  const registrar = async () => {
    if (!nuevo.nombre || !nuevo.identificacion) return;
    await agregarDependiente(nuevo);
    await cargar();
    setNuevo({ nombre: '', apellidos: '', identificacion: '', origen: '' });
  };

  return (
    <div className="p-6 bg-gray-100 min-h-screen">
      <h2 className="text-3xl font-bold text-center text-gray-800 mb-6">Gestión de Dependientes</h2>

      <div className="bg-white p-6 rounded-xl shadow-md max-w-4xl mx-auto mb-8">
        <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
          <input
            type="text"
            placeholder="Nombre"
            value={nuevo.nombre}
            onChange={(e) => setNuevo({ ...nuevo, nombre: e.target.value })}
            className="p-3 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-400"
          />
          <input
            type="text"
            placeholder="Apellidos"
            value={nuevo.apellidos}
            onChange={(e) => setNuevo({ ...nuevo, apellidos: e.target.value })}
            className="p-3 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-400"
          />
          <input
            type="text"
            placeholder="Identificación"
            value={nuevo.identificacion}
            onChange={(e) => setNuevo({ ...nuevo, identificacion: e.target.value })}
            className="p-3 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-400"
          />
          <input
            type="text"
            placeholder="Origen"
            value={nuevo.origen}
            onChange={(e) => setNuevo({ ...nuevo, origen: e.target.value })}
            className="p-3 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-400"
          />
        </div>
        <div className="flex justify-end mt-4">
          <button
            onClick={registrar}
            className="bg-blue-600 hover:bg-blue-700 text-white font-semibold px-6 py-2 rounded-lg transition-all"
          >
            Agregar
          </button>
        </div>
      </div>

      <div className="overflow-x-auto max-w-6xl mx-auto">
        <table className="w-full bg-white shadow-md rounded-xl overflow-hidden">
          <thead className="bg-blue-600 text-white">
            <tr>
              <th className="py-3 px-4 text-left">ID</th>
              <th className="py-3 px-4 text-left">Nombre</th>
              <th className="py-3 px-4 text-left">Apellidos</th>
              <th className="py-3 px-4 text-left">Identificación</th>
              <th className="py-3 px-4 text-left">Origen</th>
            </tr>
          </thead>
          <tbody>
            {dependientes.map((d) => (
              <tr key={d.id} className="border-b hover:bg-gray-50">
                <td className="py-3 px-4">{d.id}</td>
                <td className="py-3 px-4">{d.nombre}</td>
                <td className="py-3 px-4">{d.apellidos}</td>
                <td className="py-3 px-4">{d.identificacion}</td>
                <td className="py-3 px-4">{d.origen}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
  );
};

export default DependientesPage;
