import { Component, OnInit} from '@angular/core';
import {OfferModel, OfferModelRequest} from '../../core/marketplace-api/models/offer.model';
import { ActivatedRoute } from '@angular/router';
import { BehaviorSubject } from 'rxjs';
import { MarketplaceApiService } from '../../core/marketplace-api/marketplace-api.service';
import { PagingModel } from 'src/app/core/models/paging.model';
import { PagingService } from 'src/app/core/paging-service/paging.service';
import { PaginationModel } from 'src/app/pagination/pagination.component';

@Component({
  selector: 'app-offer-list',
  templateUrl: './offer-list.component.html',
  styleUrls: ['./offer-list.component.scss']
})
export class OfferListComponent implements OnInit {

  currentOffers: OfferModel[];
  paginationModels: PaginationModel[];
  
  //Data sharing via the two services to enact component-wide updates to maintain stateful presence
  constructor(private marketApiService: MarketplaceApiService, public pageService: PagingService, private route: ActivatedRoute) { 
    this.marketApiService.currentOffers.subscribe( value =>{
      this.currentOffers = value;
    });
    this.pageService.paginationModels.subscribe( value => {
      this.paginationModels = value;
    })
  }

  ngOnInit(): void {

    let newIndex: number = 1;
    this.route.params.subscribe(routeParams => {
      if (routeParams.index) newIndex = routeParams.index;
     this.pageService.Items(newIndex);
    })

    console.log('fetched the offers succesfully, loaded them');
  }

  public onUpdate(index: number, item: any)
  {
    return item.id;
  }
  public onUpdatePage(index: number, item: any)
  {
    return item;
  }
}
