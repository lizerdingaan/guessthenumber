import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent {

  constructor(private route: Router) { }

  onClickStartGame() {
    this.route.navigateByUrl('/start');
  }

  onClickHistory() {
    this.route.navigateByUrl('/history');
  }

  onClickExit() {
    this.route.navigateByUrl('/home')
  }
}
