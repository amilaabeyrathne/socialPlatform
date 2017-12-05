import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { Http } from '@angular/http';
import { CompetitionService } from './competition.service';
import { Competition } from './competition';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Popup } from 'ng2-opd-popup';


@Component({
    selector: 'competition',
    templateUrl: './competition.component.html',
    styleUrls: ['../common/commom.component.css'],
    providers: [CompetitionService],

})
export class CompetitionComponent implements OnInit {

    competitionList: Competition[];
    dbOperation: string;
    modalTitle: string;
    modalBtnTitle: string;
    competitionForm: FormGroup;
    indLoading: boolean = false;
    type = ['Individual', 'Group'];
    private competition: Competition;
    private result: number;
    @ViewChild('popup1') popup1: Popup;
    @ViewChild('popup2') popup2: Popup;
    competitionToDelet: Competition;
    private errorMessage: string;
    isEdite: boolean = false;
    competitionEdit: Competition;
    isUpdate: boolean = false;

    


    modalParams = {
        add: 'add',
        edit: 'edit'
    };

    constructor(private competitionService: CompetitionService/*private popup: Popup*/) {
        this.competition = new Competition();
    }

    ngOnInit(): void {

        this.indLoading = true;
        this.competitionService
            .getCompetition()
            .then(competitionData => {
                this.competitionList = competitionData;
                this.indLoading = false;
            });
    }


    addCompetitionPopup(parm: string) {
        this.competition = new Competition();
        this.isUpdate = false;
        this.popup1.options = {
            color: "#5cb85c",
            header: "Add New Competition",
            confirmBtnContent: "Add",
            showButtons: false
        }
        this.popup1.show(this.popup1.options);
    }

    onSubmit() {
        debugger;
        if (this.competition.id != null) {
            this.editSave();
        }
        else
        {

            this.competitionService.create(this.competition)
                .then(s => this.result = s);
            this.competition = new Competition();
            this.popup1.hide();
            location.reload();
        }

    }

    cancel() {
        this.popup1.hide();
    }

    delete(comp: Competition) {
        this.popup2.options = {
            color: "#FF0000",
            header: ""
        }
        this.competitionToDelet = comp;
        this.popup2.show(this.popup2.options);
    }

    deleteCompetition() {
        this.competitionService.delete(this.competitionToDelet.id).subscribe((result: number) => {
            if (result == 1) {
                this.popup2.hide();
                location.reload();

            }
            else {
                this.errorMessage = 'Unable to delete the compatitions';
            }
        },
            (err: any) => console.log(err));
        this.popup2.hide();
    }

    editCompetition(comp: Competition) {
        this.competition = comp;
        this.isUpdate = true;

        this.popup1.options = {
            color: "#5cb85c",
            header: "Update Competition",
            confirmBtnContent: "Update",
            showButtons: false
        }

        this.popup1.show(this.popup1.options);

    }

    editSave()
    {
        this.competitionService.edit(this.competition).subscribe((result: number) => {
            if (result == 1) {
                this.popup1.hide();
                location.reload();
            }
            else {
                this.errorMessage = 'Unable to update the compatitions';
            }
        },
            (err: any) => console.log(err));
        this.popup1.hide();
    }
}


