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
var movie_service_1 = require("../services/movie-service");
var MoviesList = (function () {
    function MoviesList(_movieservice) {
        this._movieservice = _movieservice;
    }
    MoviesList.prototype.ngOnInit = function () {
        this.GetMovies();
    };
    MoviesList.prototype.GetMovies = function () {
        var _this = this;
        this._movieservice.GetAllMovies().subscribe(function (movies) {
            _this._movies = movies;
        });
    };
    return MoviesList;
}());
MoviesList = __decorate([
    core_1.Component({
        selector: 'movies-list',
        templateUrl: './app/movies/movies-list.html'
    }),
    __metadata("design:paramtypes", [movie_service_1.MovieService])
], MoviesList);
exports.MoviesList = MoviesList;
//# sourceMappingURL=movies-list-component.js.map