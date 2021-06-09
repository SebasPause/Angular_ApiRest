import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Comentario } from './models/comment';
import { Page } from './models/page';

@Injectable({
  providedIn: 'root'
})
export class CommentService {

  constructor(private http: HttpClient) { }

  public getBookById(bookID: string) {
    let headers = new HttpHeaders({ 'Authorization': 'Bearer ' + localStorage.getItem('token') });
    return this.http.get<Comentario[]>(`/api/valoraciones/GetById?bookID=${bookID}`, { headers })
      .toPromise();
  }

  public deleteComment(id: any) {
    let headers = new HttpHeaders({ 'Authorization': 'Bearer ' + localStorage.getItem('token') });
    return this.http.delete(`/api/valoraciones/DeleteById?Id=${id}`, { headers })
      .toPromise();
  }
}
