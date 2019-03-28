import { Component } from '@angular/core';
import { SecurityService } from './services/security/security.service';
import { AppUserAuth } from 'src/Models/app-user-auth';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  /*Set a securityObject for obtain parameter from SecurityService object*/
  securityObject: AppUserAuth = null;
  title = 'An6WebLogin';
  constructor(private securityService: SecurityService) {
    this.securityObject = securityService.securityObject;
  }



}
