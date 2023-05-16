import { Component } from '@angular/core';
import { Responses } from '../../models/responses.model';
import { ActivatedRoute, Router } from '@angular/router';
import { BackendApiService } from '../../services/backend-api.service';


@Component({
  selector: 'app-start',
  templateUrl: './start.component.html',
  styleUrls: ['./start.component.css']
})
export class StartComponent {

  response = new Responses();
  username = String(this.route_.snapshot.paramMap.get('username'));

  constructor(private backendApiService: BackendApiService,
    private route_: ActivatedRoute, private route: Router) { }

  ngOnInit() {
    this.backendApiService.StartGame().subscribe(
      data => {
        this.response = data;
        console.log(data);
      }
    )
  }

  onClickSubmitInput(username: string, id: number, guess: number) {
    this.backendApiService.PlayGuessingGame(username, id, guess).subscribe(
      data => {
        this.response = data;
        console.log(data);
      }
    )
  }

  onClickMenu() {
    this.route.navigateByUrl(`/menu/${this.username}`);
  }

  onClickPlayAgain() {
    this.route.navigateByUrl(`/start/${this.username}`);
  }
}
