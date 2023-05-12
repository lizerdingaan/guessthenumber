import { Component } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { AddUser } from '../../models/adduser.model';
import { BackendApiService } from '../../services/backend-api.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  //username: string = '';

  response = new AddUser();

  constructor(private backendApiService: BackendApiService) { }

  getUserExistance() {
    this.backendApiService.getExistingUser().subscribe(
      data => {
        this.response = data;
        console.log(data);
      }
    )
  }

  onSubmit(username: string): void {
    console.log(username);  
  }

}
