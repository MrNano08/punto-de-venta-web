export interface DetallePedido {
    id?: number;
    idPedido?: number;
    idProducto: number;
    cantidad: number;
  }
  
  export interface Pedido {
    id?: number;
    fechaPedido: string;
    idProveedor: number;
    detalles: DetallePedido[];
  }
  