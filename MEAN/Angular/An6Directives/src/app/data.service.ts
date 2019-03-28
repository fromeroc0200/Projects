import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { analyzeAndValidateNgModules } from '@angular/compiler';
@Injectable({
  providedIn: 'root'
})
export class DataService {

  /*Inyectamos el modulo httpclient */
  constructor(private http: HttpClient) { }

  getUsers() {
    return this.http.get('https://jsonplaceholder.typicode.com/users');
  }

}
