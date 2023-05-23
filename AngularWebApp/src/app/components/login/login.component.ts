import { Component } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { AddUser } from '../../models/adduser.model';
import { BackendApiService } from '../../services/backend-api.service';
import { Router } from '@angular/router';
import { ContinueDialogComponent } from '../continue-dialog/continue-dialog.component';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  response = new AddUser();
  existingUser: boolean = true;

  constructor(private backendApiService: BackendApiService,
    private route: Router,
    public dialog: MatDialog) { }

  dialogPopUp() {
    const mdConfig = new MatDialogConfig();
    mdConfig.disableClose = true;
    mdConfig.width = '400px';
    mdConfig.data = {
      title: 'Warning!',
      content: "Please enter a username."
    }
    const dialogRef = this.dialog.open(ContinueDialogComponent, mdConfig);
  }

  getUserExistance(username: string) {
    this.backendApiService.getExistingUser(username).subscribe(
      data => {
        this.response = data;
        this.existingUser = this.response.usernameExists;
        if (username == "") {
          this.dialogPopUp();
        }
        else if (data.usernameExists) {
          this.route.navigateByUrl(`/menu/${username}`);
        } 
      }
    )
  }


  onSubmit(username: string): void {
    this.getUserExistance(username);    

  }

  onClickBack() {
    this.route.navigateByUrl('/home');
  }

}
