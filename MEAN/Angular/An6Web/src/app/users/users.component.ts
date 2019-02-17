import { Component, OnInit } from '@angular/core';

/*Importamos los servicios y lo que necesita para API*/
import { DataService } from '../data.service';
import { Observable} from 'rxjs';


/*Agregamos el modulo de animación */
import {trigger, style, transition, animate, state, keyframes, query, stagger} from '@angular/animations';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.scss'],
  /*Agregamos la configuracion de las animaciones*/
  animations: [
    trigger('fadeInOut', [
      state('void', style({
        opacity: 0
      })),
      transition('void <=> *', animate(1000)),
    ]),
  ]
})
export class UsersComponent implements OnInit {

  users$: object;

  /*aplicamos inyection de dependencias agregando al constructor esto 'private data: DataService'*/
  constructor(private data: DataService) { }

  /* Este es el hooks ngOnInit*/
  ngOnInit() {
    /*Obtenemos toda la lista de usuarios*/
    this.data.getUsers().subscribe(
      data => this.users$ = data
    )
  }

}
