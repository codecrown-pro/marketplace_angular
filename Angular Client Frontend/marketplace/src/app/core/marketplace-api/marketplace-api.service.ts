import {Injectable} from '@angular/core';
import {Observable, of} from 'rxjs';
import {HttpClient} from '@angular/common/http';
import {catchError, tap} from 'rxjs/operators';
import {OfferModel} from './models/offer.model';
import {Category} from '../../offers/models/category.model';
import {BehaviorSubject} from 'rxjs';


@Injectable()
export class MarketplaceApiService {

  private readonly marketplaceApiUrl = 'https://localhost:5001/offer';
  private readonly marketplaceApiUrlCategories = 'https://localhost:5001/category'

  public currentOffers: BehaviorSubject<OfferModel[]> = new BehaviorSubject<OfferModel[]>(null);

  public categories: BehaviorSubject<Category[]> = new BehaviorSubject<Category[]>(null);

  public model: OfferModel;

  constructor(private http: HttpClient) 
    { }

  getOffers(): Observable<OfferModel[]> {
    return this.http.get<OfferModel[]>(this.marketplaceApiUrl).pipe(
      tap(_ => console.log('offers fetched')),
      catchError(this.handleError<OfferModel[]>('getOffers'))
    );
  }

  postOffer(offer: OfferModel): Observable<OfferModel> {
    return this.http.post<OfferModel>(`${this.marketplaceApiUrl}/${offer.categoryId}/${offer.description}/${offer.location}/${offer.pictureUrl}/${offer.title}/${offer.userId}`, offer)
      .pipe(
      tap(_ => console.log('postoffer attempted')),
      catchError(this.handleError<OfferModel>('postOffer'))
    );
  }

  getCategories(): Observable<Category[]> {
    return this.http.get<Category[]>(this.marketplaceApiUrlCategories)
      .pipe(
      tap(_ => console.log('get categories attempted')),
      catchError(this.handleError<Category[]>('getCategories'))
    );
  }

  saveOfferState(offers: OfferModel[]): void {
    this.currentOffers.next(offers);
  }

  handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.log('here')
      console.log(error);

      return of(result as T);
    }
  }
}
