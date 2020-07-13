import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {map} from 'rxjs/operators';
import { server, port } from '../app.constants';

export class AuthData{
  constructor(
    public codice: string,
    public messaggio: string
  )
  {}
}


@Injectable({
  providedIn: 'root'
})
export class AuthappService {

  constructor(private httpClient: HttpClient) { }

  // server = "localhost";
  // port = "5051";

  autentica(UserId, Password){
    if(UserId === "Nicola" && Password ==="123"){
      sessionStorage.setItem("Utente", UserId)
      return true;
    }
    else{
      return false;
    }
  }

  autenticaService(UserId: string, Passwor: string){
    let AuthString = "Basic" + window.btoa(UserId + ":" + Passwor)
    let headers = new HttpHeaders(
      {
        Authorization: AuthString
      }
    );

    return this.httpClient.get<AuthData>(`http://${server}:${port}/api/articoli/test`, {headers}).pipe(
      map(
        data => {
          sessionStorage.setItem("Utente", UserId);
          sessionStorage.setItem("AuthToken", AuthString);
          return data;
        }
      )
    );

  }

  loggerUser(){
    let utente = sessionStorage.getItem("Utente");
    return (utente != null)? utente: "";
  }

  getAuthToken(){
    if(this.loggerUser){
      return sessionStorage.getItem("AuthToken");
    }
    else{
      return "";
    }
  }

  isLogged(){
    let utente = sessionStorage.getItem("Utente");
    return (utente != null)? true: false;
  }

  clearAll(){
    sessionStorage.removeItem("Utente");
  }
}
