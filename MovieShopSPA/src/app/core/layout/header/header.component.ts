import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/shared/models/user';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  isLoggedIn: boolean = false;
  user!: User;
  constructor(private authService: AuthService) { }

  ngOnInit(): void {

    this.authService.isLoggedIn.subscribe(
      resp => this.isLoggedIn = resp);
    this.authService.currentUser.subscribe(
      resp => this.user = resp
    );
  }

}
