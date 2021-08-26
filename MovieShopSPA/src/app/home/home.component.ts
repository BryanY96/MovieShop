import { ClassGetter } from '@angular/compiler/src/output/output_ast';
import { Component, OnInit } from '@angular/core';
import { MovieService } from '../core/services/movie.service';
import { MovieCard } from '../shared/models/movieCard';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  movies!: MovieCard[];
  
  constructor(private movieService: MovieService) { }

  ngOnInit(): void {
    // right event to call our API
    this.movieService.getTopRevenueMovies().subscribe(
      m => {
        this.movies = m;
        console.log('inside home component init method')
        console.table(this.movies);
      }
    );
  }
  // Angular Life Cycle Hooks
  // => go through certain events
  // Person's Life Cycle => Birthday, school day, marriage day, death day

}
