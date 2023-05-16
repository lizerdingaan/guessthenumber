import { Component, OnInit } from '@angular/core';
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
    private route_: ActivatedRoute) {

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
    this.backendApiService.deleteUserHistory(this.username).subscribe(
      data => {
        this.responses = data;
        console.log(data);
      }
    )
  }

}
