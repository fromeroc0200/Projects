import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-hijo',
  templateUrl: './hijo.component.html',
  styleUrls: ['./hijo.component.scss']
})
export class HijoComponent implements OnInit {

  @Input() nombre = 'hola';

  /*Se crea un evento de salida llamado gritar*/
  @Output() gritar: EventEmitter<boolean> = new EventEmitter<boolean>();
  constructor() { }

  ngOnChanges(changes: SimpleChange) { }

  ngOnInit() {
  }



  deseaGritar() {
    /*Regresa el resultado de gritar*/
    this.gritar.next(true);
 }

}
