import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Book } from './models/book';

@Injectable({
  providedIn: 'root'
})
export class BookService {

  constructor(private http: HttpClient) { }

  public GetAll() {
    let headers = new HttpHeaders({ 'Authorization': 'Bearer ' + localStorage.getItem('token') });
    return this.http.get<Book[]>(`/api/book`, { headers })
      .toPromise();
  }

  public editBook(item: Book) {
    let headers = new HttpHeaders({ 'Authorization': 'Bearer ' + localStorage.getItem('token') });
    return this.http.put(`/api/book/update`, item, { headers })
      .toPromise();
  }
}
