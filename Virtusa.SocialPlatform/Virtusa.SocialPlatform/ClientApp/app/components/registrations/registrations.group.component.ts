import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { Router, ActivatedRoute } from '@angular/router';
import { RegistrationService } from './registrations.service';
import { IRegistrations, ICompetitions, ICegs, ITiers, ITeams } from './registrations.interface';
import { NgForm } from "@angular/forms";
import { RegistrationsConstants } from './registrations.constants';

declare var RegistrationJs: any;

@Component({
    selector: 'register-group',
    templateUrl: './registrations.group.component.html',
    styleUrls: ['./registrations.component.css'],
    providers: [RegistrationService]
})

export class RegistrationsGroupComponent extends RegistrationsConstants implements OnInit {
    isGroup: boolean = true;
    lblregistrationTitle: string = "Group Registration";
        
    constructor(private registrationsService: RegistrationService,
        private router: Router) {
        super();
        this.isGroup = true;
        this.teamMemberCount = true;
        this.registrations.teamMembers = [{ id:'', name: '' }]
    }

    onGpSubmit() {
        if (this.registrations.teamName) {
            this.registrations.isGroup = true;
            this.registrationsService.registrationGroupSave(this.registrations)
                .subscribe((result: number) => {
                    if (result == 1) {
                        this.router.navigateByUrl('/api/registrations');
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
    };

    removeMember(index: any) {
        this.registrations.teamMembers.splice(index, 1);
        // if no rows left in the array create a blank array
        if (this.registrations.teamMembers.length === 0 || this.registrations.teamMembers.length == null) {
            this.teamMemberCount = false;
        }
    };

    addNewMember() {
        if (this.registrations.teamMembers.length < 5) {
            this.registrations.teamMembers.push({ 'id': '', name: '' });
            this.teamMemberCount = true;
        }
        else {
            //Warning popup should be here
        }
    };

    ngOnInit(): void {
        this.getCompetitions();
        this.getTiers();
        this.getCegs();

    };

    getCompetitions() {
        this.registrationsService.getCompetitionsData(true).subscribe((competition: ICompetitions[]) => this.competitions = competition);
    };

    getCegs() {
        this.registrationsService.getCegsData().subscribe((cegs: ICegs[]) => this.cegs = cegs);
    };

    getTiers() {
        this.registrationsService.getTiersData().subscribe((tier: ITiers[]) => this.tiers = tier);
    };
}