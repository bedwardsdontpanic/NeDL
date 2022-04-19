import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { IUser } from '../Objects/User';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private url = 'http://localhost/login.app';
  private url2 = 'http://localhost/allDoc.app';
  userCreds: string[] = new Array<string>();

  constructor(private httpCli: HttpClient) { }
  retrieveUser(email: string, password: string): Observable<IUser> {
    this.userCreds = [email, password];
    return this.httpCli.post<IUser>(this.url, this.userCreds);

  }

  getAllUsers(): Observable<IUser[]> {
    return this.httpCli.get<IUser[]>(this.url2);
  }

}

