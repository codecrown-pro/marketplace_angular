import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule} from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { OfferListComponent } from './offers/offer-list/offer-list.component';
import { OfferItemComponent } from './offers/offer-item/offer-item.component';
import { OfferCreationComponent } from './offers/offer-creation/offer-creation.component';
import { LoginComponent } from './authentication/login/login.component';

import { LoginApiService } from './core/login-api/login-api.service';
import { MarketplaceApiService } from './core/marketplace-api/marketplace-api.service';
import { PaginationComponent } from './pagination/pagination.component';


@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    OfferListComponent,
    OfferItemComponent,
    OfferCreationComponent,
    LoginComponent,
    PaginationComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [
    LoginApiService,
    MarketplaceApiService
    
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
