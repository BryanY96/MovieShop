import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { MovieCard } from 'src/app/shared/models/movieCard';
import { environment } from 'src/environments/environment';
import {Movie} from 'src/app/shared/models/movieDetails';

@Injectable({
  providedIn: 'root'
})
export class MovieService {

  // should have all the methods that deals with Movies, getById, getTopRevenue, GetTopRated
  // HttpClient to make AJAX request
  // XMLHttpRequest => 
  // private readonly, inject -- in MVC
  constructor(private http: HttpClient) { }

  getTopRevenueMovies(): Observable<MovieCard[]> {

    //https://localhost:44373/api/Movies/toprated
    // create a model based on JSON Data
    // Observables are lazy, only when you subscribe to an observable you will get the data..
    // HttpClient in Angular => Observable => 
    return this.http.get(`${environment.apiUrl}` + 'Movies/toprevenue')
      .pipe(
        map(resp => resp as MovieCard[])
      )
      // map() == .select()
    // movies.where(m => m.budget > 10000).select(m => new MovieCard { id = m.id, title = m.title}).ToList()
  }

  getMovieDetails(movieId:number): Observable<Movie> {
    return this.http.get(`${environment.apiUrl}` + 'movies/' + movieId.toString())
    .pipe(
      map(resp => resp as Movie)
    )
  }

}

