import { Injectable } from '@angular/core';
import { ApiService } from '../http/api.service';
import * as Url from '../../constants/api.constants';
import { BehaviorSubject, Observable, tap } from 'rxjs';
import { ObtenerHomeRequest } from 'app/core/models/home/request/obtener-home-request.model';
import { HomeDTO } from 'app/core/models/home/response/home-dto.model';
import { ToolService } from '../tool/tool.service';
import { ObtenerHomeReporteRequest } from 'app/core/models/home/request/obtener-home-reporte-request.model';

@Injectable({
  providedIn: 'root'
})
export class HomeService {

  private _homeData: BehaviorSubject<HomeDTO> = new BehaviorSubject(null);

  constructor(private apiService: ApiService,
    private _toolService: ToolService,
  ) { }

  get homeData$(): Observable<HomeDTO> {
    return this._homeData.asObservable();
  }
  
  GetHomeDataByFilterAsync(request: ObtenerHomeRequest): Observable<HomeDTO> {
    return this.apiService.post(Url.Home.GetHomeDataAsync, request)
      .pipe(tap((response: HomeDTO) => {
        this._homeData.next(response);
      }));
  }

  GetHomeReporteAsync(request: ObtenerHomeReporteRequest): Observable<any> {
    return this.apiService.postBlob(Url.Home.GetHomeReporteAsync, request)
      .pipe(tap(data => data));
  }

}
