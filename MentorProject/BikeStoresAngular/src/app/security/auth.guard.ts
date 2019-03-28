import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { SecurityService } from '../services/security/security.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {


  constructor(private router: Router, private securityService: SecurityService) {}


  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
      let claimType: string = next.data.claimType;
      if (this.securityService.securityObject.IsAuthenticated && this.securityService.securityObject[claimType]) {
        return true;
      } else {
        this.router.navigate(['login'], { queryParams: { returnUrl: state.url } } );
        return false;
      }


      /*if (localStorage.getItem('userToken') != null) {
        return true;
      }
      //this.router.navigate(['/login']);
      return false;*/
  }

}
