import { Component, OnInit } from '@angular/core';
import { NewsService } from './news.service';
import { News } from './news';

@Component({
    selector: 'add-news',
    templateUrl: './add-news.component.html',
    providers: [NewsService]
})
export class AddNewsComponent implements OnInit {

    minDate = new Date().toLocaleString();
    errorMessage: string = "";
    constructor(private newsService: NewsService) {

        this.newsItem = new News();
        //this.minDate = new Date().toLocaleString();
    }

    categories = ['General', 'Blogging', 'White Paper', 'Quiz Competition '];
    newsPriorities = [1, 2, 3, 4, 5, 100];


    ngOnInit() {

    }

    private newsItem: News;
    private result: number;


    onSubmit()
    {
        this.newsItem.id = 0,
        this.newsItem.createdBy = 'Madurika Welivita';
        this.newsItem.lastModified = new Date().toLocaleString();
        this.newsItem.dateCreated = new Date().toLocaleString();
        this.newsItem.eventCode = 'TechMonth';
        this.newsItem.isPublished = false,


            this.newsService.create(this.newsItem)
            .subscribe((result: number) =>
            {
                    if (result == 1)
                    {
                        //this.router.navigate(['api/registrations/']);
                        this.result = result;
                    }
                    else
                    {
                        this.errorMessage = 'Unable to create the news';
                    }
            }, (err: any) => console.log(err));
    }

}
