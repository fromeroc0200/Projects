import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { config } from '../../../e2e/protractor.conf';
import { User } from '../models/user';
import { environment } from 'src/environments/environment.prod';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  API_URL: string = environment.apiUrl;
  constructor(private http: HttpClient) { }

  getAll() {
    return this.http.get<User[]>(`${this.API_URL}/users`);
}

getById(id: number) {
    return this.http.get(`${this.API_URL}/users/` + id);
}

register(user: User) {
    return this.http.post(`${this.API_URL}/users/register`, user);
}

update(user: User) {
    return this.http.put(`${this.API_URL}/users/` + user.id, user);
}

delete(id: number) {
    return this.http.delete(`${this.API_URL}/users/` + id);
}
}
