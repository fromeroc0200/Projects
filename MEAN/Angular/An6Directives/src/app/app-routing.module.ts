import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { NgforComponent } from './structural/ngfor/ngfor.component';
import { NgifComponent } from './structural/ngif/ngif.component';

import { NgstyleComponent } from './attribute/ngstyle/ngstyle.component';
import { NgclassComponent } from './attribute/ngclass/ngclass.component';
import { NgswitchComponent } from './StructuralAttribute/ngswitch/ngswitch.component';

const routes: Routes = [
  {
    path: '',
    component: NgforComponent
  },
  {
    path: 'ngif',
    component: NgifComponent
  },
  {
    path: 'ngstyle',
    component: NgstyleComponent
  },
  {
    path: 'ngclass',
    component: NgclassComponent
  },
  {
    path: 'ngswitch',
    component: NgswitchComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
