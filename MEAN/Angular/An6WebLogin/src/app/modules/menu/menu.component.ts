import { Component, OnInit, Input } from '@angular/core';
import { AppUserAuth } from 'src/Models/app-user-auth';
import { SecurityService } from 'src/app/services/security/security.service';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css'],
  providers: [SecurityService],
})
export class MenuComponent implements OnInit {

  /*Set property */
  @Input() securityObject: AppUserAuth = null;

  constructor(private securityService: SecurityService) { }

  ngOnInit() {
  }

  /*Creating logout method */
  logout() {
    /*Call logout from Security Service */
    this.securityService.logout();
  }
}
