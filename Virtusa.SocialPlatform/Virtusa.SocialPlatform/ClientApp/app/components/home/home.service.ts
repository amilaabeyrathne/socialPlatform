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

      private headers = new Headers({ 'Content-Type': 'application/json' });
      private options = new RequestOptions({
          //withCredentials: true,
          headers: this.headers
      });

      constructor(
          private http: Http, @Inject('BASE_URL') private originUrl: string ) {
      }

      test(): void
      {
          debugger;
           this.http
              .post(this.originUrl + "/api/Auth", this.options)
              .toPromise()
              .then(res => res.json().data as number)
              .catch(this.handleError);
          
      }

      login(): Promise<RequestResult> {
//debugger;

          return this.http
              .post(this.originUrl + "/api/Auth",  this.options)
              .toPromise()
              .then(response => {
                let result = response.json() as RequestResult;
                if (result.State == 1) {
                    let json = result.Data as any;
                    //debugger;
                    sessionStorage.setItem("token", json.accessToken);
                    //localStorage.setItem('currentUser', JSON.stringify({ token: json.accessToken, name: name }));
                }
                return result;
              })
              .catch(this.handleError);

        //return this.http.post(this.originUrl + "/api/Home", this.options).toPromise()
        //    .then(response => {
        //        let result = response.json() as RequestResult;
        //        if (result.State == 1) {
        //            let json = result.Data as any;

        //            sessionStorage.setItem("token", json.accessToken);
        //        }
        //        return result;
        //    })
        //    .catch(this.handleError);
    }

    private handleError(error: any): Promise<any> {
        console.error('An error occurred', error);
        return Promise.reject(error.message || error);
    }
}