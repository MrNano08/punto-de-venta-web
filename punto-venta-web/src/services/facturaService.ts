import API from './api';
import type { Factura } from '../types/factura';

export const obtenerFacturas = async (): Promise<Factura[]> => {
  const res = await API.get('/factura');
  return res.data;
};

export const agregarFactura = async (factura: Omit<Factura, 'id'>): Promise<Factura> => {
  const res = await API.post('/factura', factura);
  return res.data;
};
