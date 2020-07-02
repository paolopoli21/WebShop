import { Injectable } from '@angular/core';
import { Articoli } from '../articoli/articoli.component';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ArticoliDataService {

  constructor(private httpClient:HttpClient) { }

  getArticoli(descrizione : string){
    return this.httpClient.get<Articoli[]>(`http://localhost:5051/api/articoli/cerca/descrizione/${descrizione}`); //ALT + 0096 | ALT GR + '
  }

}
