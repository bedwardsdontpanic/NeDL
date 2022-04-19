import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IUser } from '../Objects/User';

@Injectable({
  providedIn: 'root'
})
export class SessionService {
  constructor(private myHttpCli: HttpClient) { }
  headers = {
    'Content-Type': 'application/json',
    // tslint:disable-next-line: object-literal-key-quotes
    'Accept': 'application/json',
    'Access-Control-Allow-Headers': '*',
    // tslint:disable-next-line: object-literal-key-quotes
    'withCredentials': true
  };
  /* If you want your server to remember who you are...you'll have to send them your cookies so it can verfiy your identity.
      we do this using the {withCredentials: true} portion of the HttpRequest
  */

  infoRevRequest(): Observable<IUser> {
    return this.myHttpCli.get<IUser>('http://34.70.32.124/RevatureDoctor-0.0.1-SNAPSHOT/sesgetCurrentRevInfo.app',
      this.headers);
  }

  loginRevRequest(email: string, password: string): Observable<IUser> {
    return this.myHttpCli.post<IUser>('http://34.70.32.124/RevatureDoctor-0.0.1-SNAPSHOT/sesrevlogin.app', [email, password],
      this.headers);
  }

  logoutRevRequest(): Observable<IUser> {
    return this.myHttpCli.get<IUser>('http://34.70.32.124/RevatureDoctor-0.0.1-SNAPSHOT/sesrevlogout.app',
    this.headers);
  }

  infoDocRequest(): Observable<IUser> {
    return this.myHttpCli.get<IUser>('http://34.70.32.124/RevatureDoctor-0.0.1-SNAPSHOT/sesgetCurrentDocInfo.app',
    this.headers);
  }

  loginDocRequest(email: string, password: string): Observable<IUser> {
    return this.myHttpCli.post<IUser>('http://34.70.32.124/RevatureDoctor-0.0.1-SNAPSHOT/sesdoclogin.app', [email, password]
      , this.headers);
  }

  logoutDocRequest(): Observable<IUser> {
    return this.myHttpCli.get<IUser>('http://34.70.32.124/RevatureDoctor-0.0.1-SNAPSHOT/seslogout.app',
    this.headers);
  }
  actuator(): Observable<string> {
    return this.myHttpCli.get<string>('http://34.70.32.124/RevatureDoctor-0.0.1-SNAPSHOT/health.app',
    this.headers);
  }
}


