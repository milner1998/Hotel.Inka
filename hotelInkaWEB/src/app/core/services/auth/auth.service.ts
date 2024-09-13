import { Injectable } from '@angular/core';
import { ResponseDTO } from 'app/core/models/generic/response-dto.model';
import { ApiService } from '../http/api.service';
import { Observable, tap } from 'rxjs';
import * as Url from '../../constants/api.constants';
import { UsuarioIniciaSesionRequest } from 'app/core/models/auth/filtro/usuario-inicia-sesion-request.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private apiService: ApiService) { }

  ExistCorreo(correo: string): Observable<ResponseDTO> {
    return this.apiService.query(Url.Auth.ExistEmailAsync, {correo})
      .pipe(tap(data => data));
  }

  IniciaSesionAsync(request: UsuarioIniciaSesionRequest): Observable<ResponseDTO> {
    return this.apiService.post(Url.Auth.IniciaSesionAsync, request)
      .pipe(tap(data => data));
  }

}
