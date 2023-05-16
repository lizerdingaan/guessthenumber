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

  response = new Responses();

  constructor(private route: Router,
    private route_: ActivatedRoute,
    private backendApiService: BackendApiService) { }

  username = String(this.route_.snapshot.paramMap.get('username'));

  onClickStartGame() {
    this.route.navigateByUrl(`start/${this.username}`);

  }

  onClickHistory() {
    this.route.navigateByUrl(`/history/${this.username}`);

  }

  onClickDeleteUser() {
    this.backendApiService.deleteUser(this.username).subscribe(
      data => {
        this.response = data;
      }
    )
    this.route.navigateByUrl('/home');
  }

  onClickExit() {
    this.route.navigateByUrl('/home');
  }
}
