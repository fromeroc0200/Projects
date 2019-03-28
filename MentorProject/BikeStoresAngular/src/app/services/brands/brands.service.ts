import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment.prod';
import { Brand } from 'src/Models/brand';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BrandsService {

  /*Setting properties */
  URL_API = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getBrands(): Observable<Brand[]> {
    return this.http.get<Brand[]>(this.URL_API + 'brands');
  }

}
