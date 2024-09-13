import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ReservaRoutingModule } from './reserva-routing.module';
import { SearchComponent } from 'app/layout/common/search/search.component';
import { ListaReservaPageComponent } from './pages/lista-page/lista-reserva-page.component';
import { SharedModule } from 'app/shared/shared.module';

const BASE_MODULES = [CommonModule, SharedModule, ReservaRoutingModule];
const BASE_COMPONENTS = [
  ListaReservaPageComponent,
 
];


// const LISTA = [RegistroIngresoPageComponent,
//   ModificaIngresoPageComponent,
//   DetalleIngresoPageComponent
// ]

@NgModule({
  declarations: [...BASE_COMPONENTS],
  imports: [BASE_MODULES],
  exports: [BASE_MODULES],
})
export class ReservaModule { }
