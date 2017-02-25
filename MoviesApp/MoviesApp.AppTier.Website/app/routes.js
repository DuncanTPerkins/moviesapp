"use strict";
var movie_search_component_1 = require("./movies/movie-search-component");
var movies_list_component_1 = require("./movies/movies-list-component");
var movies_list_item_component_1 = require("./movies/movies-list-item-component");
exports.AppRoutes = [
    { path: 'movies', component: movies_list_component_1.MoviesList },
    { path: 'movies/:id', component: movies_list_item_component_1.MoviesListItem },
    { path: 'search', component: movie_search_component_1.MovieSearch },
    { path: '', redirectTo: 'search', pathMatch: 'full' }
];
//# sourceMappingURL=routes.js.map