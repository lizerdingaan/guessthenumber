import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Responses } from '../../models/responses.model';
import { BackendApiService } from '../../services/backend-api.service';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent {

  responses = new Responses();

  constructor(private route: Router,
    private route_: ActivatedRoute,
    private backendApiService: BackendApiService) { }

  username = String(this.route_.snapshot.paramMap.get('username'));

  onClickStartGame() {
    this.route.navigateByUrl('/start');
  }

  onClickHistory() {
    this.route.navigateByUrl(`/history/${this.username}`);

  }

  onClickExit() {
    this.route.navigateByUrl('/home');
  }
}
