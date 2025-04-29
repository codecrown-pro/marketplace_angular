import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { catchError, tap } from 'rxjs/operators';
import { User } from './models/user.model';
import { BehaviorSubject } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class LoginApiService {

  private readonly loginUrl = 'https://localhost:5001/user';

  public user: BehaviorSubject<User> = new BehaviorSubject<User>(null);
  public userLoggedIn: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  
  constructor(
    private http: HttpClient,
    ) { }

  verifyLoginDetails(username: string): Observable<User> {
    return this.http.get<User>(`${this.loginUrl}/name/name?username=${username}`).pipe(
      tap(_ => console.log('login attempted')),
      catchError(this.handleError<User>('verifyLoginDetails'))
    );
  }

  createUser(username: string): Observable<User> {
    return this.http.post<User>(`${this.loginUrl}/${username}`, username).pipe(
      tap(_ => console.log('create user attempted')),
      catchError(this.handleError<User>('createUser'))
    );
  }

  saveLoginState(user: User): void {
    this.userLoggedIn.next(true);
    this.user.next(user);
  }

  logout(): void {
    this.userLoggedIn.next(false);
    this.user.next(null);
  }

  handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.log(error);

      return of(result as T);
    }
  }
  
}
