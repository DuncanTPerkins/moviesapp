"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var core_1 = require("@angular/core");
var platform_browser_1 = require("@angular/platform-browser");
var movies_list_component_1 = require("./movies/movies-list-component");
var app_component_1 = require("./app.component");
var movie_service_1 = require("./services/movie-service");
var omdb_movie_service_1 = require("./services/omdb-movie-service");
var movie_tag_service_1 = require("./services/movie-tag-service");
var movie_search_component_1 = require("./movies/movie-search-component");
var material_1 = require("@angular/material");
var http_1 = require("@angular/http");
var forms_1 = require("@angular/forms");
var flex_layout_1 = require("@angular/flex-layout");
var router_1 = require("@angular/router");
var routes_1 = require("./routes");
var movies_list_item_component_1 = require("./movies/movies-list-item-component");
var AppModule = (function () {
    function AppModule() {
    }
    return AppModule;
}());
AppModule = __decorate([
    core_1.NgModule({
        imports: [
            http_1.HttpModule,
            platform_browser_1.BrowserModule,
            material_1.MaterialModule.forRoot(),
            router_1.RouterModule.forRoot(routes_1.AppRoutes),
            forms_1.FormsModule,
            forms_1.ReactiveFormsModule,
            flex_layout_1.FlexLayoutModule
        ],
        declarations: [app_component_1.AppComponent, movies_list_component_1.MoviesList, movie_search_component_1.MovieSearch, movies_list_item_component_1.MoviesListItem],
        providers: [movie_service_1.MovieService, omdb_movie_service_1.OmdbMovieService, movie_tag_service_1.MovieTagService],
        bootstrap: [app_component_1.AppComponent]
    })
], AppModule);
exports.AppModule = AppModule;
//# sourceMappingURL=app.module.js.map