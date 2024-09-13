import { Injectable } from '@angular/core';
import { ResponseDTO } from 'app/core/models/generic/response-dto.model';
import { ApiService } from '../http/api.service';
import { BehaviorSubject, Observable, tap } from 'rxjs';
import * as Url from '../../constants/api.constants';
import { UsuarioIniciaSesionRequest } from 'app/core/models/auth/filtro/usuario-inicia-sesion-request.model';
import { Country } from 'app/core/models/auth/filtro/countries.request.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private _countries: BehaviorSubject<Country[] | null> = new BehaviorSubject(null);
    /**
     * Getter for countries
     */
    get countries$(): Observable<Country[]>
    {
        return this._countries.asObservable();
    }


  constructor(private apiService: ApiService,
    private _httpClient: HttpClient) { }

  ExistCorreo(correo: string): Observable<ResponseDTO> {
    return this.apiService.query(Url.Auth.ExistEmailAsync, { correo })
      .pipe(tap(data => data));
  }

  IniciaSesionAsync(request: UsuarioIniciaSesionRequest): Observable<ResponseDTO> {
    return this.apiService.post(Url.Auth.IniciaSesionAsync, request)
      .pipe(tap(data => data));
  }
 
  getCountries(): Observable<Country[]> {
    return this._httpClient.get<Country[]>('api/apps/contacts/countries').pipe(
      tap((countries) => {
        this._countries.next(countries);
      }),
    );
  }

}
