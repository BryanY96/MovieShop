import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Login } from 'src/app/shared/models/login';
import { environment } from 'src/environments/environment';
import { User } from 'src/app/shared/models/user';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private currentUserSubject = new BehaviorSubject<User>({} as User);
  public currentUser = this.currentUserSubject.asObservable();

  private isLoggedInSubject = new BehaviorSubject<boolean>(false);
  public isLoggedIn = this.isLoggedInSubject.asObservable();

  private jwtHelper = new JwtHelperService();

  constructor(private http: HttpClient) { }

  login(login: Login): Observable<boolean> {

    return this.http.post(`${environment.apiUrl}` + 'account/login', login)
    .pipe(
      map((response: any) => {
        if (response) {
          // take the response and save that token in local storage
          // key : 'token'   value: token string
          localStorage.setItem('token', response.token)
          this.populateUserInfo();
          return true;
        }
        return false;
      })
    )
    // call the API api/account/login un 
    // POST
    // JWT if it's valid
    // save the token in local storage
  }

  // we need to decode the token
  populateUserInfo(){
      var token = localStorage.getItem('token');
      if (token && !this.jwtHelper.isTokenExpired(token)) {
        // if not expired, then decode the token
        console.log('inside the populate user method');
        const decodedToken = this.jwtHelper.decodeToken(token);
        console.log(decodedToken);
        // set current loggedin user into observable
        this.currentUserSubject.next(decodedToken);

        // set authentication status to true
        this.isLoggedInSubject.next(true);
      }
    }


  logout(){
    // delete the token from local storage 
    localStorage.removeItem('token');

    // clear out the observables
    this.currentUserSubject.next({} as User);
    this.isLoggedInSubject.next(false);
  }

  
}
