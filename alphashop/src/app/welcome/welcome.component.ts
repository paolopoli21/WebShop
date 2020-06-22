import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-welcome',
  templateUrl: './welcome.component.html',
  styleUrls: ['./welcome.component.css']
})
export class WelcomeComponent implements OnInit {
  saluti = 'Benvenuti nel sito alphatashop';
  titolo2 = 'Selezione un articolo da inserire';

  messaggio = "Sono il componente welcome";

  utente = "";

  constructor(private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.utente = this.route.snapshot.params['userid'];
  }

}
