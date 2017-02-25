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
var movietag_1 = require("../models/movietag");
var omdb_movie_service_1 = require("../services/omdb-movie-service");
var router_1 = require("@angular/router");
var movie_tag_service_1 = require("../services/movie-tag-service");
var material_1 = require("@angular/material");
var forms_1 = require("@angular/forms");
var MoviesListItem = (function () {
    function MoviesListItem(movieservice, movietagservice, omdbmovieservice, route, snackbar) {
        this.movieservice = movieservice;
        this.movietagservice = movietagservice;
        this.omdbmovieservice = omdbmovieservice;
        this.route = route;
        this.snackbar = snackbar;
        this.buttoncolor = "accent";
        this.taginput = new forms_1.FormControl();
        this.deleteswitch = new forms_1.FormControl();
        this.tagfab = new forms_1.FormControl();
    }
    MoviesListItem.prototype.ngOnInit = function () {
        var _this = this;
        this.taginput.valueChanges
            .subscribe(function (data) {
            if (data === "") {
                _this.tagfab.disable();
            }
            else {
                _this.tagfab.enable();
            }
        });
        this.deleteswitch.valueChanges
            .subscribe(function (data) {
            if (data === true) {
                _this.buttoncolor = "warn";
            }
            if (data === false) {
                _this.buttoncolor = "accent";
            }
        });
        this.id = this.route.snapshot.params['id'];
        this.movieservice.GetById(this.id)
            .subscribe(function (movie) {
            _this.movie = movie;
            //if the movie isn't in the database yet,   
            if (_this.movie.ImdbId == null) {
                _this.movie = null;
                //get the omdb equivalent,
                _this.omdbmovieservice.GetById(_this.id)
                    .subscribe(function (omdbmovie) {
                    _this.omdbmovie = omdbmovie; //remove this
                    //post it to the database,
                    _this.movieservice.CreateMovie(_this.omdbmovie)
                        .subscribe(function (movie) {
                        //and get the new movie object back
                        _this.movie = movie;
                    });
                });
            }
        });
    };
    MoviesListItem.prototype.TagClick = function (tag) {
        if (this.buttoncolor === "accent") {
        }
        if (this.buttoncolor === "warn") {
            var filteredtags = this.movie.MovieTags.filter(function (item) { return item.TagId === tag.TagId; });
            var index = this.movie.MovieTags.indexOf(tag, 0);
            if (index > -1) {
                this.movie.MovieTags.splice(index, 1);
            }
            this.movietagservice.DeleteMovieRelationship(tag, this.movie.ImdbId)
                .subscribe(function (data) {
                //has to be subscribed to
            });
            this.OpenSnackBar();
        }
    };
    MoviesListItem.prototype.OpenSnackBar = function () {
        var config = new material_1.MdSnackBarConfig();
        config.duration = 2000;
        this.snackbar.open("Tag Removed from Movie.", "Ok", config);
    };
    MoviesListItem.prototype.CreateTag = function () {
        var _this = this;
        var movietag = new movietag_1.MovieTag();
        movietag.TagDescription = this.taginput.value;
        this.movietagservice.CreateMovieTag(movietag, this.movie.ImdbId)
            .subscribe(function (movietag) {
            _this.movie.MovieTags = _this.movie.MovieTags.concat(movietag);
            _this.taginput.setValue("");
        });
    };
    return MoviesListItem;
}());
MoviesListItem = __decorate([
    core_1.Component({
        selector: 'movies-list-item',
        templateUrl: './app/movies/movies-list-item.html',
        styleUrls: ['./app/movies/movies-list-item.css']
    }),
    __metadata("design:paramtypes", [movie_service_1.MovieService,
        movie_tag_service_1.MovieTagService,
        omdb_movie_service_1.OmdbMovieService,
        router_1.ActivatedRoute,
        material_1.MdSnackBar])
], MoviesListItem);
exports.MoviesListItem = MoviesListItem;
//# sourceMappingURL=movies-list-item-component.js.map