import { Injectable } from '@angular/core';
import { ApiService } from '../http/api.service';
import { BehaviorSubject, Observable, tap } from 'rxjs';
import * as Url from '../../constants/api.constants';
import { ParametroGeneralDTO } from 'app/core/models/parametro/parametro-general-dto.model';
import { RegistrarUsuarioRequest } from 'app/core/models/parametro/registrar-usuario-request.model';
import { ResponseDTO } from 'app/core/models/generic/response-dto.model';
import { MonedaDTO } from 'app/core/models/parametro/moneda-dto.model';


@Injectable({
  providedIn: 'root'
})
export class ParametroService {

  private _monedaData: BehaviorSubject<MonedaDTO> = new BehaviorSubject(null);

  constructor(private apiService: ApiService,

  ) { }

  get monedaData$(): Observable<MonedaDTO> {
    return this._monedaData.asObservable();
  }

 

}
