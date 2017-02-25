"use strict";
var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var base_service_1 = require("./base-service");
var core_1 = require("@angular/core");
var Rx_1 = require("rxjs/Rx");
var http_1 = require("@angular/http");
var http_2 = require("@angular/http");
var MovieTagService = (function (_super) {
    __extends(MovieTagService, _super);
    function MovieTagService(http) {
        var _this = _super.call(this) || this;
        _this.http = http;
        _this._url = _this._baseurl + 'movietags/';
        return _this;
    }
    //fix
    MovieTagService.prototype.GetById = function (id) {
        return this.http.get(this._url + id)
            .map(function (response) { return response.json(); })
            .catch(this.handleError);
    };
    MovieTagService.prototype.GetAllMovieTags = function () {
        return this.http.get(this._url)
            .map(function (response) {
            return response.json();
        })
            .catch(this.handleError);
    };
    //make classes interfaces
    MovieTagService.prototype.CreateMovieTag = function (movietag, movieid) {
        //base class
        var headers = new http_2.Headers({ "Content-Type": 'application/json' });
        var options = new http_2.RequestOptions({ headers: headers });
        return this.http.post(this._url + movieid, movietag, options)
            .map(function (response) {
            return response.json();
        })
            .catch(this.handleError);
    };
    MovieTagService.prototype.DeleteMovieRelationship = function (tag, movieid) {
        var headers = new http_2.Headers({ "Content-Type": 'application/json' });
        var options = new http_2.RequestOptions({ headers: headers });
        return this.http.post(this._url + 'removerelationship/' + movieid, tag, options)
            .map(function (response) { console.log(response); })
            .catch(this.handleError);
    };
    //base class
    MovieTagService.prototype.handleError = function (error) {
        console.log(error);
        return Rx_1.Observable.throw(error.statusText);
    };
    return MovieTagService;
}(base_service_1.BaseService));
MovieTagService = __decorate([
    core_1.Injectable(),
    __metadata("design:paramtypes", [http_1.Http])
], MovieTagService);
exports.MovieTagService = MovieTagService;
//# sourceMappingURL=movie-tag-service.js.map