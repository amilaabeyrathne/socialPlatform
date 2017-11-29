import { Component } from '@angular/core';
import { Http } from '@angular/http';
import { RegistrationService } from './registrations.service';
import { IRegistrations, ICompetitions, ICegs, ITiers } from './registrations.interface';

@Component({
    selector: 'register',
    templateUrl: './registrations.component.html',
    styleUrls: ['./registrations.component.css'],
    providers: [RegistrationService]
})

export class RegistrationsComponent {
    registrationType: boolean = true;
    isIndividual: boolean = false;
    isGroup: boolean = false;
    registrationTitle: string;
    cegs: ICegs[] = [];
    constructor(private registrationsService: RegistrationService) {
        this.registrationType = true;
    }


    individualClick(): void {
        this.isGroup = false;
        this.isIndividual = true;
        this.registrationType = false;
    }

    groupClick(): void {
        this.isIndividual = false;
        this.isGroup = true;
        this.registrationType = false;
    }

}