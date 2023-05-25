import { Component } from '@angular/core';
import { Responses } from '../../models/responses.model';
import { ActivatedRoute, Router } from '@angular/router';
import { BackendApiService } from '../../services/backend-api.service';
import { MatDialog } from '@angular/material/dialog';
import { NgForm } from '@angular/forms';


@Component({
  selector: 'app-start',
  templateUrl: './start.component.html',
  styleUrls: ['./start.component.css']
})
export class StartComponent {

  beginResponse = new Responses();
  response_ = new Responses();
  username = String(this.route_.snapshot.paramMap.get('username'));
  message: string = "You've got 5 chances.";
  isPlaying: boolean = true;


  constructor(private backendApiService: BackendApiService,
    private route_: ActivatedRoute, private route: Router,
    public dialog: MatDialog) { }

  ngOnInit() {
    this.backendApiService.StartGame().subscribe(
      data => {
        this.beginResponse = data;
        console.log(data);
      }
    )
  }

  onClickSubmitInput(username: string, id: number, guess: number, userForm:NgForm) {

    if (guess < 1 || guess > 20 || guess == null) {
      this.message = "Only enter numbers between 1 and 20."
    }
    else {

      this.backendApiService.PlayGuessingGame(username, id, guess).subscribe(
        data => {
          this.response_ = data;
          this.message = this.response_.message;
          if (!this.response_.playingGame) {
            this.isPlaying = false;
          }
        }
      )
    }
  
    userForm.reset();
  }


  onClickQuit() {

    this.route.navigateByUrl(`/menu/${this.username}`)

  }

  onClickHome() {

    this.route.navigateByUrl(`/home`)

  }


  onClickPlayAgain() {
    window.location.reload();
  }

}
