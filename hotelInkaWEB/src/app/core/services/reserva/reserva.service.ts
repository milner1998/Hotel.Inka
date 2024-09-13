import { Injectable } from '@angular/core';
import { ApiService } from '../http/api.service';
import * as Url from '../../constants/api.constants';
import { Observable, tap } from 'rxjs';
import { ToolService } from '../tool/tool.service';
import { ObtenerCatalogoHabitacionesDTO } from '../../models/reserva/response/lista/obtener-catalogo-habitaciones-dto.model';

@Injectable({
  providedIn: 'root'
})
export class ReservaService {

  constructor(private apiService: ApiService,
    private _toolService: ToolService,
  ) { }

  ObtenerCalogoHabitacionesAsync(): Observable<ObtenerCatalogoHabitacionesDTO[]> {
    return this.apiService.get(Url.Reserva.ObtenerCalogoHabitacionesAsync)
      .pipe(tap(data => data));
  }

}
