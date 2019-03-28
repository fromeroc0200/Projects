
/*Agregamos el modulo Input*/
import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-address-card',
  templateUrl: './address-card.component.html',
  styleUrls: ['./address-card.component.scss']
})
export class AddressCardComponent implements OnInit {
  user: any;
  /*Obtenemos el valor de atributo name*/
  @Input('name') userName: string;

  constructor() { }


  ngOnInit() {
    this.user = {
      /*Asignamos el valor de entrada de name*/
      name: this.userName,
      title: 'Test angular Input',
      address: '859 Napoles',
      phones: [
        '123-123-123',
        '222-123-123',
        '444-555-666',
      ]
    };
  }
}
