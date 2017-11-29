import { Component } from '@angular/core';
import { Http } from '@angular/http';
import { Router, ActivatedRoute } from '@angular/router';
import { SessionsService } from './sessions.service';
import { ISessions} from './sessions.interface';
import { NgForm } from "@angular/forms";


@Component({
    selector: 'add-sessions',
    templateUrl: './add-sessions.component.html',
    styleUrls: ['./sessions.component.css'],
    providers: [SessionsService]
})

export class AddSessionsComponent {
    isAddSession: boolean = true;
    isManageSession: boolean = false;

    lblSessionTitle: string = "Add Sessions";
    lblSessionName: string = "Session Name";
    lblTrainer: string = "Trainer";
    lblSessionDate: string = "Session Date";

    errorMessage: string = "";
    sessions: ISessions = {
        id: 0,
        sessionName: '',
        trainer: '',
        sessionDate: new Date().toLocaleString()
    };


    constructor(private sessionsService: SessionsService,
        private router: Router) {
        this.isAddSession = true;
    }

    onSubmit() {
        if (this.sessions.sessionName) {
            this.sessionsService.sessionSave(this.sessions)
                .subscribe((result: number) => {
                    if (result == 1) {
                        this.router.navigateByUrl('/api/sessions');
                    }
                    else {
                        this.errorMessage = 'Unable to add session';
                    }
                },
                (err: any) => console.log(err));;
        }
        else {
            console.log("Invalid Form Submitted!");
        }
    }

    //cancelAdd() {
    //    debugger
    //    //window.history.back();
    //    //this.router.navigateByUrl('/api/session');
    //    //this.location.back(); 
    //    this.isManageSession = true;
    //    this.isAddSession = false;
    //    //this.router.navigate(["session"]);
    //}

}