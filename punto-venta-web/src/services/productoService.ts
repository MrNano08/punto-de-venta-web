import API from './api';
import type { Producto } from '../types/producto';

export const obtenerProductos = async (): Promise<Producto[]> => {
  const res = await API.get('/producto');
  return res.data;
};

export const agregarProducto = async (producto: Omit<Producto, 'id'>): Promise<Producto> => {
  const res = await API.post('/producto', producto);
  return res.data;
};

export const eliminarProducto = async (id: number): Promise<void> => {
  await API.delete(`/producto/${id}`);
};
