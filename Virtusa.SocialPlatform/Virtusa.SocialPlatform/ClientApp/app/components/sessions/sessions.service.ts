import { Injectable, Inject } from '@angular/core';
import { Http, RequestOptions, Headers, Response } from '@angular/http';
import { ISessions} from './sessions.interface';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

@Injectable()
export class SessionsService {
    private sessionsGetUrl = 'api/sessions/';
    private sessionsPostUrl = 'api/sessions/';
    private sessionsDelUrl = 'api/sessions/deletesession/';
    private sessionsPuttUrl = 'api/sessions/';

    private headers = new Headers({ 'Content-Type': 'application/json' });
    private options = new RequestOptions({
        //withCredentials: true,
        headers: this.headers
    });


    constructor(private http: Http, @Inject('BASE_URL')
    private originUrl: string) { }

    sessionSave(sessionModel: ISessions): Observable<number> {
        return this.http.post(this.originUrl + this.sessionsPostUrl, JSON.stringify(sessionModel), this.options)
            .map((res: Response) => res.json())
            .catch(this.handleError);
    }

    getSessionsData(): Observable<ISessions[]> {
        return this.http.get(this.originUrl + this.sessionsGetUrl)
            .map((res: Response) => {
                let sessions = res.json();
                return sessions;
            })
            .catch(this.handleError);
    }

    editSession(sessionModel: ISessions): Observable<number> {
        return this.http.put(this.originUrl + this.sessionsPuttUrl, JSON.stringify(sessionModel), this.options)
            .map((res: Response) => res.json())
            .catch(this.handleError);
    }

    sessionDelete(id: number): Observable<number> {
        return this.http.delete(this.originUrl + this.sessionsDelUrl + id, this.options)
            .map((res: Response) => res.json())
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