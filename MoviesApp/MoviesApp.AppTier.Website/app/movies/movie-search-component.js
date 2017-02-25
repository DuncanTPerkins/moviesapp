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
var omdb_movie_service_1 = require("../services/omdb-movie-service");
var forms_1 = require("@angular/forms");
var MovieSearch = (function () {
    function MovieSearch(omdbmovieservice) {
        this.omdbmovieservice = omdbmovieservice;
        this.SearchQuery = new forms_1.FormControl();
    }
    MovieSearch.prototype.ngOnInit = function () {
        var _this = this;
        this.SearchQuery.valueChanges
            .debounceTime(400)
            .startWith("")
            .subscribe(function (data) {
            _this.omdbmovieservice.SearchByTitle(data)
                .subscribe(function (response) {
                _this.FilteredResult = response.Search;
            });
        });
    };
    return MovieSearch;
}());
MovieSearch = __decorate([
    core_1.Component({
        selector: 'movie-search',
        templateUrl: './app/movies/movie-search.html',
        styleUrls: ['./app/movies/movie-search.css']
    }),
    __metadata("design:paramtypes", [omdb_movie_service_1.OmdbMovieService])
], MovieSearch);
exports.MovieSearch = MovieSearch;
//# sourceMappingURL=movie-search-component.js.map