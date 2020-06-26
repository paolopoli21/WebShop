import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class SalutiDataService {

  constructor(private httpClient: HttpClient) { }

  getSaluti(){
    //console.log("Saluti");
    return this.httpClient.get('http://localhost:8050/api/saluti/Paul');
  }
}
