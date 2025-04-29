import {Component, Input, OnInit} from '@angular/core';
import { MarketplaceApiService } from '../../core/marketplace-api/marketplace-api.service';
import { Router } from '@angular/router';
import { LoginApiService } from 'src/app/core/login-api/login-api.service';
import {FormGroup} from '@angular/forms';
import { Category } from '../models/category.model';
import { OfferModel, OfferModelRequest } from '../../core/marketplace-api/models/offer.model';
import { User } from 'src/app/core/login-api/models/user.model';
import { PagingService } from 'src/app/core/paging-service/paging.service';


@Component({
  selector: 'app-offer-creation',
  templateUrl: './offer-creation.component.html',
  styleUrls: ['./offer-creation.component.scss']
})
export class OfferCreationComponent implements OnInit {

  offerForm: FormGroup;
  isLoggedIn: boolean = false;
  stateUser: User = null;

  @Input()
  categories: Category[];

  constructor(private marketplaceApi: MarketplaceApiService, private loginApi: LoginApiService, private router: Router, private pageService: PagingService) {
    this.marketplaceApi.categories.subscribe( value => {
      this.categories = value; });
   }

  ngOnInit(): void {
    this.marketplaceApi.getCategories().subscribe(s => {
      this.marketplaceApi.categories.next(s);
    });
    this.loginApi.userLoggedIn.subscribe(value => this.isLoggedIn = value);
    this.loginApi.user.subscribe(value => this.stateUser = value)
  }
  //
  async offerSubmit(data): Promise<void> {
    let cate: Category[] = [
      {id: 1, name: "Product"},
      {id: 2, name: "Service"},
      {id: 3, name: "I\'m looking for"},
    ]
    
    let categoryIdTmp: number;
    let offerUser: User;
    let offerUserName: string = crypto.randomUUID().substring(0, 8);

    cate.forEach((u) => {
        if(u.name == data.category) {categoryIdTmp = u.id}
      });

    let cat: Category[];
    this.marketplaceApi.getCategories().subscribe(s => {
      s.forEach((u) => {
        if(u.name == data.category) {categoryIdTmp = u.id}
      });
    });

    if (this.isLoggedIn) {
      offerUser = this.stateUser;
      offerUserName = this.stateUser.username;
    }
    else {
      this.loginApi.createUser(offerUserName).subscribe();
      
    };
    //Refactor with more graceful await/async
    //Must wait for API to do work before moving ahead
    setTimeout(() => {
      this.loginApi.verifyLoginDetails(offerUserName).subscribe( s => {
        this.loginApi.saveLoginState({id: s.id, username: s.username});
        offerUser = {id: s.id, username: s.username};

        let offer: OfferModel = {
          categoryId: categoryIdTmp,
          description: data.description,
          id: data.id,
          location: data.location,
          pictureUrl: data.pictureUrl,
          publishedOn: data.publishedOn,
          title: data.title,
          userId: offerUser.id
        } 
    
        this.marketplaceApi.postOffer(offer).subscribe(_ => {
          this.pageService.Items(1);
        
          let endOfList: number = this.pageService.totalPages;

          this.router.navigate([`list/${endOfList}`]);
        })
      })
    ;}, 1500);
  }
}
