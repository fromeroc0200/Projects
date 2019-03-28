import { Component, OnInit } from '@angular/core';
import { DataService } from '../data.service';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
  /*agregamos como provider la clase de servicio y asi poderla inyectar en el contructor*/
  providers: [DataService]
})
export class HomeComponent implements OnInit {

  users$: object;

  /* Inyectamos el provider para ser usado dentro de la componente*/
  constructor(private myProviderData: DataService) { }

  ngOnInit() {
    this.myProviderData.getUsers().subscribe(myProviderData => this.users$ = myProviderData);
  }

}
