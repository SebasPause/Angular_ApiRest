"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var testing_1 = require("@angular/core/testing");
var comment_service_1 = require("./comment.service");
describe('CommentService', function () {
    beforeEach(function () { return testing_1.TestBed.configureTestingModule({}); });
    it('should be created', function () {
        var service = testing_1.TestBed.get(comment_service_1.CommentService);
        expect(service).toBeTruthy();
    });
});
//# sourceMappingURL=comment.service.spec.js.map