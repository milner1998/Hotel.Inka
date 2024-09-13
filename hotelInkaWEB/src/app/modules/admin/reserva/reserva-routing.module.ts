import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListaReservaPageComponent } from './pages/lista-page/lista-reserva-page.component';

const routes: Routes = [
  {
    path: 'reserva',
    children: [
      { path: 'lista', component: ListaReservaPageComponent, data: { title: 'Lista Reserva' }},
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ReservaRoutingModule { }
