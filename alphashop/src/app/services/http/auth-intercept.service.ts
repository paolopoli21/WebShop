import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AuthInterceptService implements HttpInterceptor {

  constructor() { }

  intercept(request: HttpRequest<any>, next: HttpHandler){
    let UserId ="Admin";
    let Password = "VerySecretPwd";
    let AuthHeader = "Basic " + window.btoa(UserId + ":" + Password);

    request = request.clone(
      {
        setHeaders :
        {
          Authorization: AuthHeader
        }
      }
    );
    return next.handle(request);
  }
}
