import { DatePipe } from '@angular/common';
import { AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';
import { Flags, Numeracion } from '../resource/dictionary.constants';

declare global {
    interface String {
        toFloat(): number;
        toDate(): Date;
    }

    interface Number {
        toFormat(): string;
    }

    interface Date {
        toFormat(format: string);
        addDays(days: number, useThis?: boolean): Date;
        isToday(): boolean;
        clone(): Date;
        isAnotherMonth(date: Date): boolean;
        isWeekend(): boolean;
        isSameDate(date: Date): boolean;
        getStringDate(): string;
    }

    function isEmpty(value: any): boolean;
}

export const UtilExtension = {

    tryParseDate(fecha: Date, format: string): string {
        try {
            const converted = this.datePipe.transform(fecha, format);
            return converted != null ? converted : '';
        } catch (e) {
            return '';
        }
    },

    isEqualString(firstVal: string, secondVal: string): boolean {
        return firstVal === secondVal;
    },

    isValidCorreo(correo: string): boolean {

        if (correo == '') { return null };
        const email = correo;
        const emailPattern = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
        const isValid = emailPattern.test(email);
        return isValid ? true : false;

    },

    isEmptyOrNull(valor: any): boolean {
        if (valor == null) {
            return true;
        }

        if (typeof valor === 'string' && valor.trim() === '') {
            return true;
        }

        return false;
    },

    isValidNombreApellido(nombre: string): boolean {
        const regexNombre = /^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$/;
        if (!regexNombre.test(nombre)) {
            return false;
        }

        const longitudNombre = nombre.length;
        const longitudMinima = Numeracion.Tres;
        const longitudMaxima = Numeracion.Cien;

        if (longitudNombre < longitudMinima || longitudNombre > longitudMaxima) {
            return false;
        }

        return true;
    },

    isValidFechaNacimiento(fechaNacimiento: string): boolean {
        const fechaNac = new Date(fechaNacimiento);
        const fechaActual = new Date();

        const edadMinima = Numeracion.Quince;
        const edad = fechaActual.getFullYear() - fechaNac.getFullYear();
        if (edad < edadMinima) {
            return false;
        }
        return true;
    },

    isValidMinTwelveLength(input): boolean {
        if (input.length < Numeracion.Dos) { return Flags.False; }
        return Flags.True;
    },

    isValidMinTwoLength(input): boolean {
        if (input.length < Numeracion.Dos) { return Flags.False; }
        return Flags.True;
    },

    isValidMaxHundredLength(input): boolean {
        if (input.length > Numeracion.Cien) { return Flags.False; }
        return Flags.True;
    },

    isValidFiftyLength(input): boolean {
        if (input.length > Numeracion.Cincuenta) { return Flags.False; }
        return Flags.True;
    },

    isValidTwoHundredFiftyLength(input): boolean {
        if (input.length > Numeracion.DoscientosCincuenta) { return Flags.False; }
        return Flags.True;
    },

    isValidContrasenia(password: string): boolean {

        const minLength = 12;
        const maxLength = 80;

        if (password.length < minLength || password.length > maxLength) {
            return false;
        }

        if (!/[A-Z]/.test(password)) {
            return false;
        }

        if (!/[a-z]/.test(password)) {
            return false;
        }

        if (!/\d/.test(password)) {
            return false;
        }

        if (!/[!@#$%^&*(),.?":{}|<>]/.test(password)) {
            return false;
        }

        return true;
    },

    init(datePipe: DatePipe) {
        UtilExtension.configureString();
        UtilExtension.configureDate(datePipe);
        UtilExtension.configureNumber();
    },

    configureString() {
        String.prototype.toFloat = function (defaultValue = 0) {
            if (!isEmpty(this) && !isNaN(this)) {
                return parseFloat(this);
            }
            return defaultValue;
        };
        String.prototype.toDate = function () {
            if (isEmpty(this)) {
                return new Date();
            }

            const str = this.split('/');
            const year = Number(str[2]);
            const month = Number(str[1]) - 1;
            const date = Number(str[0]);
            return new Date(year, month, date);
        };
    },

    configureDate(datePipe: DatePipe) {
        Date.prototype.toFormat = function (format) {
            return datePipe.transform(this, format);
        };

        Date.prototype.addDays = function (days: number): Date {
            if (!days) { return this; }
            const date = this;
            date.setDate(date.getDate() + days);

            return date;
        };

        Date.prototype.isToday = function (): boolean {
            const today = new Date();
            return this.isSameDate(today);
        };

        Date.prototype.clone = function (): Date {
            return new Date(+this);
        };

        Date.prototype.isAnotherMonth = function (date: Date): boolean {
            return date && this.getMonth() !== date.getMonth();
        };

        Date.prototype.isWeekend = function (): boolean {
            return this.getDay() === 0 || this.getDay() === 6;
        };

        Date.prototype.isSameDate = function (date: Date): boolean {
            return date && this.getFullYear() === date.getFullYear() && this.getMonth() === date.getMonth() && this.getDate() === date.getDate();
        };

        Date.prototype.getStringDate = function (): string {
            const monthNames = ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Setiembre', 'Octubre', 'Noviembre', 'Diciembre'];
            const today = new Date();
            if (this.getMonth() === today.getMonth() && this.getDay() === today.getDay()) {
                return 'Hoy';
            } else if (this.getMonth() === today.getMonth() && this.getDay() === today.getDay() + 1) {
                return 'Mañana';
            } else if (this.getMonth() === today.getMonth() && this.getDay() === today.getDay() - 1) {
                return 'Ayer';
            } else {
                return this.getDay() + ' de ' + this.monthNames[this.getMonth()] + ' de ' + this.getFullYear();
            }
        };
    },

    configureNumber() {
        Number.prototype.toFormat = function () {
            return new Intl.NumberFormat('en-US').format(this);
        };
    },

};

export const onlyLettersForm: ValidatorFn = (control: AbstractControl): { [key: string]: any } | null => {
    const valor = control.value;
    const soloLetras = /^[a-zA-ZáéíóúüñÁÉÍÓÚÜÑ\s'-]*$/.test(valor);
    return soloLetras ? null : { 'soloLetras': true };
};

export const onlyNumbersForm: ValidatorFn = (control: AbstractControl): { [key: string]: any } | null => {
    const valor = control.value;
    const soloNumeros = /^[0-9]+$/.test(valor);
    return soloNumeros ? null : { 'soloNumeros': true };
};

export class CommonValidators {

    static invalidEmail(): ValidatorFn {
        return (control: AbstractControl): ValidationErrors | null => {
            if (control.value == '') { return null };
            const email = control.value;
            const emailPattern = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
            const isValid = emailPattern.test(email);
            return isValid ? null : { invalidEmail: { value: control.value } };

        };
    }

    static onlyNumbersForm(): ValidatorFn {
        return (control: AbstractControl): ValidationErrors | null => {
            if (control.value == '') { return null; }
            const valor = control.value;
            const soloNumeros = /^[0-9]*$/.test(valor);
            return soloNumeros ? null : { onlyNumbersForm: { value: control.value } };
        };
    }

    static validFechaNacimientoForm(): ValidatorFn {
        return (control: AbstractControl): ValidationErrors | null => {
            if (control.value == '') { return null };
            const dateValue = control.value;

            const fechaActual = new Date();
            const edadMinima = 15;
            const edad = fechaActual.getFullYear() - new Date(dateValue).getFullYear();

            if (edad < edadMinima) {
                return { 'edadMinimaNoCumplida': true };
            }
        };
    }

    static validDateForm(): ValidatorFn {
        return (control: AbstractControl): ValidationErrors | null => {
            if (control.value == '') { return null };
            const dateValue = control.value;
            const isValidDate = !isNaN(new Date(dateValue).getTime());

            if (!isValidDate) {
                return { 'fechaInvalida': true };
            }
        };
    }

}

