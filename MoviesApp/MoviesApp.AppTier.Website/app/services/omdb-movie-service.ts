import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Rx';
import { OmdbMovie } from '../models/omdb-movie';
import { Http, Response } from '@angular/http';

@Injectable()
export class OmdbMovieService {
    private url: string = 'http://www.omdbapi.com/?';
    private searchstring: string = this.url + 's=';
    private retrievestring: string = this.url + 'i=';

    constructor(private http: Http) {
    }

    public SearchByTitle(id: string): Observable<OmdbMovie[]> {
        return this.http.get(this.searchstring + id)
            .map((response: Response) => <OmdbMovie[]>response.json())
            .catch(this.handleError);
    }

    public GetById(id: string): Observable<OmdbMovie> {
        return this.http.get(this.retrievestring + id)
            .map((Response: Response) => <OmdbMovie>Response.json())
            .catch(this.handleError);
    }

    private handleError(error: Response) {
        return Observable.throw(error.statusText);
    }
}