import { Component, OnInit } from '@angular/core';
import { OmdbMovie } from '../models/omdb-movie';
import { Observable } from 'rxjs/Rx';
import { OmdbMovieService } from '../services/omdb-movie-service';
import { FormControl, FormsModule, ReactiveFormsModule } from '@angular/forms';

@Component({
    selector: 'movie-search',
    templateUrl: './app/movies/movie-search.html',
    styleUrls: ['./app/movies/movie-search.css']
})
export class MovieSearch implements OnInit {
    SearchQuery = new FormControl();
    FilteredResult: OmdbMovie[];
    constructor(private omdbmovieservice: OmdbMovieService) {

    }

    ngOnInit(): void {
        this.SearchQuery.valueChanges
            .debounceTime(400)
            .startWith("")
            .subscribe((data: string) => {
                this.omdbmovieservice.SearchByTitle(data as string)
                    .subscribe((response: any) => {
                        this.FilteredResult = response.Search as OmdbMovie[];
                    });
            });
    }
}