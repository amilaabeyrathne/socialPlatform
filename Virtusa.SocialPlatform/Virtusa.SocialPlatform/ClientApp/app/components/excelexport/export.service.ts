import { Injectable, Inject } from '@angular/core';
import { Http, RequestOptions, Headers, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

@Injectable()
export class ExportService {
    private getUrl = 'api/excelexport/';

    private postUrl = 'api/excelexport/';
    private headers = new Headers({ 'Content-Type': 'application/json' });
    private options = new RequestOptions({
        //withCredentials: true,
        headers: this.headers
    });


    constructor(private http: Http, @Inject('BASE_URL')
    private originUrl: string) { }

    exportData() {
        return this.http.post(this.originUrl + this.postUrl, this.options)
            .map((res: Response) =>
            {
                let path = res.json();
                return path;
            })
            .catch(this.handleError);
    }

    private handleError(error: any) {
        console.error('server error:', error);
        if (error instanceof Response) {
            let errMessage = "";
            try {
                let errMessage = "";
                errMessage = error.json().error;
            } catch (err) {
                //errMessage = error.statusText;
            }
            return Observable.throw(errMessage);
        }
        return Observable.throw(error || 'ASP.NET Core server error');
    }

}