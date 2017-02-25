import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { MoviesList } from './movies/movies-list-component';
import { AppComponent }  from './app.component';
import { MovieService } from './services/movie-service';
import { OmdbMovieService } from './services/omdb-movie-service';
import { MovieTagService } from './services/movie-tag-service';
import { MovieSearch } from './movies/movie-search-component'
import { MaterialModule } from '@angular/material';
import { HttpModule } from '@angular/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FlexLayoutModule } from '@angular/flex-layout';
import { RouterModule } from '@angular/router';
import { AppRoutes } from './routes';
import { MoviesListItem } from "./movies/movies-list-item-component";

@NgModule({
  imports: [ 
    HttpModule,
    BrowserModule,
    MaterialModule.forRoot(),
    RouterModule.forRoot(AppRoutes),
    FormsModule,
    ReactiveFormsModule,
    FlexLayoutModule
    ],
  declarations: [ AppComponent, MoviesList, MovieSearch, MoviesListItem ],
  providers: [MovieService, OmdbMovieService, MovieTagService],
  bootstrap:    [ AppComponent ]
})
export class AppModule { }
