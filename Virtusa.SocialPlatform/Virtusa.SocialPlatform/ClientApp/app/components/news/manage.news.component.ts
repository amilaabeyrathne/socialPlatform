import { Component, OnInit, ViewChild } from '@angular/core';
import { Http } from '@angular/http';
import { NewsService } from './news.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Popup } from 'ng2-opd-popup';
import { News } from './news';

@Component({
    selector: 'manage-news',
    templateUrl: './manage.news.component.html',
    styleUrls: ['./manage.news.component.css'],
    providers: [NewsService]
})
export class ManageNewsComponent implements OnInit {
    newsFromDB: News[];
    news: News;
    errorMessage: string;
    isNewsItem: boolean;


    lbltile: string = "TiTle";
    lblCategory: string = "Category";
    lblCreatedBy: string = "CreatedBy";
    lblCreatedDate: string = "CreatedDate";
    constructor(private newsService: NewsService, private popup: Popup,
        private router: Router) {
        this.news = new News();
    }

    @ViewChild('popupforeditnews') editnewsPopup: Popup;
    @ViewChild('popupfordelete') deletenewsPopup: Popup;
    @ViewChild('popupforpublish') publishnewsPopup: Popup;
    categories = ['General', 'Blogging', 'White Paper', 'Quiz Competition '];

    ngOnInit() {
        this.newsService
            .getNews()
            .subscribe(newsData => {
                this.newsFromDB = newsData;
            });

    }

    EditNews(newsid: number) {
        this.news = this.newsFromDB.find(x => x.id == newsid) as News;
        this.isNewsItem = true;
        this.editnewsPopup.options = {
            header: "Edit News",
            color: "#5cb85c",
            widthProsentage: 100,
            animationDuration: 1,
            showButtons: true,
            confirmBtnContent: "Edit",
            cancleBtnContent: "Close",
            confirmBtnClass: "btn btn-default",
            cancleBtnClass: "btn btn-default",
            animation: "fadeInDown",
        }

        this.editnewsPopup.show(this.editnewsPopup.options);
    }

    DeleteNews(newsid: number) {
        this.news = this.newsFromDB.find(x => x.id == newsid) as News;
        this.deletenewsPopup.options = {
            header: "Delete news",
            color: "#FF0000",
            widthProsentage: 50,
            animationDuration: 1,
            showButtons: true,
            confirmBtnContent: "Delete",
            cancleBtnContent: "Close",
            confirmBtnClass: "btn btn-default",
            cancleBtnClass: "btn btn-default",
            animation: "fadeInDown",
        }

        this.deletenewsPopup.show(this.deletenewsPopup.options);
    }

    PublishNews(newsid: number) {
        this.news = this.newsFromDB.find(x => x.id == newsid) as News;
        this.publishnewsPopup.options = {
            header: "Publish news",
            color: "#FF0000",
            widthProsentage: 50,
            animationDuration: 1,
            showButtons: true,
            confirmBtnContent: "Publish",
            cancleBtnContent: "Close",
            confirmBtnClass: "btn btn-default",
            cancleBtnClass: "btn btn-default",
            animation: "fadeInDown",
        }

        this.publishnewsPopup.show(this.publishnewsPopup.options);
    }

    sumbitEdit() {
        if (this.news.id) {
            this.newsService.editNews(this.news)
                .subscribe((result: number) => {
                    if (result == 1) {
                        this.router.navigateByUrl('/manage-news');
                        this.editnewsPopup.hide();
                    }
                    else {
                        this.errorMessage = 'Unable to edit news';
                    }
                },
                (err: any) => console.log(err));;
        }
        else {
            console.log("Invalid Form Submitted!");
        }
    }
    sumbitDelete() {
        if (this.news.id) {
            this.newsService.deleteNews(this.news.id)
                .subscribe((result: number) => {
                    if (result == 1) {
                        this.router.navigateByUrl('/manage-news');
                        this.popup.hide();
                    }
                    else {
                        this.errorMessage = 'Unable to delete news';
                    }
                },
                (err: any) => console.log(err));;
        }
        else {
            console.log("Invalid Form Submitted!");
        }
    }

    sumbitPublish() {
       if (this.news.id) {
            this.newsService.publishNews(this.news.id)
                .subscribe((result: number) => {
                    if (result == 1) {
                        this.router.navigateByUrl('/manage-news');
                        this.popup.hide();
                    }
                    else {
                        this.errorMessage = 'Unable to publish news';
                    }
                },
                (err: any) => console.log(err));;
        }
        else {
            console.log("Invalid Form Submitted!");
        }
    }


}