import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { NewsService } from './news.service';
import { News } from './news';
import { SanitizeHtmlPipe } from '../../../utility/sanitizing';


@Component({
    selector: 'news',
    templateUrl: './news.component.html',
    styles: ['./news.component.css'],
    providers: [NewsService]
})
export class NewsComponent implements OnInit {
    newsFromDB: News[];


    constructor(private newsService: NewsService) {


    }

    ngOnInit(): void {

        this.newsService
            .getNews()
            .subscribe((newsData: News[]) => {
                this.newsFromDB = newsData;

            });


    }

}


