import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable, of } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';

import { Question } from './question';

const httpOptions = {
  headers: new HttpHeaders({'Content-type': 'application/json'})
};

@Injectable({
  providedIn: 'root'
})
export class QuestionService {

  private questionsUrl = 'http://localhost:3010/api/questions'; // URL to web api

  constructor(private http: HttpClient) { }

   /** GET questions from the server */
  getQuestions():Observable<Question[]> {
    return this.http.get<Question[]>(this.questionsUrl)
      .pipe(
        //tap(heroes => console.log(`fetched questions`)),
        catchError(this.handleError('getQuestions',[]))
      );
  }

  /**
  * Handle Http operation that failed.
  * Let the app continue.
  * @param operation - name of the operation that failed
  * @param result - optional value to return as the observable result
  */
  private handleError<T> (operation = 'operation', result?: T) {
    return (error: any) : Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      //this.log(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }
}
