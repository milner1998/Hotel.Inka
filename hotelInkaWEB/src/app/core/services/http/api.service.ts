import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders, HttpResponse } from '@angular/common/http';
import { environment } from './../../../../environments/environment.prod';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private baseUrl: string;

  constructor(private httpClient: HttpClient) {
    this.baseUrl = environment.api_url;
  }

  private getHeaders(): HttpHeaders {
    const headers = new HttpHeaders()
      .set('Content-Type', 'application/json; charset=utf-8');
    return headers;
  }

  query(url: string, obj: any): Observable<any> {
    const params = new HttpParams({ fromObject: obj });
    const headers = this.getHeaders();
    return this.httpClient.get(`${this.baseUrl}${url}`, { params, headers });
  }

  get(url: string, params: HttpParams = new HttpParams()): Observable<any> {
    const headers = this.getHeaders();
    return this.httpClient.get(`${this.baseUrl}${url}`, { params, headers });
  }

  post(url: string, data: object = {}, applyDefaultConfig: boolean = false): Observable<any> {
    if (!applyDefaultConfig) {
      const headers = this.getHeaders();
      return this.httpClient.post(`${this.baseUrl}${url}`, JSON.stringify(data), { headers });
    } else {
      return this.httpClient.post(`${this.baseUrl}${url}`, data);
    }
  }

  postBlob(url: string, data: object = {}, applyDefaultConfig: boolean = false): Observable<Blob> {
    if (!applyDefaultConfig) {
      const headers = this.getHeaders(); // Configura tus headers si es necesario
      return this.httpClient.post(`${this.baseUrl}${url}`, data, { headers, responseType: 'blob' });
    } else {
      return this.httpClient.post(`${this.baseUrl}${url}`, data, { responseType: 'blob' });
    }
  }

  getRawText(url: string, params: HttpParams = new HttpParams()): Observable<any> {
    const headers = this.getHeaders().set('responseType', 'text');
    return this.httpClient.get(`${this.baseUrl}${url}`, { params, headers });
  }

  postRaw(url: string, data: object = {}): Observable<any> {
    return this.httpClient.post(`${this.baseUrl}${url}`, data);
  }

  put(url: string, data: object = {}): Observable<any> {
    const headers = this.getHeaders();
    return this.httpClient.put(`${this.baseUrl}${url}`, JSON.stringify(data), { headers });
  }

  delete(url: string): Observable<any> {
    const headers = this.getHeaders();
    return this.httpClient.delete(`${this.baseUrl}${url}`, { headers });
  }

  deleteRawResponse(url: string): Observable<any> {
    const headers = this.getHeaders().set('responseType', 'text');
    return this.httpClient.delete(`${this.baseUrl}${url}`, { headers });
  }

  getBlob(url: string): Observable<any> {
    return this.httpClient.get(`${this.baseUrl}${url}`, { observe: 'response', responseType: 'blob' });
  }

}
