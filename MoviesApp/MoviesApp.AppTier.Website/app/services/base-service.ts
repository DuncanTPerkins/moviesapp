import { Injectable } from '@angular/core';
import { Headers, RequestOptions } from '@angular/http';

@Injectable()
export class BaseService{
    protected _baseurl: string = 'http://localhost:65490/api/';
    protected headers: Headers;
    protected options: RequestOptions;

    constructor() {
        //this.headers = new Headers({ "Content-Type": 'application/json' });
        //this.options = new RequestOptions({ this.headers });
    }
}