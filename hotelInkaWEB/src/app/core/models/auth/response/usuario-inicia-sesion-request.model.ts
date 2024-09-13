import { ResponseDTO } from "../../generic/response-dto.model";
import { MonedaDTO } from "../../parametro/moneda-dto.model";

export interface UsuarioLoginDTO {
    response: ResponseDTO;
    idUsuario: string;
    nombres: string;
    apellidos: string;
    correoElectronico: string;
    idTipoCuenta: number;
    fechaRegistro: Date;
    monedaInfo: MonedaDTO;
}
