import { DateTime } from "luxon";

export interface ObtenerOrdenHospedajeXDNI {
    nombreHuesped: string;
    apellidoHuesped:string;
    nroOrden:string;
    fechaIngreso:DateTime;
    fechaSalida:DateTime;
    nroHabitacion:number;
    tipoHabitacion:string;
}
