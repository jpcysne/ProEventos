import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit{

  public eventos: any = [];
  public eventosFiltrados: any = [];
  widthImg: number = 150;
  marginImg: number = 2;
  showImg: boolean = true;
  private _filterList: string = '';

  public get filterList(){
    return this._filterList;
  }

  public set filterList(value: string){
    this._filterList = value;
    this.eventosFiltrados = this.filterList ? this.filterEvents(this.filterList) : this.eventos;
  }


  constructor(private http: HttpClient){}

  ngOnInit(): void {
    this.getEventos();
  }

  changeImage(){
    this.showImg = !this.showImg;
  }

  filterEvents(filterBy: string): any {
      filterBy = filterBy.toLocaleLowerCase();
      return this.eventos.filter(
        (evento: { tema: string; local: string}) => evento.tema.toLocaleLowerCase().indexOf(filterBy) !== -1
        || evento.local.toLocaleLowerCase().indexOf(filterBy) !== -1

      );
  }

  public getEventos(): void {
    this.http.get('https://localhost:7270/api/eventos').subscribe(
      response => {
        this.eventos = response;
        this.eventosFiltrados = this.eventos;
      },
      error => console.error(error)
    );
  }
}
