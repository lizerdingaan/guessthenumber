import { Component } from '@angular/core';
import { AddUser } from '../../models/adduser.model';
import { BackendApiService } from '../../services/backend-api.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {

  response = new AddUser()
  existingUser: boolean = false;

  constructor(private backendApiService: BackendApiService,
    private route: Router) { }


  getRegisteredUser(username: string) {
    this.backendApiService.registerNewUser(username).subscribe(
      data => {
        this.response = data;
        this.existingUser = this.response.usernameExists;
        if (!data.usernameExists) {
          this.route.navigateByUrl(`/menu/${username}`);
        }
        console.log(data);
      }
    )
  }

  onSubmit(username: string) {
    this.getRegisteredUser(username);
  }

  onClickBack() {
    this.route.navigateByUrl('/home');
  }


}
