import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'platzisquare';
  a = 2;
  b = 3;
  listo = true;
  name:string = '';
  //--Seccion de variables para gloogle maps
lat:number = 19.3901558;
lng:number = -99.1995694;
  
  constructor()
  {
    setTimeout(()=>{
        this.listo = false
    }, 3000)
  }

  doAction(){
    alert('You click this button');
  }

  //--Seccion para directivas
  //--Any permite recibir cualquier tipo de objeto
  lugares:any =[
    {nombre : 'Juanita store'},
    {nombre : 'Pancha store'},
    {nombre : 'Paquita store'}
  ];

  places:any =[
    {active: true, name : 'Mona store'},
    {active: false,name : 'Osa store'},
    {active: true,name : 'Leona store'}
  ];





}
