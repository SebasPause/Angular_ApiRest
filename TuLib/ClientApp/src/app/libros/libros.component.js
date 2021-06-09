"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.LibrosComponent = exports.Libro = void 0;
var Libro = /** @class */ (function () {
    function Libro(Id, ApplicationUserId, Autor, Descripcion, FechaPublicado, Publicado, Photo) {
        this.Id = Id;
        this.ApplicationUserId = ApplicationUserId;
        this.Autor = Autor;
        this.Descripcion = Descripcion;
        this.FechaPublicado = FechaPublicado;
        this.Publicado = Publicado;
        this.Photo = Photo;
    }
    return Libro;
}());
exports.Libro = Libro;
var LibrosComponent = /** @class */ (function () {
    function LibrosComponent(bookService) {
        this.bookService = bookService;
    }
    LibrosComponent.prototype.ngOnInit = function () {
        //this.getAll();
    };
    return LibrosComponent;
}());
exports.LibrosComponent = LibrosComponent;
//# sourceMappingURL=libros.component.js.map