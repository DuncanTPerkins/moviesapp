"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var core_1 = require("@angular/core");
var Rx_1 = require("rxjs/Rx");
var http_1 = require("@angular/http");
var OmdbMovieService = (function () {
    function OmdbMovieService(http) {
        this.http = http;
        this.url = 'http://www.omdbapi.com/?';
        this.searchstring = this.url + 's=';
        this.retrievestring = this.url + 'i=';
    }
    OmdbMovieService.prototype.SearchByTitle = function (id) {
        return this.http.get(this.searchstring + id)
            .map(function (response) { return response.json(); })
            .catch(this.handleError);
    };
    OmdbMovieService.prototype.GetById = function (id) {
        return this.http.get(this.retrievestring + id)
            .map(function (Response) { return Response.json(); })
            .catch(this.handleError);
    };
    OmdbMovieService.prototype.handleError = function (error) {
        return Rx_1.Observable.throw(error.statusText);
    };
    return OmdbMovieService;
}());
OmdbMovieService = __decorate([
    core_1.Injectable(),
    __metadata("design:paramtypes", [http_1.Http])
], OmdbMovieService);
exports.OmdbMovieService = OmdbMovieService;
//# sourceMappingURL=omdb-movie-service.js.map