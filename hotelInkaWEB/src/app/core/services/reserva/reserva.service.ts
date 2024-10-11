import { Injectable } from '@angular/core';
import { ApiService } from '../http/api.service';
import * as Url from '../../constants/api.constants';
import { Observable, tap } from 'rxjs';
import { ObtenerCatalogoHabitacionesDTO } from '../../models/reserva/response/lista/obtener-catalogo-habitaciones-dto.model';
import { ObtenerClientePorDNIDTO } from 'app/core/models/reserva/response/lista/obtener-cliente-por-dni-dto.model';
import { ObtenerReservaxDNI } from 'app/core/models/reserva/response/lista/obtener-reserva-por-dni-dto.model';
import { ObtenerOrdenHospedajeXDNI } from 'app/core/models/reserva/response/Obtener-orden-hospedaje-x-dni';
import { ObtenerCatalogoXTipoDTO } from 'app/core/models/reserva/response/Obtener-catalogo-servicios-por-tipo';
import { ObtenerTiposServiciosDTO } from 'app/core/models/reserva/response/lista/Obtener-tipo-servicio';

@Injectable({
  providedIn: 'root'
})
export class ReservaService {

  constructor(private apiService: ApiService,
  ) { }

  ObtenerCalogoHabitacionesAsync(): Observable<ObtenerCatalogoHabitacionesDTO[]> {
    return this.apiService.get(Url.Reserva.ObtenerCalogoHabitacionesAsync)
      .pipe(tap(data => data));
  }

  ObtenerClienteXDNIAsync(dni: string): Observable<ObtenerClientePorDNIDTO> {
    return this.apiService.query(Url.Reserva.ObtenerClienteXDNIAsync, { dni })
      .pipe(tap(data => data));
  }

  ObtenerReservaDNIAsync(idhueped: number): Observable<ObtenerReservaxDNI[]> {
    return this.apiService.query(Url.Reserva.ObtenerReservaDNIAsync, { idhueped })
      .pipe(tap(data => data));
  }

  ObtenerOrdenHospedajeAsync(dni: string): Observable<ObtenerOrdenHospedajeXDNI> {
    return this.apiService.query(Url.Reserva.ObtenerOrdenHospedajeAsync, { dni })
      .pipe(tap(data => data));
  }

  ObtenerCatalogoXTipoAsync(tipo: number): Observable<ObtenerCatalogoXTipoDTO> {
    return this.apiService.query(Url.Reserva.ObtenerOrdenHospedajeAsync, { tipo })
      .pipe(tap(data => data));
  }

  ObtenerTipoServicioAsync(): Observable<ObtenerTiposServiciosDTO[]> {
    return this.apiService.get(Url.Reserva.ObtenerTipoServicioAsync)
      .pipe(tap(data => data));
  }

}
