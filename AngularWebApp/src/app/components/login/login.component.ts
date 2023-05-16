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
  exist: boolean = true;

  constructor(private backendApiService: BackendApiService,
    private route: Router) { }

  getUserExistance(username: string) {
    this.backendApiService.getExistingUser(username).subscribe(
      data => {
        this.response = data;
        this.exist = this.response.usernameExists;
        if (data.usernameExists) {
          this.route.navigateByUrl(`/menu/${username}`);
        } 
        console.log(data);
      }
    )
  }


  onSubmit(username: string): void {
    this.getUserExistance(username);    

  }

}
