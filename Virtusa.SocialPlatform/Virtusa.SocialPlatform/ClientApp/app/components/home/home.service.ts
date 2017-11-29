import { Injectable, Inject } from '@angular/core';
import { Http, RequestOptions, Headers, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import "rxjs/add/operator/toPromise";

import { RequestResult } from "./RequestResult";

@Injectable()
export class HomeService {

    private tokeyKey = "token";
    private token: string;

    constructor(
        private http: Http
    ) { }


}