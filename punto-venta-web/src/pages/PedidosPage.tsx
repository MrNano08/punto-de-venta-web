import { useEffect, useState } from 'react';
import { obtenerPedidos, agregarPedido } from '../services/pedidoService';
import type { Pedido, DetallePedido } from '../types/pedido';

const PedidosPage = () => {
  const [pedidos, setPedidos] = useState<Pedido[]>([]);
  const [nuevoPedido, setNuevoPedido] = useState<Omit<Pedido, 'id'>>({
    fechaPedido: new Date().toISOString().split('T')[0],
    idProveedor: 1,
    detalles: [],
  });

  const [detalleActual, setDetalleActual] = useState<DetallePedido>({
    idProducto: 0,
    cantidad: 1,
  });

  const cargar = async () => {
    const data = await obtenerPedidos();
    setPedidos(data);
  };

  useEffect(() => {
    cargar();
  }, []);

  const agregarDetalle = () => {
    setNuevoPedido({
      ...nuevoPedido,
      detalles: [...nuevoPedido.detalles, detalleActual],
    });

    setDetalleActual({ idProducto: 0, cantidad: 1 });
  };

  const registrarPedido = async () => {
    if (!nuevoPedido.detalles.length) return;
    await agregarPedido(nuevoPedido);
    await cargar();
    setNuevoPedido({
      fechaPedido: new Date().toISOString().split('T')[0],
      idProveedor: 1,
      detalles: [],
    });
  };

  return (
    <div className="p-6 bg-gray-100 min-h-screen">
      <h2 className="text-3xl font-bold text-center text-gray-800 mb-8">Gestión de Pedidos</h2>

      <div className="bg-white p-6 rounded-xl shadow-md max-w-4xl mx-auto mb-10 space-y-4">
        <h4 className="text-xl font-semibold text-gray-700">Nuevo Pedido</h4>
        <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
          <input
            type="date"
            value={nuevoPedido.fechaPedido}
            onChange={(e) =>
              setNuevoPedido({ ...nuevoPedido, fechaPedido: e.target.value })
            }
            className="p-3 border border-gray-300 rounded-md"
          />
          <input
            type="number"
            placeholder="ID Proveedor"
            value={nuevoPedido.idProveedor}
            onChange={(e) =>
              setNuevoPedido({ ...nuevoPedido, idProveedor: parseInt(e.target.value) })
            }
            className="p-3 border border-gray-300 rounded-md"
          />
        </div>

        <h5 className="text-lg font-medium text-gray-600 mt-4">Agregar Detalle</h5>
        <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
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
        </div>

        <div className="flex gap-4 justify-end mt-4">
          <button
            onClick={agregarDetalle}
            className="bg-blue-500 text-white px-6 py-2 rounded-lg hover:bg-blue-600 transition-all"
          >
            Agregar Detalle
          </button>
          <button
            onClick={registrarPedido}
            className="bg-green-600 text-white px-6 py-2 rounded-lg hover:bg-green-700 transition-all"
          >
            Registrar Pedido
          </button>
        </div>
      </div>

      <div className="overflow-x-auto max-w-6xl mx-auto">
        <h4 className="text-2xl font-semibold text-gray-700 mb-4 text-center">Pedidos Registrados</h4>
        <table className="w-full bg-white shadow-md rounded-xl overflow-hidden">
          <thead className="bg-blue-600 text-white">
            <tr>
              <th className="py-3 px-4 text-left">ID</th>
              <th className="py-3 px-4 text-left">Fecha</th>
              <th className="py-3 px-4 text-left">Proveedor</th>
              <th className="py-3 px-4 text-left">Detalles (cantidad)</th>
            </tr>
          </thead>
          <tbody>
            {pedidos.map((p) => (
              <tr key={p.id} className="border-b hover:bg-gray-50">
                <td className="py-3 px-4">{p.id}</td>
                <td className="py-3 px-4">{p.fechaPedido.split('T')[0]}</td>
                <td className="py-3 px-4">{p.idProveedor}</td>
                <td className="py-3 px-4">{p.detalles?.length ?? 0}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
  );
};

export default PedidosPage;
