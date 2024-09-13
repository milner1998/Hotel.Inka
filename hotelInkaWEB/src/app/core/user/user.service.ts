import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { User } from 'app/core/user/user.types';
import { map, Observable, ReplaySubject, tap } from 'rxjs';
import { UsuarioLoginDTO } from '../models/auth/response/usuario-inicia-sesion-request.model';

@Injectable({providedIn: 'root'})
export class UserService
{
    private _httpClient = inject(HttpClient);
    private _user: ReplaySubject<UsuarioLoginDTO> = new ReplaySubject<UsuarioLoginDTO>(1);

    // -----------------------------------------------------------------------------------------------------
    // @ Accessors
    // -----------------------------------------------------------------------------------------------------

    /**
     * Setter & getter for user
     *
     * @param value
     */
    set user(value: UsuarioLoginDTO)
    {
        // Store the value
        this._user.next(value);
    }

    get user$(): Observable<UsuarioLoginDTO>
    {
        return this._user.asObservable();
    }

    // -----------------------------------------------------------------------------------------------------
    // @ Public methods
    // -----------------------------------------------------------------------------------------------------

    /**
     * Get the current signed-in user data
     */
    get(): Observable<UsuarioLoginDTO>
    {
        return this._httpClient.get<UsuarioLoginDTO>('api/common/user').pipe(
            tap((user) =>
            {
                this._user.next(user);
            }),
        );
    }

    /**
     * Update the user
     *
     * @param user
     */
    update(user: UsuarioLoginDTO): Observable<any>
    {
        return this._httpClient.patch<UsuarioLoginDTO>('api/common/user', {user}).pipe(
            map((response) =>
            {
                this._user.next(response);
            }),
        );
    }
}
