import { Component } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { Responses } from '../../models/responses.model';
import { BackendApiService } from '../../services/backend-api.service';
import { DetailDialogComponent } from '../detail-dialog/detail-dialog.component';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent {

  response = new Responses();

  constructor(private route: Router,
    private route_: ActivatedRoute,
    private backendApiService: BackendApiService,
    public dialog: MatDialog) { }

  username = String(this.route_.snapshot.paramMap.get('username'));

  onClickStartGame() {
    this.route.navigateByUrl(`start/${this.username}`);

  }

  onClickHistory() {
    this.route.navigateByUrl(`/history/${this.username}`);

  }

  onClickDeleteUser() {
    const mdConfig = new MatDialogConfig();
    mdConfig.disableClose = true;
    mdConfig.width = '400px';
    const dialogRef = this.dialog.open(DetailDialogComponent, mdConfig);

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.backendApiService.deleteUser(this.username).subscribe(
          data => {
            this.response = data;
          }
        )
        this.route.navigateByUrl('/home');
      }
    })

 
  }

  onClickExit() {
    this.route.navigateByUrl('/home');
  }

}
