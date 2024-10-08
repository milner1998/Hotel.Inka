import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminRoutingModule } from './admin-routing.module';
import { SharedModule } from 'app/shared/shared.module';

@NgModule({
  declarations: [],
  imports: [
    CommonModule, 
    AdminRoutingModule,
    SharedModule
  ],
  exports: [
    AdminRoutingModule,
  ]
})
export class AdminModule { }
