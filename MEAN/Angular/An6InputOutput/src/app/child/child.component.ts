import { Component, OnInit } from '@angular/core';
/*Se importa el modulo Input */
import { Input } from '@angular/core';
import { Output, EventEmitter } from '@angular/core';
@Component({
  selector: 'app-child',
  templateUrl: './child.component.html',
  styleUrls: ['./child.component.scss']
})
export class ChildComponent implements OnInit {

  cData = 'I am child component';
  /*Obtiene del el valor cpData del componente padre*/
  @Input() cpData: string;

  /* */
  @Output() msgEvent = new EventEmitter<string>();
  constructor() { }

  ngOnInit() {
  }

  emitChild() {
    /*Emite el valor de cData asigado en el child component*/
    this.msgEvent.emit(this.cData);
  }

}
