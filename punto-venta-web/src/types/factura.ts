export interface DetalleFactura {
    id?: number;
    idFactura?: number;
    idProducto: number;
    cantidad: number;
    precioUnitario: number;
  }
  
  export interface Factura {
    id?: number;
    fecha: string;
    total: number;
    idDependiente: number;
    detalles: DetalleFactura[];
  }