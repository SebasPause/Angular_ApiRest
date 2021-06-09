import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { NavigationExtras, Router } from '@angular/router';
import { BookService } from '../shared/book.service';
import { Book } from '../shared/models/book';
import { UserService } from '../shared/user.service';

export class Libro {
  constructor(
    public Id: any,
    public ApplicationUserId: string,
    public Autor: string,
    public Descripcion: any,
    public FechaPublicado: Date,
    public Publicado: boolean,
    public Photo: any
  ) { }
}


@Component({
  selector: 'app-libros',
  templateUrl: './libros.component.html',
  styleUrls: ['./libros.component.css']
})
export class LibrosComponent implements OnInit {

  books: Book[];
  publicarLibro: Book;

  constructor(private bookService: BookService,private router: Router) {
  }

  ngOnInit() {
    this.getAll();
  }

  public getAll(): void {
    this.bookService.GetAll()
      .then((x) => {
        this.books = x;
        console.log(x);
      });
  }

  verContenido(bookID: any) {
    let navigationExtras: NavigationExtras = {
      queryParams: {
        idPagina: bookID
      }
    }
    this.router.navigate(['/contenido'], navigationExtras);
  }

  verComentarios(bookID: any) {
    let navigationExtras: NavigationExtras = {
      queryParams: {
        idPagina: bookID
      }
    }
    this.router.navigate(['/valoraciones'], navigationExtras);
  }

  publicar(item: Book,valor: any) {
    this.publicarLibro = item;
    this.publicarLibro.Publicado = true;
    this.publicarLibro.Estado = 'Aceptado';
    this.bookService.editBook(this.publicarLibro);
    location.reload();
  }

  quitarPublicacion(item: Book, valor: any) {
    this.publicarLibro = item;
    this.publicarLibro.Publicado = false;
    this.publicarLibro.Estado = 'Rechazado';
    this.bookService.editBook(this.publicarLibro);
    location.reload();
  }

  getColor(estado) {
    switch (estado) {
      case 'Pendiente':
        return 'orange';
      case 'Aceptado':
        return 'green';
      case 'Rechazado':
        return 'red';
    }
  }

}
