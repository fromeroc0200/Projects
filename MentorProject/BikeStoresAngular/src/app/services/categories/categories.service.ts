import { Injectable, APP_ID } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment.prod';
import { Category } from 'src/Models/category';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CategoriesService {

  URL_API = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getCategories(): Observable<Category[]> {
    return this.http.get<Category[]>(this.URL_API + 'categories');
  }

  getCategory(id: number): Observable<Category> {
    return this.http.get<Category>(this.URL_API + 'categories/' + id);
  }

  deleteCategory(id: number) {
    return this.http.delete(this.URL_API + 'categories/' + id);
  }

  updateCategory(entity: Category): Observable<Category> {
    return this.http.patch<Category>(this.URL_API + 'categories/' + entity.category_id, entity);
  }

  addCategory(entity: Category): Observable<Category> {
    return this.http.post<Category>(this.URL_API + 'categories', entity);
  }
}
