import axios from 'axios';

const API = axios.create({
  baseURL: 'http://localhost:5148/api/', // cambia al puerto real de tu backend
});

export default API;
