import { Injectable } from '@angular/core';
import { MarketplaceApiService } from '../marketplace-api/marketplace-api.service';
import { OfferModel } from '../marketplace-api/models/offer.model';
import { BehaviorSubject } from 'rxjs';
import { PaginationModel } from 'src/app/pagination/pagination.component';

@Injectable({
  providedIn: 'root'
})
export class PagingService {

  public currentIndex: number = 1;
  public totalPages: number = 0;
  public pagesList: Array<OfferModel> = [];
  public pageSize: number = 4;
  public paginationModels: BehaviorSubject<PaginationModel[]> = new BehaviorSubject<PaginationModel[]>(null);

  constructor(private marketApi: MarketplaceApiService) { }

  Items(index: number): void {

    //pulling all offers as the amount is small and manageable
    //larger systems would have an API that fetches offers/{index}/{limit} and receives the limit amount of offers
    //With more time, this long code could be refactored into smaller components for the purpose of being more easily extensible
    this.marketApi.getOffers().subscribe(value => {
      this.totalPages = Math.ceil((value.length)/(this.pageSize));
      
      this.pagesList = value;
      
      this.currentIndex = index;
      let newIndex: number = (index == 1 ? 0 : ((index-1)*4));

      this.marketApi.saveOfferState(this.pagesList.slice(newIndex,newIndex+this.pageSize));
    
    
      let paginationModels: PaginationModel[] = [];
      let leftState = true;
      let rightState = true;
      let blueFlag = false;
      
      for(let i: number = 0; i<this.totalPages;i++)
      {
        leftState = true;
        rightState = true;
        blueFlag = false;

        if(i==this.pageSize) rightState= false;
        if(i==1) leftState = false;
        if(index==i+1) blueFlag = true;

        paginationModels[i] = {
          pageNumber: i+1,
          leftEnd: leftState,
          rightEnd: rightState,
          blueFlag: blueFlag

        }
        console.log(i)
      }
      this.savePaginationModels(paginationModels)
    });
  }

  savePaginationModels(paginationModel: PaginationModel[]): void {
    this.paginationModels.next(paginationModel)
  }

}
