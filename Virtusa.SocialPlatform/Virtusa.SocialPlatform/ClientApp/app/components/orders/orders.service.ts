import { Injectable, Inject } from '@angular/core';
import { Http, RequestOptions, Headers, Response } from '@angular/http';
import { IOrders } from './orders';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';


@Injectable()
export class OrdersService {
    private ordersUrl = 'api/OrderDetails';

    private headers = new Headers({ 'Content-Type': 'application/json' });
    private options = new RequestOptions({
       // withCredentials: true,
        headers: this.headers
    });

    constructor(private http: Http, @Inject('BASE_URL')
    private oriiginUrl: string) { }

    
    add(orderModel: IOrders): Observable<number> {
        
        return this.http.post(this.oriiginUrl + this.ordersUrl, JSON.stringify(orderModel), this.options)
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