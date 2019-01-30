import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
//--Se agrega modulo de formulario a imports
import { FormsModule } from '@angular/forms'

//--Agregando el modulo de google maps
import { AgmCoreModule } from '@agm/core';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    //--Se agrega modulo de formularios
    FormsModule,
    //--Agregamos el modulo de google maps
    AgmCoreModule.forRoot({
      apiKey: 'AIzaSyA69bt1Z4Sp6ie0T9Jjgq9f-aRrbsye1gY'
    })
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
