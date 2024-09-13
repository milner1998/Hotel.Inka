import { Injectable } from '@angular/core';
// import { AuthConfig, OAuthService } from 'angular-oauth2-oidc';

@Injectable({
  providedIn: 'root'
})
export class AuthGoogleService {

  // constructor(private oAuthservice: OAuthService) 
  // { 
    
  //   this.signInConfGoogle();
  // }

  // signInConfGoogle() {
  //   const config: AuthConfig = {
  //     issuer: 'https://accounts.google.com',
  //     strictDiscoveryDocumentValidation:false,
  //     clientId: '521028098770-u9in8qfhh06ip40v56sm8c385ihvdanu.apps.googleusercontent.com',
  //     redirectUri: window.location.origin  + '/seguridad',
  //     scope: 'openid profile email'
  //   } 
    
  //   this.oAuthservice.configure(config);
  //   this.oAuthservice.setupAutomaticSilentRefresh();
  //   this.oAuthservice.loadDiscoveryDocumentAndTryLogin();
    
  // }

  // sigIn(){

  //   this.oAuthservice.initLoginFlow();
  // }

  // logAut(){
  //   this.oAuthservice.logOut();
  // }

  // getProfile() {
  //   return this.oAuthservice.getIdentityClaims();
  // }

}
