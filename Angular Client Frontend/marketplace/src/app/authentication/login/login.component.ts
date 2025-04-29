import { Component, OnInit } from '@angular/core';
import { LoginApiService } from '../../core/login-api/login-api.service';
import {Router} from '@angular/router';
import { User } from '../../core/login-api/models/user.model';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  result: User;
  username: string;
  userLoggedIn: boolean = false;

  constructor(private loginApiService: LoginApiService, private router: Router) { }

  ngOnInit(): void {
  }

  login(): void {
    this.loginApiService.verifyLoginDetails(this.username).subscribe( async s => {
      
    this.result = s 

    if (this.result != null)
    {
      
      this.loginApiService.saveLoginState(this.result);
      console.log('username was found and retrieved');
    }
    else
    {
      this.loginApiService.createUser(this.username).subscribe();
      console.log('username was not found, user was made and logged in');
      await setTimeout(() => {this.loginApiService.verifyLoginDetails(this.username).subscribe(s => {
        
        this.loginApiService.saveLoginState({id: s.id, username: s.username});
      });}, 2000)
      
      
    }
  });

    //we could make this service incorporate localstorage to persist logins across reloads
    this.router.navigate(['list']);

  }
}
