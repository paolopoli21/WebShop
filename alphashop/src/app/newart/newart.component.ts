import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Articoli, Iva, FamAss, ApiMsg } from '../articoli/articoli.component';
import { ArticoliDataService } from '../services/articoli-data.service';

@Component({
  selector: 'app-newart',
  templateUrl: './newart.component.html',
  styleUrls: ['./newart.component.css']
})
export class NewartComponent implements OnInit {
  CodArt : string = "";
  articolo: Articoli;
  apiMsg: ApiMsg;
  Conferma: string;
  Errore: string;
  Iva: Iva;
  Cat: FamAss;
  IsModifica: boolean = false;
  Erro403Msg: string ="Non è autorizzato per eseguire modifiche agli articoli!";

  constructor(private route: ActivatedRoute,private router: Router ,private articoliService: ArticoliDataService) { }

  ngOnInit(): void {
    this.articolo = new Articoli("","", "",0,0,0, false, new Date(), 0,0,0)
    this.CodArt = this.route.snapshot.params['codart'];
    
    if(this.CodArt != "-1"){
      this.IsModifica = true;
      this.articoliService.getArticoliByCordArt(this.CodArt).subscribe(
        response => {
          this.articolo = response;
          console.log("Articolo: " + this.articolo);
        },
        error => {
          console.log(error.error.messaggio);
        }
      );
    }

    this.articoliService.getIva().subscribe(
      response =>{
        this.Iva = response;
        //console.log(response);
      },
      error =>{
        console.log(error.error);
      }
    );

    this.articoliService.getCat().subscribe(
      response =>{
        this.Cat = response;
        //console.log(response);
      },
      error =>{
        console.log(error.error);
      }
    );

  }

  abort(){
    this.router.navigate(['articoli', this.CodArt]);
  }

  salva(){
    this.Conferma = "";
    this.Errore = "";
    if(this.IsModifica){
      this.articoliService.updArticolo(this.articolo).subscribe(
        response =>{
          console.log(response);
          this.apiMsg = response;
          this.Conferma = this.apiMsg.message;
          console.log(this.Conferma);
        },
        error=>{
          this.apiMsg = error;
          this.Errore = this.apiMsg.message;
          console.log(this.Errore);
        }
      );
    }
    else{
      this.articoliService.insArticolo(this.articolo).subscribe(
        response =>{
          debugger;
          console.log(response);
          this.apiMsg = response;
          this.Conferma = this.apiMsg.message;
          console.log(this.Conferma);
          this.router.navigate(['newart', this.articolo.codArt]);
        },
        error=>{
          debugger;
          this.apiMsg = error;
          this.Errore = (error.status ===403) ? this.Erro403Msg: this.apiMsg.message;
          console.log(this.Errore);
        }
      );
    }
  }

}
