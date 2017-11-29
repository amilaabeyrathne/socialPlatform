import { Component, OnInit, ViewChild } from '@angular/core';
import { Http } from '@angular/http';
import { SessionsService } from './sessions.service';
import { ISessions } from './sessions.interface';
import { Router, ActivatedRoute } from '@angular/router';
import { NgForm, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Popup } from 'ng2-opd-popup';

declare var SessionJs: any;

@Component({
    selector: 'session',
    templateUrl: './sessions.component.html',
    styleUrls: ['./sessions.component.css', '../common/commom.component.css'],
    providers: [SessionsService]
})

export class SessionsComponent implements OnInit {

    constructor(private sessionsService: SessionsService, private popup: Popup, private router: Router) {
    }

    isAddSession: boolean = false;
    indLoading: boolean = false;
    isManageSession: boolean = true;
    isEdit: boolean = false;

    competitionForm: FormGroup;

    lblSessionName: string = "Session Name";
    lblTrainer: string = "Trainer";
    lblSessionDate: string = "Session Date";

    sessionList: ISessions[];

    sessions: ISessions = {
        id: 0,
        sessionName: '',
        trainer: '',
        sessionDate: new Date().toLocaleString()
    };

    private result: number;
    @ViewChild('sessionAddpop') sessionAddpop: Popup;
    @ViewChild('sessionDeletepop') sessionDeletepop: Popup;
    @ViewChild('sessionEditpop') sessionEditpop: Popup;

    private errorMessage: string;

    modalParams = {
        add: 'add',
        edit: 'edit'
    };

    

    ngOnInit(): void {
        this.indLoading = true;
        this.getSessions();
        this.indLoading = false;
    };

    getSessions() {
        this.sessionsService.getSessionsData()
            .subscribe((sessionData: ISessions[]) =>
                this.sessionList = sessionData
            );
    };


    addSessionPopup(parm: string) {
        this.sessionAddpop.options = {
            color: "#007bff",
            header: "Add New Session",
            confirmBtnContent: "Add",
            showButtons: false
        }
        this.sessionAddpop.show(this.sessionAddpop.options);
    }


    onSubmit() {
        if (this.sessions.sessionName) {
            this.sessionsService.sessionSave(this.sessions)
                .subscribe((result: number) => {
                    if (result == 1) {
                        //this.router.navigateByUrl('/api/sessions');
                        this.sessionAddpop.hide();
                        window.location.reload();
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

    cancel() {
        this.sessionAddpop.hide();
    }

    cancelEdit() {
        this.sessionEditpop.hide();
    }


    delete(id: number) {
        this.sessions = this.sessionList.find(x => x.id == id) as ISessions;
        this.sessionDeletepop.options = {
            color: "#FF0000",
            header: ""
        }
        this.sessionDeletepop.show(this.sessionDeletepop.options);
    }

    deleteSession() {
        if (this.sessions.id) {
            this.sessionsService.sessionDelete(this.sessions.id)
                .subscribe((result: number) => {
                    if (result == 1) {
                        this.sessionDeletepop.hide();
                        window.location.reload();
                    }
                    else {
                        this.errorMessage = 'Unable to delete Session';
                    }
                },
                (err: any) => console.log(err));
            this.sessionDeletepop.hide();
        }
        else {
            console.log("Invalid Form Submitted!");
        }
    }

    editSession(id: number) {
        this.sessions = this.sessionList.find(x => x.id == id) as ISessions;
        this.sessionEditpop.options = {
            header: "Update Sessions",
            color: "#5cb85c",
            widthProsentage: 40,
            animationDuration: 1,
            showButtons: true,
            confirmBtnContent: "Edit",
            cancleBtnContent: "Close",
            confirmBtnClass: "btn btn-default",
            cancleBtnClass: "btn btn-default",
            animation: "fadeInDown",
        }
        this.sessionEditpop.show(this.sessionEditpop.options);
    }

    sumbitEdit() {
        if (this.sessions.id) {
            this.sessionsService.editSession(this.sessions)
                .subscribe((result: number) => {
                    if (result == 1) {
                        this.sessionEditpop.hide();
                        window.location.reload();
                    }
                    else {
                        this.errorMessage = 'Unable to register the compatitions';
                    }
                },
                (err: any) => console.log(err));;
                this.sessionEditpop.hide();
        }
        else {
            console.log("Invalid Form Submitted!");
        }
    }
}