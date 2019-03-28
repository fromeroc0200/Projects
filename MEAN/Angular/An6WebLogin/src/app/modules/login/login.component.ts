import { Component, OnInit } from '@angular/core';

/*Import SecirityService for implement your methods */
import { SecurityService } from 'src/app/services/security/security.service';
import { AppUserAuth } from 'src/Models/app-user-auth';
import { AppUser } from 'src/Models/app-user';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit {

  /*Setting a securityObject for get and validate permissions */
  securityObject: AppUserAuth = null;
  /*Creating user object for get values to validate and initializate*/
  user: AppUser = new AppUser();

  constructor(private securityService: SecurityService, private router: Router) { }

  ngOnInit() {
  }

  /*Implement login method*/
  login() {
    this.securityService.login(this.user).subscribe(resp => {this.securityObject = resp; });
  }


}
