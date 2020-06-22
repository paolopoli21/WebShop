import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { AuthappService } from './authapp.service';

@Injectable({
  providedIn: 'root'
})
export class RouteGuardService implements CanActivate {

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot){
    if(!this.BasicAuth.isLogged()){
      this.router.navigate(['login']);
      return false;
    }
    else{
      return true;
    }
  }

  constructor(private BasicAuth: AuthappService, private router: Router) { }
}
