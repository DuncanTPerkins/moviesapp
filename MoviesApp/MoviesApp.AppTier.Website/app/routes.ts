import { Routes } from '@angular/router';
import { MovieSearch } from './movies/movie-search-component';
import { MoviesList } from './movies/movies-list-component';
import { MoviesListItem } from './movies/movies-list-item-component';

export const AppRoutes: Routes = [
    { path: 'movies', component: MoviesList },
    { path: 'movies/:id', component: MoviesListItem },
    { path: 'search', component: MovieSearch },
    { path: '', redirectTo: 'search', pathMatch: 'full' }
]