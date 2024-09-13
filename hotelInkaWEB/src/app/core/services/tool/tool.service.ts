import { EventEmitter, Injectable } from '@angular/core';
import { Numeracion } from 'app/core/resource/dictionary.constants';
import { DateTime } from 'luxon';
import { ToastrService } from 'ngx-toastr';
import { getLocaleCurrencyCode } from '@angular/common';
import { ApiService } from '../http/api.service';
import { Observable, tap } from 'rxjs';
import * as Url from '../../constants/api.constants';
import { CambiarMonedaRequest } from 'app/core/models/tools/cambiar-moneda-request.model';
import { ResponseDTO } from 'app/core/models/generic/response-dto.model';

@Injectable({
  providedIn: 'root'
})
export class ToolService {

  public too: EventEmitter<any>;

  constructor(
    private apiService: ApiService,
    private _toastService: ToastrService,
  ) { }

  GetExchangeRateAsync(request: CambiarMonedaRequest): Observable<ResponseDTO> {
    return this.apiService.post('', request)
      .pipe(tap(data => data));
  }

  getUserTimeZone(): string {
    return Intl.DateTimeFormat().resolvedOptions().timeZone;
  }

  getDateTimeNow(): Date {
    return new Date();
  }

  getUserLocale(): string {
    return Intl.DateTimeFormat().resolvedOptions().locale;
  }

  getLocaleCurrencyCode(region: string): string {
    return getLocaleCurrencyCode(region) || '';
  }

  showWarning(message: string, title: string) {
    this._toastService.warning(message, title, { positionClass: 'toast-bottom-right' });
  }

  showError(message: string, title: string) {
    this._toastService.error(message, title, { positionClass: 'toast-bottom-right' });
  }

  showInfo(message: string, title: string) {
    this._toastService.info(message, title, { positionClass: 'toast-bottom-right' });
  }

  showSuccess(message: string, title: string) {
    this._toastService.success(message, title, { positionClass: 'toast-bottom-right' });
  }

  sortingActivoData = (data: any, sortHeaderId: string) => {
    switch (sortHeaderId) {
      case 'activarDesactivar':
        return data.activo ? Numeracion.Uno : Numeracion.Cero;
      default:
        return data[sortHeaderId];
    }
  };

  getStartDateTimeOfMonthddMMyyyyHHmmss(): Date {
    const today = DateTime.now().setZone('UTC');
    const timeZone = this.getUserTimeZone();
    const firstDayOfMonth = today.setZone(timeZone).startOf('month');
    const formattedFirstDayOfMonth = firstDayOfMonth.toFormat('dd/MM/yyyy HH:mm:ss');
    const DateTimeMonth = DateTime.fromFormat(formattedFirstDayOfMonth, 'dd/MM/yyyy HH:mm:ss', { zone: timeZone }).toJSDate();
    return DateTimeMonth;
  }

  getDateTimeNowddMMyyyyHHmmss(): Date {
    const today = DateTime.now().setZone('UTC');
    const timeZone = this.getUserTimeZone();
    const formattedDateTime = today.setZone(timeZone).toFormat('dd/MM/yyyy HH:mm:ss');
    const dateTimeNow = DateTime.fromFormat(formattedDateTime, 'dd/MM/yyyy HH:mm:ss', { zone: timeZone });
    const dateTimeTomorrow = dateTimeNow.plus({ days: 1 }).toJSDate();
    return dateTimeTomorrow;
  }

  getStringStartDateTimeOfMonthddMMyyyyHHmmss(): string {
    const today = DateTime.now().setZone('UTC');
    const timeZone = this.getUserTimeZone();
    const firstDayOfMonth = today.setZone(timeZone).startOf('month');
    const formattedFirstDayOfMonth = firstDayOfMonth.toFormat('dd/MM/yyyy HH:mm:ss');
    return formattedFirstDayOfMonth;
  }

  getStringDateTimeNowddMMyyyyHHmmss(): string {
    const today = DateTime.now().setZone('UTC');
    const timeZone = this.getUserTimeZone();
    const formattedDateTime = today.setZone(timeZone).toFormat('dd/MM/yyyy HH:mm:ss');
    return formattedDateTime;
  }

  getStartDateTimeOfYear(): Date {
    const today = DateTime.now().setZone('UTC');
    const timeZone = this.getUserTimeZone();
    const firstDayOfYear = today.setZone(timeZone).startOf('year');
    return firstDayOfYear.toJSDate();
  }

  getEndDateTimeOfYear(): Date {
    const today = DateTime.now().setZone('UTC');
    const timeZone = this.getUserTimeZone();
    const lastDayOfYear = today.setZone(timeZone).endOf('year');
    return lastDayOfYear.toJSDate();
  }

  isMobilSize(): boolean {
    return window.screen.width < 1100;
  }

} 
