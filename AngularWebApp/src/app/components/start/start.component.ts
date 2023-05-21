import { Component } from '@angular/core';
import { Responses } from '../../models/responses.model';
import { ActivatedRoute, Router } from '@angular/router';
import { BackendApiService } from '../../services/backend-api.service';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { DetailDialogComponent } from '../../components/detail-dialog/detail-dialog.component';
import { FormGroup, NgForm } from '@angular/forms';
import { ContinueDialogComponent } from '../continue-dialog/continue-dialog.component';


@Component({
  selector: 'app-start',
  templateUrl: './start.component.html',
  styleUrls: ['./start.component.css']
})
export class StartComponent {

  beginResponse = new Responses();
  response_ = new Responses();
  username = String(this.route_.snapshot.paramMap.get('username'));
  message: string = "";
  isPlaying: boolean = true;
  title = ""
  isButtonDisabled: boolean = false;
  textBoxValue: string = '';


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

  onClickSubmitInput(username: string, id: number, guess: number) {

    if (guess < 1 || guess > 20) {
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
  }


  onClickContinue() {
    const mdConfig = new MatDialogConfig();
    mdConfig.disableClose = true;
    mdConfig.width = '400px';
    mdConfig.data = {
      title: 'Note',
      content: 'Do you want to quit to menu?'
    }

    const dialogRef = this.dialog.open(ContinueDialogComponent, mdConfig);
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.route.navigateByUrl(`/menu/${this.username}`)
      }
    })


  }

  onClickPlayAgain() {
    this.route.navigateByUrl(`/start/${this.username}`);
  }

/*  disableButton() {
    this.isButtonDisabled = true;
  }*/

/*  enableButton() {
    this.isButtonDisabled = false;
  }*/
}
