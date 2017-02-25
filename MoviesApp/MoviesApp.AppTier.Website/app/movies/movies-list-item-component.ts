import { Component } from '@angular/core';
import { MovieService } from '../services/movie-service';
import { Observable } from "rxjs/Rx";
import { Movie } from '../models/movie';
import { MovieTag } from '../models/movietag';
import { OmdbMovie } from '../models/omdb-movie';
import { OmdbMovieService } from '../services/omdb-movie-service';
import { ActivatedRoute } from '@angular/router';
import { MovieTagService } from '../services/movie-tag-service';
import { MdSnackBar, MdSnackBarConfig } from '@angular/material';
import { FormControl, FormsModule, ReactiveFormsModule } from '@angular/forms';

@Component({
    selector: 'movies-list-item',
    templateUrl: './app/movies/movies-list-item.html',
    styleUrls: ['./app/movies/movies-list-item.css']
})
export class MoviesListItem {
    private id: string;
    private omdbmovie: OmdbMovie;
    private movie: Movie;
    private buttoncolor: string = "accent";
    private taginput = new FormControl();
    private deleteswitch = new FormControl();
    private tagfab = new FormControl();
    constructor(
        private movieservice: MovieService,
        private movietagservice: MovieTagService,
        private omdbmovieservice: OmdbMovieService,
        private route: ActivatedRoute,
        private snackbar: MdSnackBar
    ) {}

    ngOnInit() {
        this.taginput.valueChanges
            .subscribe((data: any) => {
                if (data === "") {
                    this.tagfab.disable();
                } else {
                    this.tagfab.enable();
                }
            });
        this.deleteswitch.valueChanges
            .subscribe((data: any) => {
                if (data === true) {
                    this.buttoncolor = "warn";
                }
                if (data === false) {
                    this.buttoncolor = "accent";
                }
            });

        this.id = this.route.snapshot.params['id'];
        this.movieservice.GetById(this.id)
            .subscribe((movie: Movie) => {
                this.movie = movie;
                //if the movie isn't in the database yet,   
                if (this.movie.ImdbId == null) {
                    this.movie = null;
                    //get the omdb equivalent,
                    this.omdbmovieservice.GetById(this.id)
                        .subscribe((omdbmovie: OmdbMovie) => {
                            this.omdbmovie = omdbmovie; //remove this
                            //post it to the database,
                            this.movieservice.CreateMovie(this.omdbmovie)
                                .subscribe((movie: Movie) => {
                                    //and get the new movie object back
                                    this.movie = movie;
                                });
                        });
                }
            });
    }

    private TagClick(tag: MovieTag) {
        if (this.buttoncolor === "accent") { //open other movies with this tag dialog
            
        }
        if (this.buttoncolor === "warn") { //open snackbar and delete movietag
            let filteredtags: MovieTag[] = this.movie.MovieTags.filter((item) => item.TagId === tag.TagId);
            let index = this.movie.MovieTags.indexOf(tag, 0);
            if (index > -1) {
                this.movie.MovieTags.splice(index, 1);
            }
            this.movietagservice.DeleteMovieRelationship(tag, this.movie.ImdbId)
                .subscribe((data: any) => {
                    //has to be subscribed to
                });
            this.OpenSnackBar();          
        }
    }

    private OpenSnackBar() {
        let config = new MdSnackBarConfig();
        config.duration = 2000;
        this.snackbar.open("Tag Removed from Movie.", "Ok", config);
    }

    private CreateTag() {
        let movietag = new MovieTag();
        movietag.TagDescription = this.taginput.value;
        this.movietagservice.CreateMovieTag(movietag, this.movie.ImdbId)
            .subscribe((movietag: MovieTag) => {
                this.movie.MovieTags = this.movie.MovieTags.concat(movietag);
                this.taginput.setValue("");
            });
    }
} 