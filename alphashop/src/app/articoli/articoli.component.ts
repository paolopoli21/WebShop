import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ArticoliDataService } from '../services/articoli-data.service';

export class Articoli{
  constructor(
    public codart: string,
    public descrizione: string,
    public um: string,
    public pzcart: number,
    public peso: number,
    public prezzo: number,
    public isactive: boolean,
    public data: Date
  ){}
}

export class ApiMsg {

  constructor(
    public code: string,
    public message: string
  ) {}
}

@Component({
  selector: 'app-articoli',
  templateUrl: './articoli.component.html',
  styleUrls: ['./articoli.component.css']
})
export class ArticoliComponent implements OnInit {
  NumArt = 0;
  pagina = 1;
  righe = 10;
  apiMsg: ApiMsg;
  messaggio: string;

  filter: string = '';


  articoli : Articoli[];

  articolo: Articoli;


  constructor(private route:ActivatedRoute,private articoliService : ArticoliDataService) { }

  ngOnInit(): void {
    this.filter = this.route.snapshot.params['filter'];
    this.getArticoli(this.filter);
  }

  refresh(){
    this.getArticoli(this.filter);
  }

  public getArticoli(filter: string) {

    this.articoliService.getArticoliByCordArt(filter).subscribe(
      response => {
        this.articoli = [];
        //this.articoli = null;
        console.log('Ricerchiamo articoli per codice articolo con filtro ' + filter);

        this.articolo = response;
        console.log(this.articolo);

        this.articoli.push(this.articolo);
        
        this.NumArt = this.articoli.length
        console.log(this.articoli.length);
      },
       error =>{
         console.log(error.error);
         console.log("Ricerchiamo per descrizione con filtro" + filter);
         this.articoliService.getArticoliByDescription(filter).subscribe(
            response => {
              this.articoli = [];
              this.articoli = response;
              this.NumArt = this.articoli.length
              console.log(this.articoli.length);
            },
            error =>{
              console.log(error.error);
              console.log("Ricerchiamo per barcoe con filtro" + filter);
              this.articoliService.getArticoliByEan(filter).subscribe(
                response =>{
                  this.articoli = [];
                  this.articolo = response;
                  this.articoli.push(this.articolo);
                  this.NumArt = this.articoli.length
                  console.log(this.articoli.length);
                },
                error =>{
                  console.log(error.error);
                  this.articoli = [];
                }
              );
            }
         );

       }
    )
  }

  Elimina(CodArt: string) {
    console.log(`Eliminazione articolo ${CodArt}`);

    this.articoliService.delArticoloByCodArt(CodArt).subscribe(
      response => {
        console.log(response);
        this.apiMsg = response;
        this.messaggio = this.apiMsg.message;
        this.refresh();
      }
    )
    
  }
}
