import { Component } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { DetailDialogComponent } from '../../components/detail-dialog/detail-dialog.component';
import { Router } from '@angular/router';
import { NeedHelpDialogComponent } from '../need-help-dialog/need-help-dialog.component';

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

    const dialogRef = this.dialog.open(NeedHelpDialogComponent, mdConfig);


  }
}
