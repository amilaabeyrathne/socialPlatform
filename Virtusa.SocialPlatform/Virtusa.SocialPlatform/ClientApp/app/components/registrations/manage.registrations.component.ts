import { Component, OnInit, ViewChild } from '@angular/core';
import { Http } from '@angular/http';
import { RegistrationService } from './registrations.service';
import { Router, ActivatedRoute } from '@angular/router';
import { IRegistrations, ICompetitions, ICegs, ITiers, IParticipants } from './registrations.interface';
import { Popup } from 'ng2-opd-popup';
import { GroupByPipe } from '../../../utility/group-by.pipe';
import { } from '../common/';
import { RegistrationsConstants } from './registrations.constants';

@Component({
    selector: 'manage-register',
    templateUrl: './manage.registrations.component.html',
    styleUrls: ['../common/commom.component.css'],
    providers: [RegistrationService]
})
export class ManageRegistrationsComponent extends RegistrationsConstants implements OnInit {

    constructor(private registrationsService: RegistrationService,
        private popup: Popup,
        private router: Router) {
        super();
        this.registrationTitle = "Individual Registrations View";
        this.isIndividual = true;
        this.teamMemberCount = true;
        this.participants = [{ employeeId: '', employeeName: '', status: 'added' }];
    }
      
    @ViewChild('popupforIndividual') individualPopup: Popup;
    @ViewChild('popupforGroup') groupPopup: Popup;
    @ViewChild('popupforelete') deletePopup: Popup;
    @ViewChild('popupforTeamEdit') teameditPopup: Popup;

    individualClick(): void {
        this.isGroup = false;
        this.isIndividual = true;
        this.registrationTitle = "Individual Registrations View"
        this.getAllRegistration(false);
    }

    groupClick(): void {
        this.isIndividual = false;
        this.isGroup = true;
        this.registrationTitle = "Group Registrations View"
        this.getAllRegistration(true);
    }

    EditRegistration(id: number, isGroup: boolean) {
        this.registrations = this.registrationList.find(x => x.participantId == id) as IRegistrations;
        this.registrations.isGroup = isGroup;
        if (this.registrations.isGroup) {
            this.groupPopup.options = {
                header: "Edit Group Registration",
                color: "#5cb85c",
                showButtons: false

            }
            this.groupPopup.show(this.groupPopup.options);
        } else {
            this.individualPopup.options = {
                header: "Edit Individual Registration",
                color: "#5cb85c",
                showButtons: false

            }
            this.individualPopup.show(this.individualPopup.options);
        }
    }
    individualEditcancel() {
        this.individualPopup.hide();
    }

    groupEditcancel() {
        this.groupPopup.hide();
    }

    teamEditcancel() {
        this.teameditPopup.hide();
    }

    EditTeamMember(id: number) {
        this.registrationsService.getTeamMemberById(id).subscribe((participant: any[]) => this.participants = participant);
        this.teameditPopup.options = {
            header: "Edit Team Member - Registration",
            color: "#5cb85c",
            showButtons: false

        }
        this.teameditPopup.show(this.teameditPopup.options);

    }

    DeleteRegistration(id: number) {
        this.registrations = this.registrationList.find(x => x.participantId == id) as IRegistrations;
        this.deletePopup.options = {
            header: "Delete Registration",
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

        this.deletePopup.show(this.deletePopup.options);
    }

    sumbitEdit() {
        if (this.registrations.participantId) {
            this.registrationsService.editRegistrations(this.registrations)
                .subscribe((result: number) => {
                    if (result == 1) {
                        this.router.navigateByUrl('/manage-registrations');
                        this.popup.hide();
                    }
                    else {
                        this.errorMessage = 'Unable to register the compatitions';
                    }
                },
                (err: any) => console.log(err));;
        }
        else {
            console.log("Invalid Form Submitted!");
        }
    }

    sumbitGroupEdit() {
        if (this.registrations.teamId) {
            this.registrationsService.editRegistrations(this.registrations)
                .subscribe((result: number) => {
                    if (result == 1) {
                        this.router.navigateByUrl('/manage-registrations');
                        this.popup.hide();
                    }
                    else {
                        this.errorMessage = 'Unable to register the compatitions';
                    }
                },
                (err: any) => console.log(err));;
        }
        else {
            console.log("Invalid Form Submitted!");
        }
    }

    sumbitEditTeam() {
        if (this.participants != null) {
            this.registrationsService.editTeamMember(this.participants)
                .subscribe((result: number) => {
                    if (result == 1) {
                        this.router.navigateByUrl('/manage-registrations');
                        this.popup.hide();
                    }
                    else {
                        this.errorMessage = 'Unable to edit the Team Member';
                    }
                },
                (err: any) => console.log(err));;
        }
        else {
            console.log("Invalid Form Submitted!");
        }
    }
    
    sumbitDelete() {
        if (this.registrations.participantId) {
            this.registrationsService.deleteRegistrations(this.registrations.participantId)
                .subscribe((result: number) => {
                    if (result == 1) {
                        this.router.navigateByUrl('/manage-registrations');
                        this.popup.hide();
                    }
                    else {
                        this.errorMessage = 'Unable to register the compatitions';
                    }
                },
                (err: any) => console.log(err));;
        }
        else {
            console.log("Invalid Form Submitted!");
        }
    }

    removeMember(index: any) {

        this.participants.splice(index, 1);
        // if no rows left in the array create a blank array
        if (this.participants.length === 0 || this.participants.length == null) {
            this.teamMemberCount = false;
        }
    };

    addNewMember() {
        if (this.participants.length < 5) {
            this.participants.push({ 'employeeId': '', employeeName: '', status: 'added' });
            this.teamMemberCount = true;
        }
        else 
        {
            //Warning popup should be here
        }
        
    };

    ngOnInit(): void {
        this.loadingData = true;
        this.getAllRegistration(false);
        this.getCegs();
        this.getTiers();
    }

    getCegs() {
        this.registrationsService.getCegsData().subscribe((cegs: ICegs[]) => this.cegs = cegs);
    };

    getTiers() {
        this.registrationsService.getTiersData().subscribe((tier: ITiers[]) => this.tiers = tier);
    };

    getAllRegistration(isGroup: boolean) {
        this.registrationsService.getAllRegistration(isGroup)
            .subscribe((registrationsData: IRegistrations[]) =>
                this.registrationList = registrationsData
            );
    };

}