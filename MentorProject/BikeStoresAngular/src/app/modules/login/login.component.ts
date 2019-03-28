import { Component, OnInit } from '@angular/core';

/*Import SecirityService for implement your methods */
import { SecurityService } from 'src/app/services/security/security.service';
import { AppUserAuth } from 'src/Models/app-user-auth';
import { AppUser } from 'src/Models/app-user';
import { Router, ActivatedRoute } from '@angular/router';

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
  returnUrl: string;

  constructor(private securityService: SecurityService,
              private router: Router,
              private route: ActivatedRoute) { }

  ngOnInit() {
    this.returnUrl = this.route.snapshot.queryParamMap.get('returnUrl');
    console.log('URL: ' + this.returnUrl);
  }

  /*Implement login method*/
  login() {
    console.log('valida login');
    this.securityService.login(this.user).subscribe(resp => { this.securityObject = resp;
                                                              if (this.returnUrl) {
                                                                if (resp.BearerToken !== '') {
                                                                  this.router.navigateByUrl(this.returnUrl);
                                                                }
                                                              } else {
                                                                if (resp.BearerToken !== '') {
                                                                  this.router.navigateByUrl('dashboard');
                                                                }
                                                              }
    },
    (error) => {
        console.log('Error: ' + error);
        // When there is a error, set a new Objects that contain values as false
        this.securityObject = new AppUserAuth();
      }
    );
  }


}
