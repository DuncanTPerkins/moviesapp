import { Component, OnInit } from '@angular/core';
import { Movie } from '../models/movie';
import { MovieService } from '../services/movie-service';
@Component({
    selector: 'movies-list',
    templateUrl: './app/movies/movies-list.html'
})
export class MoviesList implements OnInit{
    private _movies: Movie[];
    constructor(private _movieservice: MovieService) {
        
    }
    ngOnInit() {
        this.GetMovies();
    }

    public GetMovies() {
        this._movieservice.GetAllMovies().subscribe((movies: Movie[]) => {
            this._movies = movies;
        });
    }
}