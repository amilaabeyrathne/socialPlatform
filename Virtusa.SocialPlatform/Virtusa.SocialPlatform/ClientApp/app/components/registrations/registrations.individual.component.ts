import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { Router, ActivatedRoute } from '@angular/router';
import { RegistrationService } from './registrations.service';
import { IRegistrations, ICompetitions, ICegs, ITiers, ITeams } from './registrations.interface';
import { NgForm } from "@angular/forms";
import { RegistrationsConstants } from './registrations.constants';


@Component({
    selector: 'register-individual',
    templateUrl: './registrations.individual.component.html',
    styleUrls: ['./registrations.component.css'],
    providers: [RegistrationService]
})

export class RegistrationsIndividualComponent extends RegistrationsConstants implements OnInit {
    isIndividual: boolean = true;
    lblregistrationTitle: string = "Individual Registration";
    constructor(private registrationsService: RegistrationService,
        private router: Router) {
        super();
        this.isIndividual = true;
    }

    onSubmit() {
        if (this.registrations.employeeId) {
            this.registrations.isGroup = false;
            this.registrationsService.registrationSave(this.registrations)
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
    }

    ngOnInit(): void {
        this.getCompetitions();
        this.getTiers();
        this.getCegs();

    };

    getCompetitions() {
        this.registrationsService.getCompetitionsData(false).subscribe((competition: ICompetitions[]) => this.competitions = competition);
    };

    getCegs() {
        this.registrationsService.getCegsData().subscribe((cegs: ICegs[]) => this.cegs = cegs);
    };
    getTiers() {
        this.registrationsService.getTiersData().subscribe((tier: ITiers[]) => this.tiers = tier);
    };

}