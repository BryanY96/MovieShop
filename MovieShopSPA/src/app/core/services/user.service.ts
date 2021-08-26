import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { MovieCard } from 'src/app/shared/models/movieCard';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }

  getUserPurchases(userid:number): Observable<MovieCard[]> {

    return this.http.get(`${environment.apiUrl}` + 'User/' + userid.toString() + '/purchases')
    .pipe(
      map(resp => resp as MovieCard[])
    )

  }
  getUserFavorites(userid:number): Observable<MovieCard[]> {

    return this.http.get(`${environment.apiUrl}` + 'User/' + userid.toString() + '/favorites')
    .pipe(
      map(resp => resp as MovieCard[])
    )
  }

}
