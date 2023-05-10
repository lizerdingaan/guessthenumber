import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BackendApiService } from '../../services/backend-api.service';

@Component({
  selector: 'app-history',
  templateUrl: './history.component.html',
  styleUrls: ['./history.component.css']
})
export class HistoryComponent implements OnInit {

  constructor(private route: Router,
    private backendApiService: BackendApiService) { }


  ngOnInit(): void {
    this.getUserHistory();
  }


  getUserHistory() {
    this.backendApiService.getHistory().subscribe(
      response => {
        console.log(response);
      });
  }


  onClickBacktoMenu() {
    this.route.navigateByUrl('/menu');
  }

}
