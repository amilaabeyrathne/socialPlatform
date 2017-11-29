import { Injectable, Inject } from '@angular/core';
import { Http, RequestOptions, Headers, Response } from '@angular/http';
import { IRegistrations, ICompetitions, ICegs, ITiers, IParticipants } from './registrations.interface';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

@Injectable()
export class RegistrationService {
    private regisGetUrl = 'api/registrations/';
    private compGetUrl = 'api/registrations/getcompetitions/';
    private cegsGetUrl = 'api/registrations/getcegs/';
    private tierGetUrl = 'api/registrations/gettiers/';
    private regisAllGetUrl = 'api/registrations/allregistrations/';
    private getTeamMemberUrl = 'api/registrations/getteammember/';
    
    private regisPostUrl = 'api/registrations/';
    private teamPutUrl = 'api/registrations/teamupdate';
    private regisPuttUrl = 'api/registrations/';
    private regisDaleteUrl = 'api/registrations/deleteregistration/';
    private headers = new Headers({ 'Content-Type': 'application/json' });
    private options = new RequestOptions({
       //withCredentials: true,
       headers: this.headers
    });


    constructor(private http: Http, @Inject('BASE_URL')
        private originUrl: string) { }

    registrationSave(registrationsModel: IRegistrations): Observable<number> {
        return this.http.post(this.originUrl + this.regisPostUrl, JSON.stringify(registrationsModel), this.options)
            .map((res: Response) => res.json())
            .catch(this.handleError);
    }

    registrationGroupSave(registrationsModel: IRegistrations): Observable<number> {
        return this.http.post(this.originUrl + this.regisPostUrl, JSON.stringify(registrationsModel), this.options)
            .map((res: Response) => res.json())
            .catch(this.handleError);
    }

    getCompetitionsData(isGroup: boolean): Observable<ICompetitions[]> {
        return this.http.get(this.originUrl + this.compGetUrl + isGroup, this.options)
            .map((res: Response) =>
            {
                let competitions = res.json();
                return competitions;
            })
            .catch(this.handleError);

    }

    getTiersData(): Observable<ITiers[]> {
        return this.http.get(this.originUrl + this.tierGetUrl)
            .map((res: Response) =>
            {
                let tiers = res.json();
                return tiers;
            })
            .catch(this.handleError);
    }

    getCegsData(): Observable<ICegs[]> {
        return this.http.get(this.originUrl + this.cegsGetUrl, this.options)
            .map((res: Response) => 
            {
                let cegs = res.json();
                return cegs;
            })
            .catch(this.handleError);
    }

    getAllRegistration(isGroup: boolean): Observable<IRegistrations[]> {
        return this.http.get(this.originUrl + this.regisAllGetUrl + isGroup, this.options)
            .map((res: Response) => {
                let registrations = res.json();
                return registrations;
            })
            .catch(this.handleError);
    }

    getTeamMemberById(teamId: number): Observable<any[]> {
        return this.http.get(this.originUrl + this.getTeamMemberUrl + teamId, this.options)
            .map((res: Response) => {
                let participents = res.json();
                return participents;
            })
            .catch(this.handleError);
    }

    editRegistrations(registrationsModel: IRegistrations): Observable<number> {
        return this.http.put(this.originUrl + this.regisPuttUrl, JSON.stringify(registrationsModel), this.options)
            .map((res: Response) => res.json())
            .catch(this.handleError);
    }

    editTeamMember(ParticipentModel: any[]): Observable<number> {
        return this.http.put(this.originUrl + this.teamPutUrl, JSON.stringify(ParticipentModel), this.options)
            .map((res: Response) => res.json())
            .catch(this.handleError);
    }

    deleteRegistrations(participantid: number): Observable<number> {
        return this.http.delete(this.originUrl + this.regisDaleteUrl + participantid, this.options)
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