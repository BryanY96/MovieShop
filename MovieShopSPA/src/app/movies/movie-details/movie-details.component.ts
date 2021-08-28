import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MovieService } from 'src/app/core/services/movie.service';
import { MovieCard } from 'src/app/shared/models/movieCard';
import { Movie } from 'src/app/shared/models/movieDetails';

@Component({
  selector: 'app-movie-details',
  templateUrl: './movie-details.component.html',
  styleUrls: ['./movie-details.component.css']
})
export class MovieDetailsComponent implements OnInit {
  movies !: Movie;
  id !: number;

  constructor(private movieService: MovieService, private currentRouter: ActivatedRoute) { }

  ngOnInit(): void {
    this.currentRouter.params.subscribe(
      f => {
        this.id = f['id'];
      });
      console.log(this.id);
      this.movieService.getMovieDetails(this.id).subscribe(
        u => {
          this.movies = u;
          console.table(this.movies)
        }
      )
  }
}
