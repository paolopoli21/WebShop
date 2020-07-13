import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler } from '@angular/common/http';
import { AuthappService } from '../authapp.service';

@Injectable({
  providedIn: 'root'
})
export class AuthInterceptService implements HttpInterceptor {

  constructor(private BasicAuth: AuthappService) { }

  intercept(request: HttpRequest<any>, next: HttpHandler){
    // let UserId ="Admin";
    // let Password = "VerySecretPwd";
    // let AuthHeader = "Basic " + window.btoa(UserId + ":" + Password);

    let AuthToken = this.BasicAuth.getAuthToken();
    let User = this.BasicAuth.loggerUser();
    if(AuthToken && User){
      request = request.clone(
        {
          setHeaders :
          {
            Authorization: AuthToken
          }
        }
      );
      return next.handle(request);
    }
  }
}
