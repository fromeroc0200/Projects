import { Directive, OnInit } from '@angular/core';

/*Se usa un decorador, se especifica con @*/
/*Los decortadores son un modo de añadirt metadatos a declaraciones de clase
para ser usadas por 'inyaccion de dependencias' o 'compilación de directivas' */
@Directive({
  selector: '[appResaltar]'
})
export class ResaltarDirective implements OnInit {

  constructor() { }

  ngOnInit() {

  }

}
