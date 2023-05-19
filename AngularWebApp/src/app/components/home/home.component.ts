import { Component } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { DetailDialogComponent } from '../../components/detail-dialog/detail-dialog.component';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {

  title = 'Welcome to...';

  constructor(private route: Router, public dialog: MatDialog) { }

  onClickLogin() {
    this.route.navigateByUrl('/login');
  }

  onClickRegister() { 
    this.route.navigateByUrl('/register');
  }

  dialogPopUp() {
    const mdConfig = new MatDialogConfig();
    mdConfig.disableClose = true;
    mdConfig.width = '400px';
    mdConfig.data = {
      title: 'How to play',
      content: "1. Login as an existing user." +
      " 2. If you are new, register with a unique username." +
      " 3.Press start to begin. " +
      " 4. You have 5 tries to guess a number between 1 and 20."
    }

    const dialogRef = this.dialog.open(DetailDialogComponent, mdConfig);


  }
}
