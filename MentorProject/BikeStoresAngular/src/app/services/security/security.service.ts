import { Injectable } from '@angular/core';



/*Import LOGIN_MOCKS with the start values for authentication */
import { LOGIN_MOCKS } from 'src/Models/login-mocks';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { HttpClient, HttpHeaders } from '@angular/common/http';


/*Import providers */
import { AppUserAuth } from 'src/Models/app-user-auth';
import { AppUser } from 'src/Models/app-user';

const API_URL = 'http://localhost:49973/api/security/';
const httpOptions = { headers: new HttpHeaders({'Content-Type': 'application/json' }) };

@Injectable({
  providedIn: 'root'
})


export class SecurityService {
  /*Create security property and initializate*/
  securityObject: AppUserAuth = new AppUserAuth();

  /*Constructor not injecting dependency */
  constructor(private http: HttpClient) { }

  /*Create login method with appuser parameter*/
  login(entity: AppUser): Observable<AppUserAuth> {
    this.resetSecurityObject();

    return this.http.post<AppUserAuth>(API_URL + 'login', entity, httpOptions).pipe(
      tap(resp => {
        // this.securityObject = new AppUserAuth();
        Object.assign(this.securityObject, resp);
        localStorage.setItem('BearerToken', this.securityObject.BearerToken);
        console.log(resp);
        console.log(this.securityObject);
      })
    );

  }

  /*Create logout method */
  logout(): void {
    this.resetSecurityObject();
  }

  setLoggedIn(value: boolean) {

  }

  /*Reset Security Object */
  resetSecurityObject(): void {
    this.securityObject.UserName = '';
    this.securityObject.BearerToken = '';
    this.securityObject.IsAuthenticated = false;

    this.securityObject.CanAccessProducts = false;
    this.securityObject.CanAddProduct = false;
    this.securityObject.CanSaveProduct = false;
    this.securityObject.CanAccessCategory = false;
    this.securityObject.CanAddCategory = false;

    localStorage.removeItem('BearerToken');
  }
}
