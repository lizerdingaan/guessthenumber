import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { DetailDialogComponent } from '../../components/detail-dialog/detail-dialog.component';
import { ActivatedRoute, Router } from '@angular/router';
import { Responses } from '../../models/responses.model';
import { BackendApiService } from '../../services/backend-api.service';

@Component({
  selector: 'app-history',
  templateUrl: './history.component.html',
  styleUrls: ['./history.component.css']
})
export class HistoryComponent implements OnInit {

  responses = new Responses();

  constructor(private route: Router,
    private backendApiService: BackendApiService,
    private route_: ActivatedRoute,
    public dialog: MatDialog) {

  }

  username = String(this.route_.snapshot.paramMap.get('username'));

  ngOnInit(): void {
    this.getUserHistory(this.username);
  }


  getUserHistory(username: string) {
    this.backendApiService.getHistory(username).subscribe(
      data => {
        this.responses = data;
        console.log(data);
      });
  }


  onClickBacktoMenu() {
    this.route.navigateByUrl(`/menu/${this.username}`);
  }

  onClickDeleteHistory() {
    const mdConfig = new MatDialogConfig();
    mdConfig.disableClose = true;
    mdConfig.width = '400px';
    mdConfig.data = {
      title: 'Warning!',
      content: 'Are you sure you want to delete your history games?'
    }

    const dialogRef = this.dialog.open(DetailDialogComponent, mdConfig);

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.backendApiService.deleteUserHistory(this.username).subscribe(
          data => {
            this.responses = data;
          }
        )
      }
    })
  }

}
