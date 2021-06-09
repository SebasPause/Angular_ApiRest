"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var testing_1 = require("@angular/core/testing");
var contenido_service_1 = require("./contenido.service");
describe('ContenidoService', function () {
    beforeEach(function () { return testing_1.TestBed.configureTestingModule({}); });
    it('should be created', function () {
        var service = testing_1.TestBed.get(contenido_service_1.ContenidoService);
        expect(service).toBeTruthy();
    });
});
//# sourceMappingURL=contenido.service.spec.js.map