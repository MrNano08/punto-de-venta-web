import { useEffect, useState } from 'react';
import { obtenerFacturas, agregarFactura } from '../services/facturaService';
import type { Factura, DetalleFactura } from '../types/factura';

const FacturasPage = () => {
  const [facturas, setFacturas] = useState<Factura[]>([]);
  const [nuevaFactura, setNuevaFactura] = useState<Omit<Factura, 'id'>>({
    fecha: new Date().toISOString().split('T')[0],
    total: 0,
    idDependiente: 1,
    detalles: [],
  });

  const [detalleActual, setDetalleActual] = useState<DetalleFactura>({
    idProducto: 0,
    cantidad: 1,
    precioUnitario: 0,
  });

  const cargarFacturas = async () => {
    const data = await obtenerFacturas();
    setFacturas(data);
  };

  useEffect(() => {
    cargarFacturas();
  }, []);

  const agregarDetalle = () => {
    setNuevaFactura({
      ...nuevaFactura,
      detalles: [...nuevaFactura.detalles, detalleActual],
      total: nuevaFactura.total + detalleActual.cantidad * detalleActual.precioUnitario,
    });

    setDetalleActual({ idProducto: 0, cantidad: 1, precioUnitario: 0 });
  };

  const registrarFactura = async () => {
    await agregarFactura(nuevaFactura);
    await cargarFacturas();
    setNuevaFactura({
      fecha: new Date().toISOString().split('T')[0],
      total: 0,
      idDependiente: 1,
      detalles: [],
    });
  };

  return (
    <div className="p-6 bg-gray-100 min-h-screen">
      <h2 className="text-3xl font-bold text-center text-gray-800 mb-8">Gestión de Facturas</h2>

      <div className="bg-white p-6 rounded-xl shadow-md max-w-4xl mx-auto mb-10 space-y-4">
        <h4 className="text-xl font-semibold text-gray-700 mb-2">Nueva Factura</h4>
        <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
          <input
            type="date"
            value={nuevaFactura.fecha}
            onChange={(e) => setNuevaFactura({ ...nuevaFactura, fecha: e.target.value })}
            className="p-3 border border-gray-300 rounded-md"
          />
          <input
            type="number"
            placeholder="ID Dependiente"
            value={nuevaFactura.idDependiente}
            onChange={(e) =>
              setNuevaFactura({ ...nuevaFactura, idDependiente: parseInt(e.target.value) })
            }
            className="p-3 border border-gray-300 rounded-md"
          />
        </div>

        <h5 className="text-lg font-medium text-gray-600 mt-6">Agregar Detalle</h5>
        <div className="grid grid-cols-1 md:grid-cols-3 gap-4">
          <input
            type="number"
            placeholder="ID Producto"
            value={detalleActual.idProducto}
            onChange={(e) =>
              setDetalleActual({ ...detalleActual, idProducto: parseInt(e.target.value) })
            }
            className="p-3 border border-gray-300 rounded-md"
          />
          <input
            type="number"
            placeholder="Cantidad"
            value={detalleActual.cantidad}
            onChange={(e) =>
              setDetalleActual({ ...detalleActual, cantidad: parseInt(e.target.value) })
            }
            className="p-3 border border-gray-300 rounded-md"
          />
          <input
            type="number"
            placeholder="Precio Unitario"
            value={detalleActual.precioUnitario}
            onChange={(e) =>
              setDetalleActual({ ...detalleActual, precioUnitario: parseFloat(e.target.value) })
            }
            className="p-3 border border-gray-300 rounded-md"
          />
        </div>

        <div className="flex gap-4 justify-end mt-4">
          <button
            onClick={agregarDetalle}
            className="bg-blue-500 text-white px-6 py-2 rounded-lg hover:bg-blue-600 transition-all"
          >
            Agregar Detalle
          </button>
          <button
            onClick={registrarFactura}
            className="bg-green-500 text-white px-6 py-2 rounded-lg hover:bg-green-600 transition-all"
          >
            Registrar Factura
          </button>
        </div>
      </div>

      <div className="overflow-x-auto max-w-6xl mx-auto">
        <h4 className="text-2xl font-semibold text-gray-700 mb-4">Facturas Registradas</h4>
        <table className="w-full bg-white shadow-md rounded-xl overflow-hidden">
          <thead className="bg-blue-600 text-white">
            <tr>
              <th className="py-3 px-4 text-left">ID</th>
              <th className="py-3 px-4 text-left">Fecha</th>
              <th className="py-3 px-4 text-left">Total</th>
              <th className="py-3 px-4 text-left">Dependiente</th>
            </tr>
          </thead>
          <tbody>
            {facturas.map((f) => (
              <tr key={f.id} className="border-b hover:bg-gray-50">
                <td className="py-3 px-4">{f.id}</td>
                <td className="py-3 px-4">{f.fecha.split('T')[0]}</td>
                <td className="py-3 px-4">₡{f.total.toFixed(2)}</td>
                <td className="py-3 px-4">{f.idDependiente}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
  );
};

export default FacturasPage;
