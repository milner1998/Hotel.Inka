import { DateTime } from "luxon";

export interface ObtenerReservaxDNI {
    idReserva: number;
    idHuesped:number;
    fechInggreso:DateTime;
    fechSalida:DateTime;
    tipoHabitacion:string;
    descripcion:string;
    capHabitacion:number;
    estado:string;
}
