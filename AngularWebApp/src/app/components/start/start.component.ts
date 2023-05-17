import { Component } from '@angular/core';
import { Responses } from '../../models/responses.model';
import { ActivatedRoute, Router } from '@angular/router';
import { BackendApiService } from '../../services/backend-api.service';
import { FormGroup, NgForm } from '@angular/forms';


@Component({
  selector: 'app-start',
  templateUrl: './start.component.html',
  styleUrls: ['./start.component.css']
})
export class StartComponent {

  response = new Responses();
  response_ = new Responses();
  username = String(this.route_.snapshot.paramMap.get('username'));
  message: string = "";

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

    if (guess < 1 || guess > 20) {
      this.message = "Only enter numbers between 1 and 20."
    }
    else {

      this.backendApiService.PlayGuessingGame(username, id, guess).subscribe(
        data => {
          this.response_ = data;
          this.message = this.response_.message;
          console.log(data);
        }
      )
    }
  }

  onClickQuit() {
    this.route.navigateByUrl(`/menu/${this.username}`);
  }

  onClickPlayAgain() {
    this.route.navigateByUrl(`/start/${this.username}`);
  }
}
