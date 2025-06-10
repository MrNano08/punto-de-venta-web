import API from './api';
import type { Pedido } from '../types/pedido';

export const obtenerPedidos = async (): Promise<Pedido[]> => {
  const res = await API.get('/pedido');
  return res.data;
};

export const agregarPedido = async (pedido: Omit<Pedido, 'id'>): Promise<Pedido> => {
  const res = await API.post('/pedido', pedido);
  return res.data;
};
