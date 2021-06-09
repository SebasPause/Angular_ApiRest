import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { forEachChild } from 'typescript';
import { ContenidoService } from '../../shared/contenido.service';
import { Page } from '../../shared/models/page';

@Component({
  selector: 'app-contenido',
  templateUrl: './contenido.component.html',
  styleUrls: ['./contenido.component.css']
})
export class ContenidoComponent implements OnInit {

  sub: any;
  public pages: Array<Page> = [];
  bookID: string;
  pageArrayNumber: number = 0;
  public selectedPage;

  @ViewChild('ref', { static: false }) myNameElem: ElementRef;

  constructor(private router: Router, private route: ActivatedRoute, private contenidoService: ContenidoService) {

  }

  ngOnInit() {
    this.sub = this.route.queryParams.subscribe(params => {
      console.log(params);
      this.bookID = params.idPagina;
    });
    console.log(this.bookID);
    this.getBookById(this.bookID);
    
  }

  public getBookById(id: string): void {
    this.contenidoService.getBookById(id)
      .then((x) => {
        this.pages = x;
        this.selectedPage = this.pages[this.pageArrayNumber];
      });
  }

  public avanzar() {
    if (this.pageArrayNumber == this.pages.length - 1) {
      //do nothing
    } else {
      this.pageArrayNumber = this.pageArrayNumber + 1;
      this.selectedPage = this.pages[this.pageArrayNumber];
    }
  }

  public retroceder() {
    if (this.pageArrayNumber == 0) {
      //do nothing
    } else {
      this.pageArrayNumber = this.pageArrayNumber - 1;
      this.selectedPage = this.pages[this.pageArrayNumber];
    }
  }


}
