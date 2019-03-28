import { Component, OnInit } from '@angular/core';
import { HijoComponent } from '../hijo/hijo.component';

@Component({
  selector: 'app-padre',
  templateUrl: './padre.component.html',
  styleUrls: ['./padre.component.scss'],

})
export class PadreComponent implements OnInit {

  private nombreHijo = 'Esteban';
  textoHijo = 'esta gritando?';

  constructor() { }

  ngOnInit() {
    this.nombreHijo = 'Fercho';
  }

  estaGritandoHijo(esta: boolean) {
    console.log('disparo');
    this.textoHijo = 'El hijo ' + (esta ? 'esta' : 'no esta') + ' gritando';
 }

}
