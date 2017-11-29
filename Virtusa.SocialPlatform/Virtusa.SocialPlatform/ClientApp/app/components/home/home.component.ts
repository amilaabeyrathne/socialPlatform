import { Component } from '@angular/core';

@Component({
    selector: 'home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.css'],
    providers: [HomeService],
})
export class HomeComponent {

    constructor(private competitionService: CompetitionService/*private popup: Popup*/) {
        this.competition = new Competition();
    }

}
