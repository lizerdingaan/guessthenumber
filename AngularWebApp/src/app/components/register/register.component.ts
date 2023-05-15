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

  constructor(private backendApiService: BackendApiService,
    private route: Router) { }

  getRegisteredUser(username: string) {
    this.backendApiService.registerNewUser(username).subscribe(
      data => {
        this.response = data;
        console.log(data);
      }
    )
  }

  onSubmit(username: string) {
    this.getRegisteredUser(username);
    this.route.navigateByUrl(`/menu/${username}`);
  }
}
