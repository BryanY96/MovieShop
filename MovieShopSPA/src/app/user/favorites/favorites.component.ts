import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { UserService } from 'src/app/core/services/user.service';
import { MovieCard } from 'src/app/shared/models/movieCard';

@Component({
  selector: 'app-favorites',
  templateUrl: './favorites.component.html',
  styleUrls: ['./favorites.component.css']
})
export class FavoritesComponent implements OnInit {
  movies!: MovieCard[];
  id!: number;
  constructor(private userservice: UserService, private currentRouter: ActivatedRoute) { }

  ngOnInit(): void {
    // this.currentRouter.paramMap.subscribe(
    //   r => {
    //     this.id = +r.get('id')!;
    //   }
    // )
    this.currentRouter.params.subscribe(
      f => {
        this.id = f['id'];
      });
      console.log(this.id);
    this.userservice.getUserFavorites(this.id).subscribe(
      u => {
        this.movies = u;
        console.table(this.movies);
      }
    )
  }
}
