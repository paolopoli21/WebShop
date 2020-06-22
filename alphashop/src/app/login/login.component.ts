import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthappService } from '../services/authapp.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  userid = ""
  password = "";
  autenticato = false;
  consentito = false;
  errorMsg = "Spiacente la userid o la password sono errati!";
  infoMsg = "Accesso consentito"

  constructor(private route : Router, private BasicAuth: AuthappService) { }

  ngOnInit(): void {
  }

  gestAut(){
    if (this.BasicAuth.autentica(this.userid, this.password)){
       this.autenticato = true;
       this.route.navigate(['welcome', this.userid])
    }
    else{
       this.autenticato = false;
       this.consentito = false;
    }

    // if(this.userid === "Nicola" && this.password ==="123"){
    //   this.autenticato = true;
    //   this.route.navigate(['welcome', this.userid])
    //   this.consentito = true;
    // }
    // else{
    //   this.autenticato = false;
    //   this.consentito = false;
    // }
  }
}
