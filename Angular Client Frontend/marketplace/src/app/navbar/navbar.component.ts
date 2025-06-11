import { Component, OnInit } from '@angular/core';
import { LoginApiService } from '../core/login-api/login-api.service';
import { NavMenu } from './navMenu';
import { User } from '../core/login-api/models/user.model';


@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})

export class NavbarComponent implements OnInit {

  navMenu: NavMenu[] = [
    { text: 'List', path: 'list' },
    { text: 'Post new', path: 'create' }
  ];

  

  login = {text: 'Login', path: 'login'};

  user: User = null;
  userLoggedIn: boolean = false;

  showHam: boolean = true;
  
  constructor(
    private loginApiService: LoginApiService
    ) { 
      
    this.loginApiService.userLoggedIn.subscribe( value => {
      this.userLoggedIn = value });

    this.loginApiService.user.subscribe( value => {
      this.user = value });

    }
  
  ngOnInit(): void {
    
  }

  logout(): void {
    this.loginApiService.logout();
  }

  toggleHamburger():void {
    this.showHam = !this.showHam;
  }
  
  


}
