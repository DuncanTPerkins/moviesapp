import { BaseService } from './base-service';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Rx';
import { Movie } from '../models/movie';
import { MovieTag } from '../models/movietag'
import { Http, Response } from '@angular/http';
import { Headers, RequestOptions } from '@angular/http';

@Injectable()
export class MovieTagService extends BaseService {
    private _url: string = this._baseurl + 'movietags/';

    constructor(private http: Http) {
        super();
    }
    //fix
    public GetById(id: string): Observable<MovieTag> {
        return this.http.get(this._url + id)
            .map((response: Response) => <MovieTag>response.json())
            .catch(this.handleError);
    }

    public GetAllMovieTags(): Observable<MovieTag[]> {
        return this.http.get(this._url)
            .map((response: Response) => {
                return <MovieTag[]>response.json();
            })
            .catch(this.handleError);
    }

    //make classes interfaces
    public CreateMovieTag(movietag: MovieTag, movieid: string): Observable<MovieTag> {
        //base class
        let headers = new Headers({ "Content-Type": 'application/json' });
        let options = new RequestOptions({ headers: headers });

        return this.http.post(this._url + movieid, movietag, options)
            .map((response: Response) => {
                return <MovieTag>response.json();
            })
            .catch(this.handleError);
    }

    public DeleteMovieRelationship(tag: MovieTag, movieid: string): Observable<any> {
        let headers = new Headers({ "Content-Type": 'application/json' });
        let options = new RequestOptions({ headers: headers });
        return this.http.post(this._url + 'removerelationship/' + movieid, tag, options)
            .map((response: Response) => {console.log(response)})
            .catch(this.handleError);
    }

    //base class
    private handleError(error: Response) {
        console.log(error);
        return Observable.throw(error.statusText);
    }
}