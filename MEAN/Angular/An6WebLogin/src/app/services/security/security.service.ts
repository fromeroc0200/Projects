import { Injectable } from '@angular/core';

/*Import providers */
import { AppUserAuth } from 'src/Models/app-user-auth';
import { AppUser } from 'src/Models/app-user';

/*Import LOGIN_MOCKS with the start values for authentication */
import { LOGIN_MOCKS } from 'src/Models/login-mocks';
import { of, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class SecurityService {

  /*Create security property and initializate*/
  securityObject: AppUserAuth = new AppUserAuth();

  /*Constructor not injecting dependency */
  constructor() { }

  /*Create login method with appuser parameter*/
  login(entity: AppUser): Observable<AppUserAuth> {
    this.resetSecurityObject();

    Object.assign(this.securityObject, LOGIN_MOCKS.find(user => user.userName.toLowerCase() === entity.userName.toLowerCase()));

    /*Validating user name */
    if (this.securityObject.userName !== '') {
      // Store into local storage
      localStorage.setItem('bearerToken', this.securityObject.bearerToken);
    }

    /*Returning the securityObject if they were found*/
    return of<AppUserAuth>(this.securityObject);
  }

  /*Create logout method */
  logout(): void {
    this.resetSecurityObject();
  }

  /*Reset Security Object */
  resetSecurityObject(): void {
    this.securityObject.userName = '';
    this.securityObject.bearerToken = '';
    this.securityObject.isAuthenticated = false;

    this.securityObject.canAccessProducts = false;
    this.securityObject.canAddProduct = false;
    this.securityObject.canSaveProduct = false;
    this.securityObject.canAccessCategories = false;
    this.securityObject.canAddCategory = false;

    localStorage.removeItem('bearerToken');
  }
}
