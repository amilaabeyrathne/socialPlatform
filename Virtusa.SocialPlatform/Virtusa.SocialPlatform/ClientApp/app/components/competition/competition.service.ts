import { Injectable, Inject } from '@angular/core';
import { Http, RequestOptions, Headers, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

import { Competition } from './competition';

import 'rxjs/add/operator/toPromise';

@Injectable()
export class CompetitionService {

    private competitionUrl = 'api/competition';  // URL to web api

    private headers = new Headers({ 'Content-Type': 'application/json' });
    private options = new RequestOptions({
        //withCredentials: true,
        headers: this.headers
    });

    private deleteUrl = 'api/Competition/';
    private id: number;

    constructor(private http: Http, @Inject('BASE_URL') private originUrl: string) { }

    //Get All competition Items
    getCompetition(): Promise<Competition[]> {
        return this.http.get(this.originUrl + this.competitionUrl, this.options)
            .toPromise()
            .then(response =>
                response.json() as Competition[]
            )
            .catch(this.handleError);
    }

    // Add competition Item
    create(competitionToAdd: Competition): Promise<number> {
        return this.http
            .post(this.originUrl + this.competitionUrl, competitionToAdd, this.options)
            .toPromise()
            .then(res => res.json().data as number)
            .catch(this.handleError);
    }

    // delete competition item
    delete(id: number): Observable<number>
    {
        return this.http.delete(this.originUrl + this.deleteUrl + id, this.options)
            .map((res:Response) => res.json())
            .catch(this.handleError);
            
            
    }

    edit(competitionToUpdate: Competition): Observable<number> {

        return this.http.put(this.originUrl + this.competitionUrl, JSON.stringify(competitionToUpdate), this.options).map((res: Response) => res.json())
            .catch(this.handleError);
    }

    private handleError(error: any): Promise<any> {
        console.error('An error occurred', error); // for demo purposes only
        return Promise.reject(error.message || error);
    }

}






