import { DateTime } from "luxon";

export interface ObtenerCatalogoXTipoDTO {
    idServicio: string;
    nombreServicio:string;
    descripcionServicio:string;
    precioServicio: number;
    precioTotal: number;
    cantidad: number
}
