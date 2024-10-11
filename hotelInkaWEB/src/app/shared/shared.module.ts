import { LOCALE_ID, NgModule } from '@angular/core';
import { CommonModule, CurrencyPipe, DatePipe, NgClass, NgFor, NgIf } from '@angular/common';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatGridListModule } from '@angular/material/grid-list';
import { LayoutModule } from '@angular/cdk/layout';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatDialogModule } from '@angular/material/dialog';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { DateAdapter, MAT_DATE_FORMATS, MAT_DATE_LOCALE, MAT_NATIVE_DATE_FORMATS, MatDateFormats, MatNativeDateModule, MatOptionModule, MatRippleModule, NativeDateAdapter } from '@angular/material/core';
import { HttpClientModule } from '@angular/common/http';
import { TranslocoModule } from '@ngneat/transloco';
import { MatMenuModule } from '@angular/material/menu';
import { MatTabsModule } from '@angular/material/tabs';
import { MatButtonToggleModule } from '@angular/material/button-toggle';
import { NgApexchartsModule } from 'ng-apexcharts';
import { RouterLink } from '@angular/router';
import { FuseAlertComponent } from '@fuse/components/alert';
import { MomentDateModule } from '@angular/material-moment-adapter';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatStepperModule } from '@angular/material/stepper';
import { MatRadioModule } from '@angular/material/radio';
import { ToolService } from 'app/core/services/tool/tool.service';
import { ToastrModule, ToastrService } from 'ngx-toastr';
import { NavigationService } from 'app/core/navigation/navigation.service';
import { MatSortModule } from '@angular/material/sort';
import { NgxMaterialTimepickerModule } from 'ngx-material-timepicker';
import { MatDatetimepickerModule, MatNativeDatetimeModule } from '@mat-datetimepicker/core';
import { MatMomentDateModule } from '@angular/material-moment-adapter';
import { MatMomentDatetimeModule } from '@mat-datetimepicker/moment';
import { TwoDigitDecimaNumberDirective } from './components/directiva/two-digit-decima-number.directive';
import { NgxColorsModule } from 'ngx-colors';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatDividerModule } from '@angular/material/divider';

// export const MY_FORMATS : MatDateFormats = {
//   parse: {
//     dateInput: 'DD/MM/YYYY',
//   },
//   display: {
//     dateInput: 'DD/MM/YYYY',
//     monthYearLabel: 'MMM YYYY',
//     dateA11yLabel: 'DD/MM/YYYY',
//     monthYearA11yLabel: 'MMMM YYYY',
//   },
// };

const BASE_MODULES =
  [
    CommonModule, MatSlideToggleModule, MatNativeDatetimeModule, MatMomentDateModule, MatMomentDatetimeModule,
    MatDatetimepickerModule, TranslocoModule, ReactiveFormsModule, FormsModule, HttpClientModule,
    MatRippleModule, MatCardModule, MatInputModule, MatMenuModule, MatTabsModule, MatSelectModule,
    MatButtonToggleModule, NgApexchartsModule, MatProgressBarModule, MatProgressSpinnerModule,
    MatGridListModule, LayoutModule, MatToolbarModule, MatSidenavModule, MatButtonModule,
    MatIconModule, MatListModule, MatTableModule, MatPaginatorModule, MatSortModule,
    MatDialogModule, MatSnackBarModule, MatTooltipModule, MatAutocompleteModule, MatDatepickerModule,
    NgxMaterialTimepickerModule, NgFor, NgIf, NgClass, MatNativeDateModule, CurrencyPipe,
    MomentDateModule, RouterLink, FuseAlertComponent, MatCheckboxModule, MatStepperModule, MatDividerModule,
    MatFormFieldModule, MatOptionModule, MatRadioModule, NgxColorsModule, ToastrModule.forRoot()
  ]

const COMPONENTS = [TwoDigitDecimaNumberDirective]

const PROVIDERS = [NavigationService, { provide: ToastrService, useClass: ToastrService }, DatePipe,
  {  
    provide: MAT_DATE_LOCALE,
    useFactory: (localeService: ToolService) => localeService.getUserLocale(),
    deps: [ToolService]
  },
  // {
  //   provide: MAT_DATE_FORMATS,
  //   useValue: MY_FORMATS
  // },
  // { provide: MAT_DATE_FORMATS, useValue: MAT_NATIVE_DATE_FORMATS }


]

@NgModule({
  declarations: [...COMPONENTS],
  imports: [BASE_MODULES],
  exports: [...COMPONENTS, BASE_MODULES],
  providers: [PROVIDERS, DatePipe, CurrencyPipe]
})

export class SharedModule { }
