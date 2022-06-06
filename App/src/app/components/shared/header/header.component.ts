import { Component, OnInit } from '@angular/core';
import { UserService } from '../../../services/user.service';
import { Developer } from '../../../models/developer';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
})
export class HeaderComponent implements OnInit {
  constructor(private userService: UserService) {}
  currentUser?: Developer;

  ngOnInit() {
    this.userService.currentUser.subscribe((userData) => {
      this.currentUser = userData;
    });
  }

  onLogout() {
    this.userService.purgeAuth();
  }
}
