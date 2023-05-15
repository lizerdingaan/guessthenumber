import { Component } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { AddUser } from '../../models/adduser.model';
import { BackendApiService } from '../../services/backend-api.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  response = new AddUser();

  constructor(private backendApiService: BackendApiService,
    private route: Router) { }

  getUserExistance(username: string) {
    this.backendApiService.getExistingUser(username).subscribe(
      data => {
        this.response = data;
        console.log(data);
      }
    )
  }

  onSubmit(username: string): void {
    this.getUserExistance(username);
    console.log(username);
    this.route.navigateByUrl(`/menu/${username}`)
  }

}
