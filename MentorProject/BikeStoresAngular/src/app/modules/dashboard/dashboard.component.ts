import { Component, OnInit, Input } from '@angular/core';
import { SecurityService } from 'src/app/services/security/security.service';
import { AppUserAuth } from 'src/Models/app-user-auth';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  securityObject: AppUserAuth;

  constructor(private securityService: SecurityService) {
      this.securityObject = securityService.securityObject;
  }

  ngOnInit() {
    console.log('is activated:' + this.securityObject.IsAuthenticated);
  }

}
