import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DatePipe } from '@angular/common';
import { NewsService } from './news.service';
import { News } from './news';
import { SanitizeHtmlPipe } from '../../../utility/sanitizing';


@Component({
    selector: 'news-detail',
    templateUrl: './news-detail.component.html',
    styles: ['./news-detail.component.css'],
    providers: [NewsService]
})
export class NewsDetailComponent implements OnInit {
    newsItemFromDB: News;

    constructor(private newsService: NewsService, private route: ActivatedRoute) {

    }

    ngOnInit(): void {
        const id = +this.route.snapshot.paramMap.get('id')!;
        if (id) {
            this.newsService
                .getNewsItem(id)
                .subscribe((newsData: News) => {
                    this.newsItemFromDB = newsData;

                });
        }
    }

}


