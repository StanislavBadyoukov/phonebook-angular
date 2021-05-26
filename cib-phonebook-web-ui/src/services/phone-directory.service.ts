import { Injectable } from '@angular/core';
import { PhonebookEntry } from '../models/phone-book-entry'
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class PhoneDirectoryService {

  //TODO: this should be in configuration
  private phoneBookUrl = 'http://localhost:53700/api/phonebook/'; 
  
  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json'
    })
  };
  constructor(private http: HttpClient) { }

  getPhoneBookEntries(searchText: string) : Observable<PhonebookEntry[]> {
    return this.http.get<PhonebookEntry[]>(this.phoneBookUrl + searchText, this.httpOptions)
    .pipe(
      catchError(this.handleError<PhonebookEntry[]>('getPhoneBookEntries', []))
    );
  }

  savePhonebookEntry(newEntry: PhonebookEntry) {
    console.log(JSON.stringify(newEntry));
    this.http.post<PhonebookEntry>(this.phoneBookUrl, JSON.stringify(newEntry), this.httpOptions)
    .pipe(
      catchError(this.handleError('savePhonebookEntry', newEntry))
    ).subscribe();
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error);
      return of(result as T);
    };
  }
}