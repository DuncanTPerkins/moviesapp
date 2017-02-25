import { BaseService } from './base-service';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Rx';
import { Movie } from '../models/movie';
import { OmdbMovie } from '../models/omdb-movie';
import { Http, Response } from '@angular/http';
import { Headers, RequestOptions } from '@angular/http';

@Injectable()
export class MovieService extends BaseService{
    private _url: string = this._baseurl + 'movies/';

    constructor(private http: Http){
        super();
    }

    public GetById(id: string): Observable<Movie>{
        return this.http.get(this._url + id)
            .map((response: Response) => <Movie[]>response.json())
            .catch(this.handleError);
    }

    public GetAllMovies(): Observable<Movie[]> {
        return this.http.get(this._url)
            .map((response: Response) => {
                return <Movie[]>response.json();
            })
            .catch(this.handleError);
    }

    public CreateMovie(omdbmovie: OmdbMovie): Observable<Movie> {
        let headers = new Headers({ "Content-Type": 'application/json' });
        let options = new RequestOptions({ headers: headers });

        return this.http.post(this._url, omdbmovie, options)
            .map((response: Response) => {
                return <Movie>response.json();
            })
            .catch(this.handleError);
    }


    private handleError(error: Response){
        return Observable.throw(error.statusText);
    }
}