import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/core/services/user.service';
import { MovieCard } from 'src/app/shared/models/movieCard';

@Component({
  selector: 'app-favorites',
  templateUrl: './favorites.component.html',
  styleUrls: ['./favorites.component.css']
})
export class FavoritesComponent implements OnInit {
  movies!: MovieCard[];

  constructor(private userservice: UserService) { }

  ngOnInit(): void {

    this.userservice.getUserFavorites(49821).subscribe(
      u => {
        this.movies = u;
        console.table(this.movies);
      }
    )
  }
}
