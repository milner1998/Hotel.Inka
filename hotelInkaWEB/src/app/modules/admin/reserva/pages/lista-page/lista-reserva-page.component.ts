import { AfterViewInit, Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { ObtenerCatalogoHabitacionesDTO } from 'app/core/models/reserva/response/lista/obtener-catalogo-habitaciones-dto.model';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';
import { Subject } from 'rxjs';
import { Flags, Numeracion } from 'app/core/resource/dictionary.constants';
import { DictionaryErrors } from 'app/core/resource/dictionaryError.constants';
import { ToolService } from 'app/core/services/tool/tool.service';
import { ReservaService } from 'app/core/services/reserva/reserva.service';
import { ObtenerClientePorDNIDTO } from 'app/core/models/reserva/response/lista/obtener-cliente-por-dni-dto.model';
import moment from 'moment';
import { ObtenerReservaxDNI } from 'app/core/models/reserva/response/lista/obtener-reserva-por-dni-dto.model';
import { ObtenerOrdenHospedajeXDNI } from 'app/core/models/reserva/response/Obtener-orden-hospedaje-x-dni';
import { ObtenerCatalogoXTipoDTO } from 'app/core/models/reserva/response/Obtener-catalogo-servicios-por-tipo';


@Component({
    selector: 'app-lista-reserva-page',
    standalone: false,

    templateUrl: './lista-reserva-page.component.html',
    styleUrl: './lista-reserva-page.component.scss'
})
export class ListaReservaPageComponent implements OnInit, AfterViewInit, OnDestroy {

    minDate = moment(new Date()).format('YYYY-MM-DD')
    maxDate = moment("2024-12-31").format('YYYY-MM-DD') 
    public allCatalogoHabitacionesDataSource: ObtenerCatalogoHabitacionesDTO[];

    public disabledBtnNuevo: boolean = false;
    public disabledAcciones: boolean = false;
    public disabledBuscar: boolean = false;
    public tieneDatos: boolean = false;

    public textoResultadoTable: string = "";

    public isCallingService: boolean = Flags.False;

    @ViewChild('listaCatalogoHabitacionesTable', { read: MatSort }) private listaCatalogoHabitacionesTableMatSort: MatSort;
    public clienteDetalleDataSource: MatTableDataSource<ObtenerClientePorDNIDTO> = new MatTableDataSource();

    @ViewChild(MatPaginator) private _paginator: MatPaginator;

    filtroListaClienteForm: UntypedFormGroup;
    filtroFechaForm: UntypedFormGroup;

    
    selected = 'option2';
 
    public pageSlicePersona: MatTableDataSource<ObtenerCatalogoXTipoDTO> = new MatTableDataSource();
     
    public pageSlice: MatTableDataSource<ObtenerCatalogoHabitacionesDTO> = new MatTableDataSource();
    
    public catalogoTableColumns: string[] = ['idServicio', 'nombreServicio', 'descripcionServicio' , 'precioServicio'];
    public catalogoHabitacionesTableColumns: string[] = ['numHabitacion', 'tipoHabitacion', 'capacidad', 'precioxNoche', 'descripcionHabitacion', 'estadoHabitacion'];
    private _unsubscribeAll: Subject<any> = new Subject<any>();

    constructor(
        private _formBuilder: UntypedFormBuilder,
        private _reservaService: ReservaService,
        private _toolService: ToolService) {
    }

    ngOnInit() {
     
        this.formFiltros();

    }
 
    onShowFormRegistrarDeudaDialog() {
        this.isCallingService = Flags.True;
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
        this.filtroListaClienteForm = this._formBuilder.group({
            dni: ['', Validators.required],
            nombreHuesped: [''],
            apellidoHuesped: [''],
            nroOrdenHospedaje: [''],
            fechaIngreso: [''],
            fechaSalida: [''],
            nroHabitacion: [''],
            tipoHabitacion: [''],

        });
 
        this.filtroFechaForm = this._formBuilder.group({
            fechaInicio: ['', Validators.required],
            fechaFin: ['', Validators.required],

        });

    }

    trackByFn(index: number, item: any): any {
        return item.id || index;
    }

    sortingActivoData = (data: any, sortHeaderId: string) => {
        return this._toolService.sortingActivoData(data, sortHeaderId);
    };


    setPageSlice(data) {
        this.pageSlice.data = data.slice(Numeracion.Cero, Numeracion.Diez);
        if (this._paginator) {
            this._paginator.pageIndex = Numeracion.Cero;
            this._paginator.pageSize = Numeracion.Diez;
        }
    }

    setPageSlicePersona(data) {
        this.pageSlicePersona.data = data.slice(Numeracion.Cero, Numeracion.Diez);
        if (this._paginator) {
            this._paginator.pageIndex = Numeracion.Cero;
            this._paginator.pageSize = Numeracion.Diez;
        }
    }

    isMobilSize(): boolean {
        return this._toolService.isMobilSize();
    }

    btnBuscar() {

        if(!this.filtroListaClienteForm.valid){return;}

        this.GetClienteByDNIAsync();
    }

    btnLimpiar() {
        this.filtroListaClienteForm.get('dni').setValue('');
        this.filtroListaClienteForm.get('nombreHuesped').setValue('');
        this.filtroListaClienteForm.get('apellidoHuesped').setValue('');
        this.filtroListaClienteForm.get('nroOrdenHospedaje').setValue('');
        this.filtroListaClienteForm.get('fechaIngreso').setValue('');
        this.filtroListaClienteForm.get('fechaSalida').setValue('');
        this.filtroListaClienteForm.get('nroHabitacion').setValue('');
        this.filtroListaClienteForm.get('tipoHabitacion').setValue('');
        this.pageSlicePersona.data = [];
        this.pageSlice.data = [];
        this.clienteDetalleDataSource.data = [];
        this.tieneDatos = false;
    }

    btnBuscarHabitaciones() {
        this.GetCatalogoHabitacionesAsync();
    }
 
    GetClienteByDNIAsync() {
   
        const txtDNI = this.filtroListaClienteForm.get('dni').value;

        this._reservaService.ObtenerOrdenHospedajeAsync(txtDNI).subscribe((response: ObtenerOrdenHospedajeXDNI) => {
  
             if(response){
                this.tieneDatos = true;
                this.filtroListaClienteForm.get('nombreHuesped').setValue(response.nombreHuesped);
                this.filtroListaClienteForm.get('apellidoHuesped').setValue(response.apellidoHuesped);
                this.filtroListaClienteForm.get('nroOrdenHospedaje').setValue(response.nroOrden);
                this.filtroListaClienteForm.get('fechaIngreso').setValue(response.fechaIngreso);
                this.filtroListaClienteForm.get('fechaSalida').setValue(response.fechaSalida);
                this.filtroListaClienteForm.get('nroHabitacion').setValue(response.nroHabitacion);
                this.filtroListaClienteForm.get('tipoHabitacion').setValue(response.tipoHabitacion);

                //this.GetReservaByDNIAsync(response.idHuesped)
                // this.pageSlicePersona.data.push(response);
          
                // this.setPageSlicePersona(this.pageSlicePersona.data);
                // this.disabledBuscar = Flags.False;
                return;
             }
             this.tieneDatos = false;
             this.filtroListaClienteForm.get('nombreHuesped').setValue('');
             this.filtroListaClienteForm.get('apellidoHuesped').setValue('');
             this.filtroListaClienteForm.get('nroOrdenHospedaje').setValue('');
             this.filtroListaClienteForm.get('correo').setValue('');
             this.pageSlicePersona.data = [];
             this.clienteDetalleDataSource.data = [];
             this._toolService.showWarning('No se encontró el cliente con el DNI ingresado', 'Advertencia')
 
        }, err => {
            this._toolService.showError(DictionaryErrors.Transaction, DictionaryErrors.Tittle);
            this.disabledBuscar = Flags.False;
            console.log(err);

        });
    }

    GetReservaByDNIAsync(tipo: number) {
   
        this._reservaService.ObtenerCatalogoXTipoAsync(tipo).subscribe((response: ObtenerCatalogoXTipoDTO) => {
             if(response){
 
                this.setPageSlicePersona(response);
                this.disabledBuscar = Flags.False;
                return;
             }
 
        }, err => {
            this._toolService.showError(DictionaryErrors.Transaction, DictionaryErrors.Tittle);
            this.disabledBuscar = Flags.False;
            console.log(err);

        });
    }

    GetCatalogoHabitacionesAsync() {
        this._reservaService.ObtenerCalogoHabitacionesAsync().subscribe((response: ObtenerCatalogoHabitacionesDTO[]) => {

            this.pageSlice.data =response;
            if (this.pageSlice.data.length > Numeracion.Cero) {
                this.setPageSlice(this.pageSlice.data);
                this.disabledBuscar = Flags.False;
               
                return;
            }
        
            this.disabledBuscar = Flags.False;
 
        }, err => {
            this._toolService.showError(DictionaryErrors.Transaction, DictionaryErrors.Tittle);
            this.disabledBuscar = Flags.False;
            console.log(err);

        });
    }

}
