import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {

  title = 'Welcome to...';

  constructor(private route: Router) { }

  onClickLogin() {
    this.route.navigateByUrl('/login');
  }

  onClickRegister() { 
    this.route.navigateByUrl('/register');
  }
}
