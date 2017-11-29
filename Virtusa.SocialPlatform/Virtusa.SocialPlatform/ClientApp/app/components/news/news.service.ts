import { Injectable, Inject } from '@angular/core';
import { Http, RequestOptions, Headers, Response } from '@angular/http';
import { News } from './news';
import { INews } from './news.interface';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

import 'rxjs/add/operator/toPromise';

@Injectable()
export class NewsService {

    private newsUrl = 'api/news';  // URL to web api
    private newsPuttUrl = 'api/news';
    private newsDeleteUrl = 'api/news/deleteNews/';
    private newsPublishUrl = 'api/news/publishNews/';

    private headers = new Headers({ 'Content-Type': 'application/json' });
    private options = new RequestOptions({
        withCredentials: true,
        headers: this.headers
    });



    constructor(private http: Http, @Inject('BASE_URL') private originUrl: string) { }

    //Get News Item detail
    getNewsItem(id: number): Observable<News> {
        const url = `${this.newsUrl}/${id}`;
        return this.http.get(this.originUrl + url, this.options)
            .map((res: Response) => {
                let news = res.json();
                return news;
            }
            )
            .catch(this.handleError);
    }

    //Get All News Items
   
    getNews(): Observable<News[]> {
        return this.http.get(this.originUrl + this.newsUrl, this.options)
            .map((res: Response) =>
            {
                let news = res.json();
                return news;
            })
            .catch(this.handleError);
    }

    
    // Add News Item res => res.json().data as number
    create(newsToAdd: News): Observable<number> {
        return this.http
            .post(this.originUrl + this.newsUrl, newsToAdd, this.options)
            .map((res: Response) => res.json())
            .catch(this.handleError);
    }

    // edit news items
    editNews(newsModel: News): Observable<number> {

        return this.http.put(this.originUrl + this.newsPuttUrl, JSON.stringify(newsModel), this.options).map((res: Response) => res.json())
            .catch(this.handleError);
    }

    //delete news item
    deleteNews(newsid: number): Observable<number> {
        return this.http.delete(this.originUrl + this.newsDeleteUrl + newsid, this.options)
            .map((res: Response) => res.json())
            .catch(this.handleError);
    }

    //publish new item
    publishNews(newsid: number): Observable<number> {
        return this.http.delete(this.originUrl + this.newsPublishUrl + newsid, this.options)
            .map((res: Response) => res.json())
            .catch(this.handleError);
    }


    //private handleError(error: any): Promise<any> {
    //    console.error('An error occurred', error); // for demo purposes only
    //    return Promise.reject(error.message || error);
    //}
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






