import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/core/services/user.service';
import { MovieCard } from 'src/app/shared/models/movieCard';

@Component({
  selector: 'app-purchases',
  templateUrl: './purchases.component.html',
  styleUrls: ['./purchases.component.css']
})
export class PurchasesComponent implements OnInit {
  movies !: MovieCard[];

  constructor(private userservice: UserService) { }

  ngOnInit(): void {
    this.userservice.getUserPurchases(49821).subscribe(
      u => {
        this.movies = u;
        console.table(this.movies);
      }
    )
  }

}
