import API from './api';
import type { Dependiente } from '../types/dependiente';

export const obtenerDependientes = async (): Promise<Dependiente[]> => {
  const res = await API.get('/dependiente');
  return res.data;
};

export const agregarDependiente = async (d: Omit<Dependiente, 'id'>): Promise<Dependiente> => {
  const res = await API.post('/dependiente', d);
  return res.data;
};
