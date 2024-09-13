import { AfterViewInit, Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ObtenerCatalogoHabitacionesDTO } from 'app/core/models/reserva/response/lista/obtener-catalogo-habitaciones-dto.model';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { MatDrawer } from '@angular/material/sidenav';
import { UntypedFormBuilder, UntypedFormGroup } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';
import { Subject } from 'rxjs';
import { MatDialog } from '@angular/material/dialog';
import { DictionaryInfo, Flags, Numeracion, OrigenPlataforma } from 'app/core/resource/dictionary.constants';
import { FuseValidators } from '@fuse/validators';
import { DictionaryErrors, DictionaryWarning } from 'app/core/resource/dictionaryError.constants';
import { ToolService } from 'app/core/services/tool/tool.service';
import { FuseConfirmationService } from '@fuse/services/confirmation';
import { ResponseDTO } from 'app/core/models/generic/response-dto.model';
import { ReservaService } from 'app/core/services/reserva/reserva.service';

@Component({
  selector: 'app-lista-reserva-page',
  standalone: false,
 
  templateUrl: './lista-reserva-page.component.html',
  styleUrl: './lista-reserva-page.component.scss'
})
export class ListaReservaPageComponent  implements OnInit, AfterViewInit, OnDestroy {
 
  public allCatalogoHabitacionesDataSource: ObtenerCatalogoHabitacionesDTO[];

  public disabledBtnNuevo: boolean = false;
  public disabledAcciones: boolean = false;
  public disabledBuscar: boolean = false;

  public textoResultadoTable: string = "";

  @ViewChild('listaCatalogoHabitacionesTable', { read: MatSort }) private listaCatalogoHabitacionesTableMatSort: MatSort;
  @ViewChild(MatPaginator) private _paginator: MatPaginator;
 

  filtroListaIngresoForm: UntypedFormGroup;

  public pageSlice: MatTableDataSource<ObtenerCatalogoHabitacionesDTO> = new MatTableDataSource();
  public allIngresosDataSource: MatTableDataSource<ObtenerCatalogoHabitacionesDTO> = new MatTableDataSource();
  public catalogoTableColumns: string[] = ['id', 'numHabitacion', 'tipoHabitacion', 'capacidad',  'precioxNoche', 'descripcionHabitacion', 'estadoHabitacion'];
  private _unsubscribeAll: Subject<any> = new Subject<any>();
 
  constructor(
      private _reservaService: ReservaService,
      private _toolService: ToolService) {
  }

  ngOnInit() {
    this.GetAllIngresoByFilterAsync();
      this.formFiltros();
 
  }

  ngAfterViewInit() {
      this.pageSlice.sortingDataAccessor = this.sortingActivoData;
 
      this.pageSlice.paginator = this._paginator;
  }

  formatCurrency(amount: number, currencySymbol: string): string {
      return `${currencySymbol}${amount.toFixed(2)}`;
  }

  ngOnDestroy() {

      this._unsubscribeAll.next(null);
      this._unsubscribeAll.complete();
  }

  formFiltros() {
    //   this.filtroListaIngresoForm = this._formBuilder.group({
    //       nombre: [''],
    //       fechaIngresoInicio: [this._toolService.getStartDateTimeOfYear()],
    //       fechaIngresoFin: [this._toolService.getEndDateTimeOfYear()],
    //       montoInicio: [''],
    //       montoFin: [''],
    //       categoria: [''],
    //   });
  }

  GetAllIngresoByFilterAsync() {
    debugger;
    this._reservaService.ObtenerCalogoHabitacionesAsync().subscribe((response: ObtenerCatalogoHabitacionesDTO[]) => {
        debugger;
        this.allIngresosDataSource.data = response;
        this.pageSlice.data = [];
        if (this.allIngresosDataSource.data.length > Numeracion.Cero) {
            this.setPageSlice(this.allIngresosDataSource.data);
            this.disabledBuscar = Flags.False;
        
            return;
        }
        this.textoResultadoTable = DictionaryInfo.NoDataTable;
        this.disabledBuscar = Flags.False;
 
    }, err => {
        this._toolService.showError(DictionaryErrors.Transaction, DictionaryErrors.Tittle);
        this.disabledBuscar = Flags.False;
        console.log(err);
     
    });
}
 
  trackByFn(index: number, item: any): any {
      return item.id || index;
  }

  sortingActivoData = (data: any, sortHeaderId: string) => {
      return this._toolService.sortingActivoData(data, sortHeaderId);
  };

  onPageChange(event: any): void {
      const startIndex = event.pageIndex * event.pageSize;
      let endIndex = startIndex + event.pageSize;
      if (endIndex > this.allIngresosDataSource.data.length) {
          endIndex = this.allIngresosDataSource.data.length;
      }

      this.pageSlice.data = this.allIngresosDataSource.data.slice(startIndex, endIndex);
  }

  setPageSlice(data) {
      this.pageSlice.data = data.slice(Numeracion.Cero, Numeracion.Diez);
      if (this._paginator) {
          this._paginator.pageIndex = Numeracion.Cero;
          this._paginator.pageSize = Numeracion.Diez;
      }
  }

  isMobilSize(): boolean {
      return this._toolService.isMobilSize();
  }
 
}
