import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Articoli } from '../articoli/articoli.component';
import { ArticoliDataService } from '../services/articoli-data.service';

@Component({
  selector: 'app-newart',
  templateUrl: './newart.component.html',
  styleUrls: ['./newart.component.css']
})
export class NewartComponent implements OnInit {

  constructor(private route: ActivatedRoute, private articoliService: ArticoliDataService) { }

  CodArt : String = "";
  articolo: Articoli;

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

  }

}
