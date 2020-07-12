import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {map} from 'rxjs/operators';

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

  server = "localhost";
  port = "5051";

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
    let headers = new HttpHeaders(
      {
        Authorization: "Basic" + window.btoa(UserId + ":" + Passwor)
      }
    );

    return this.httpClient.get<AuthData>(`http://${this.server}:${this.port}/api/articoli/test`, {headers}).pipe(
      map(
        data => {
          sessionStorage.setItem("Utente", UserId);
          return data;
        }
      )
    );

  }

  loggerUser(){
    let utente = sessionStorage.getItem("Utente");
    return (utente != null)? utente: "";
  }

  isLogged(){
    let utente = sessionStorage.getItem("Utente");
    return (utente != null)? true: false;
  }

  clearAll(){
    sessionStorage.removeItem("Utente");
  }
}
