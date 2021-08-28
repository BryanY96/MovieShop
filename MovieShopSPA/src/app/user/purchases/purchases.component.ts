import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { UserService } from 'src/app/core/services/user.service';
import { MovieCard } from 'src/app/shared/models/movieCard';

@Component({
  selector: 'app-purchases',
  templateUrl: './purchases.component.html',
  styleUrls: ['./purchases.component.css']
})
export class PurchasesComponent implements OnInit {
  movies !: MovieCard[];
  id !: number;
  constructor(private userservice: UserService, private currentRouter: ActivatedRoute) { }

  ngOnInit(): void {
    this.currentRouter.params.subscribe(
      p => {
        this.id = p['id'];
      });
    console.log(this.id);
    this.userservice.getUserPurchases(this.id).subscribe(
      u => {
        this.movies = u;
        console.table(this.movies);
      }
    )
  }
}
