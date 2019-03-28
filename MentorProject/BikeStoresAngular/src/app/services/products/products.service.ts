import { Injectable } from '@angular/core';

/*Implementing  Http Module */
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Product } from 'src/Models/product';
import { Observable } from 'rxjs';

/*Setting main URL */
const API_URL = environment.apiUrl;

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  constructor(private http: HttpClient) { }

  getProducts(): Observable<Product[]> {
    return this.http.get<Product[]>( API_URL + 'products');
  }

  getProduct(id: number): Observable<Product> {
    return this.http.get<Product>(API_URL + 'products/' + id);
  }

  addProduct(entity: Product): Observable<Product> {
    return this.http.post<Product>(API_URL + 'products', entity);
  }

  updateProduct(entity: Product): Observable<any> {
    return this.http.patch(API_URL + 'products/' + entity.product_id, entity);
  }

  deleteProduct(id: number) {
    return this.http.delete(API_URL + 'products/' + id);
  }
}
