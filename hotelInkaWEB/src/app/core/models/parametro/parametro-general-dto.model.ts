import { GeneroDTO } from "./genero-dto.model";
import { MonedaDTO } from "./moneda-dto.model";
import { OcupacionDTO } from "./ocupacion-dto.model";
  
export interface ParametroGeneralDTO {
    lstGenero: GeneroDTO[];
    lstOcupacion: OcupacionDTO[];
    lstMoneda: MonedaDTO[];
}
