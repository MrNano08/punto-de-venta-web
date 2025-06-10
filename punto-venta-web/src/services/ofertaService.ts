import API from './api';
import type { Oferta } from '../types/oferta';

export const obtenerOfertas = async (): Promise<Oferta[]> => {
  const res = await API.get('/oferta');
  return res.data;
};

export const agregarOferta = async (oferta: Omit<Oferta, 'id'>): Promise<Oferta> => {
  const res = await API.post('/oferta', oferta);
  return res.data;
};
