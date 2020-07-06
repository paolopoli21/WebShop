import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Articoli, Iva, FamAss } from '../articoli/articoli.component';
import { ArticoliDataService } from '../services/articoli-data.service';

@Component({
  selector: 'app-newart',
  templateUrl: './newart.component.html',
  styleUrls: ['./newart.component.css']
})
export class NewartComponent implements OnInit {

  constructor(private route: ActivatedRoute, private articoliService: ArticoliDataService) { }

  CodArt : string = "";
  articolo: Articoli;

  Iva: Iva;
  Cat: FamAss;

  ngOnInit(): void {
    this.CodArt = this.route.snapshot.params['codart'];

    this.articoliService.getArticoliByCordArt(this.CodArt).subscribe(
      response => {
        this.articolo = response;
        console.log(this.articolo);
      },
      error => {
        console.log(error.error.messaggio);
      }
    );

    this.articoliService.getIva().subscribe(
      response =>{
        this.Iva = response;
        console.log(response);
      },
      error =>{
        console.log(error.error);
      }
    );

    this.articoliService.getCat().subscribe(
      response =>{
        this.Cat = response;
        console.log(response);
      },
      error =>{
        console.log(error.error);
      }
    );

  }

}
