import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit{

  public eventos: any;

  constructor(private http: HttpClient){}

  ngOnInit(): void {
    this.getEventos();
  }

  public getEventos(): void {
    this.http.get('https://localhost:7270')


    this.eventos = [
      {
        Tema: 'Angular',
        Local: 'Belo Horizonte'
      },
      {
        Tema: '.Net 5',
        Local: 'Sao Paulo'
      },
      {
        Tema: 'Angular e Suas Novidades',
        Local: 'Rio de Janeiro'
      }
    ];
  }
}
