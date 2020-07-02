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

@Component({
  selector: 'app-articoli',
  templateUrl: './articoli.component.html',
  styleUrls: ['./articoli.component.css']
})
export class ArticoliComponent implements OnInit {
  NumArt = 0;
  pagina = 1;
  righe = 10;
  filter: string = '';
  // articoli = [
  //   new Articoli('014600301','BARILLA FARINA 1 KG','PZ',24,1,1.09,true,new Date()),
  //   new Articoli('013500121','BARILLA PASTA GR.500 N.70 1/2 PENNE','PZ',30,0.5,1.3,true,new Date()),
  //   new Articoli('007686402','FINDUS FIOR DI NASELLO 300 GR','PZ',8,0.3,6.46,true,new Date()),
  //   new Articoli('057549001','FINDUS CROCCOLE 400 GR','PZ',12,0.4,5.97,true,new Date())
  // ];

  articoli : Articoli[];


  constructor(private route:ActivatedRoute,private articoliService : ArticoliDataService) { }

  ngOnInit(): void {
    this.filter = this.route.snapshot.params['filter'];
    this.getArticoli(this.filter);
  }

  refresh(){
    this.getArticoli(this.filter);
  }

  public getArticoli(filter: string) {

    this.articoliService.getArticoli(filter).subscribe(
      response => {

        //this.articoli = null;
        console.log('Ricerchiamo articoli con filtro ' + filter);

        this.articoli = response;
        console.log(this.articoli);
        
        this.NumArt = this.articoli.length
        console.log(this.articoli.length);
      } 
    )
  }
}
