import { Injectable } from '@angular/core';
import { Articoli } from '../articoli/articoli.component';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ArticoliDataService {
  server = "localhost";
  port = "5051";

  constructor(private httpClient:HttpClient) { }

  getArticoliByDescription(descrizione : string){
    return this.httpClient.get<Articoli[]>(`http://${this.server}:${this.port}/api/articoli/cerca/descrizione/${descrizione}`); //ALT + 0096 | ALT GR + '
  }

  getArticoliByCordArt(codart: string){
    return this.httpClient.get<Articoli>(`http://${this.server}:${this.port}/api/articoli/cerca/codice/${codart}`); //ALT + 0096 | ALT GR + '
  }

  getArticoliByEan(barcode: string){
    return this.httpClient.get<Articoli>(`http://${this.server}:${this.port}/api/articoli/cerca/ean/${barcode}`); //ALT + 0096 | ALT GR + '
  }

}
