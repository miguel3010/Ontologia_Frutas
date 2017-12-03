import { Http } from '@angular/http';
import { Injectable } from '@angular/core';
import 'rxjs/add/operator/map';

@Injectable()
export class AuthService {
  currentUser: UserLogged;

  constructor(private http: Http) {
    let token = localStorage.getItem('token');

  }

  login(credentials) {
    return false;
  }

  logout() {
    localStorage.removeItem('token');
    this.currentUser = null;
  }

  isLoggedIn() {
    return false;
  }
}

