import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgforComponent } from './structural/ngfor/ngfor.component';
import { NgifComponent } from './structural/ngif/ngif.component';

import { HttpClient, HttpClientModule } from '@angular/common/http';
import { SidebarComponent } from './sidebar/sidebar.component';
import { NgstyleComponent } from './attribute/ngstyle/ngstyle.component';
import { NgclassComponent } from './attribute/ngclass/ngclass.component';
import { NgswitchComponent } from './StructuralAttribute/ngswitch/ngswitch.component';


@NgModule({
  declarations: [
    AppComponent,
    NgforComponent,
    NgifComponent,
    SidebarComponent,
    NgstyleComponent,
    NgclassComponent,
    NgswitchComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
