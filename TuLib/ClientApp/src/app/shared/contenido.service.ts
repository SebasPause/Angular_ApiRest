import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Page } from './models/page';

@Injectable({
  providedIn: 'root'
})
export class ContenidoService {

  constructor(private http: HttpClient) { }

  public getBookById(bookID: string) {
    let headers = new HttpHeaders({ 'Authorization': 'Bearer ' + localStorage.getItem('token') });
    return this.http.get<Page[]>(`/api/contenido/GetById?bookID=${bookID}`, { headers })
      .toPromise();
  }
}
