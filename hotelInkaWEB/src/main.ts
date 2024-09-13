import { bootstrapApplication } from '@angular/platform-browser';
import { AppComponent } from 'app/app.component';
import { appConfig } from 'app/app.config';
import { appRoutes } from './app/app.routes';
import { provideRouter } from '@angular/router';
import { provideServiceWorker } from '@angular/service-worker';
import { isDevMode } from '@angular/core';
// import '@angular.common/locales/global/es-AR';
// import '@angular.common/locales/global/es-BO';
// import '@angular.common/locales/global/es-CL';
// import '@angular.common/locales/global/es-CO';
// import '@angular.common/locales/global/es-CR';
// import '@angular.common/locales/global/es-EC';
// import '@angular.common/locales/global/es-SV';
// import '@angular.common/locales/global/es-ES';
// import '@angular.common/locales/global/es-US';
// import '@angular.common/locales/global/es-GT';
// import '@angular.common/locales/global/es-GQ';
// import '@angular.common/locales/global/es-HN';
// import '@angular.common/locales/global/es-MX';
// import '@angular.common/locales/global/es-NI';
// import '@angular.common/locales/global/es-PA';
// import '@angular.common/locales/global/es-PY';
// import '@angular.common/locales/global/es-PE';
// import '@angular.common/locales/global/es-PR';
// import '@angular.common/locales/global/es-DO';
// import '@angular.common/locales/global/es-UY';
// import '@angular.common/locales/global/es-VE';

bootstrapApplication(AppComponent, appConfig)
    .catch(err => console.error(err));