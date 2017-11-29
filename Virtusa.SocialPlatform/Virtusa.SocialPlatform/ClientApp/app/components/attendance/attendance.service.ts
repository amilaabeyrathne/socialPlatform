import { Injectable, Inject } from '@angular/core';
import { Http, RequestOptions, Headers, Response } from '@angular/http';
import { IAttendance, ICompetitions, ISessions } from './attendance.interface';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

@Injectable()
export class AttendanceService {

    private compGetUrl = 'api/attendance/getcompetitions/';
    private sessionsGetUrl = 'api/attendance/getsessions/';
    private attendanceAllGetUrl = 'api/attendance/allattendances/';

    private attendancePostUrl = 'api/attendance/';
    //private attendancePuttUrl = 'api/attendance/';
    private attendanceDaleteUrl = 'api/attendance/deleteattendance/';
    private headers = new Headers({ 'Content-Type': 'application/json' });
    private options = new RequestOptions({
        //withCredentials: true,
        headers: this.headers
    });


    constructor(private http: Http, @Inject('BASE_URL')
    private originUrl: string) { }

    attendanceSave(attendanceModel: IAttendance): Observable<number> {
        return this.http.post(this.originUrl + this.attendancePostUrl, JSON.stringify(attendanceModel), this.options)
            .map((res: Response) => res.json())
            .catch(this.handleError);
    }

    getCompetitionsData(): Observable<ICompetitions[]> {
        return this.http.get(this.originUrl + this.compGetUrl)
            .map((res: Response) => {
                let competitions = res.json();
                return competitions;
            })
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

    getAllAttendance(isGroup: boolean): Observable<IAttendance[]> {
        return this.http.get(this.originUrl + this.attendanceAllGetUrl + isGroup, this.options)
            .map((res: Response) => {
                let registrations = res.json();
                return registrations;
            })
            .catch(this.handleError);
    }

    //editAttendance(attendanceModel: IAttendance): Observable<number> {
    //    return this.http.put(this.originUrl + this.attendancePuttUrl, JSON.stringify(attendanceModel), this.options)
    //        .map((res: Response) => res.json())
    //        .catch(this.handleError);
    //}

    deleteAttendance(participantid: number): Observable<number> {
        return this.http.delete(this.originUrl + this.attendanceDaleteUrl + participantid, this.options)
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