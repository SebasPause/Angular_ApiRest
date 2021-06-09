import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CommentService } from '../shared/comment.service';
import { Comentario } from '../shared/models/comment';

@Component({
  selector: 'app-valoraciones',
  templateUrl: './valoraciones.component.html',
  styleUrls: ['./valoraciones.component.css']
})
export class ValoracionesComponent implements OnInit {

  bookID: string;
  sub: any;
  public comments: Array<Comentario> = [];
  public selectedComment;

  constructor(private route: ActivatedRoute, private commentService: CommentService) { }

  ngOnInit() {
    this.sub = this.route.queryParams.subscribe(params => {
      console.log(params);
      this.bookID = params.idPagina;
    });
    console.log(this.bookID);
    this.getBookById(this.bookID);
  }

  public getBookById(id: string): void {
    this.commentService.getBookById(id)
      .then((x) => {
        this.comments = x;
        console.log(this.comments);
      });
  }

  borrar(id: any) {
    this.commentService.deleteComment(id);
    location.reload();
  }

}
