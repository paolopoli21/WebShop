import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthappService {

  constructor() { }

  autentica(UserId, Password){
    if(UserId === "Nicola" && Password ==="123"){
      sessionStorage.setItem("Utente", UserId)
      return true;
    }
    else{
      return false;
    }
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
