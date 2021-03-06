import { Injectable } from '@angular/core';
import { Articoli, ApiMsg, Iva, FamAss } from '../articoli/articoli.component';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { server, port } from '../app.constants';

@Injectable({
  providedIn: 'root'
})
export class ArticoliDataService {
  // server = "localhost";
  // port = "5051";

  constructor(private httpClient:HttpClient) { }

  // getBasicAutHeader(){
  //   let UserId ="Nicola";
  //   let Password = "123Stella";
  //   let retVal = "Basic " + window.btoa(UserId + ":" + Password);
  //   return retVal;
  // }

  getArticoliByDescription(descrizione : string){
    // let headers = new HttpHeaders(
    //   {Authorization: this.getBasicAutHeader()}
    // );
    return this.httpClient.get<Articoli[]>(`http://${server}:${port}/api/articoli/cerca/descrizione/${descrizione}`); //ALT + 0096 | ALT GR + '
  }

  getArticoliByCordArt(CodArt: string){
    return this.httpClient.get<Articoli>(`http://${server}:${port}/api/articoli/cerca/codice/${CodArt}`); //ALT + 0096 | ALT GR + '
  }

  getArticoliByEan(barcode: string){
    return this.httpClient.get<Articoli>(`http://${server}:${port}/api/articoli/cerca/ean/${barcode}`); //ALT + 0096 | ALT GR + '
  }
  
  getIva(){
    return this.httpClient.get<Iva>(`http://${server}:${port}/api/iva`); //ALT + 0096 | ALT GR + '
  }

  getCat(){
    return this.httpClient.get<FamAss>(`http://${server}:${port}/api/cat`); //ALT + 0096 | ALT GR + '
  }

  delArticoloByCodArt(codart: string){
    return this.httpClient.delete<ApiMsg>(`http://${server}:${port}/api/articoli/elimina/${codart}`); //ALT + 0096 | ALT GR + '
  }

  updArticolo(articolo: Articoli) {
    return this.httpClient.put<ApiMsg>(`http://${server}:${port}/api/articoli/modifica`, articolo);
  }

  insArticolo(articolo: Articoli){
    return this.httpClient.post<ApiMsg>(`http://${server}:${port}/api/articoli/inserisci`, articolo);
  }

}
