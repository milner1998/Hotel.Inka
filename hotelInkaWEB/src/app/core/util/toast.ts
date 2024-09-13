import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class ToastTool {

  constructor(private toastr: ToastrService) {}
 
  success(mensaje: string) {
    this.toastr.success(mensaje);
  }

  warning(mensaje: string) {
    this.toastr.warning(mensaje);
  }

  error(mensaje: string) {
    this.toastr.error(mensaje);
  }
}