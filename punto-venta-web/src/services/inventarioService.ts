import API from './api';
import type { Inventario } from '../types/inventario';

export const obtenerInventario = async (): Promise<Inventario[]> => {
  const res = await API.get('/inventario');
  return res.data;
};

export const agregarInventario = async (entrada: Omit<Inventario, 'id'>): Promise<Inventario> => {
  const res = await API.post('/inventario', entrada);
  return res.data;
};
