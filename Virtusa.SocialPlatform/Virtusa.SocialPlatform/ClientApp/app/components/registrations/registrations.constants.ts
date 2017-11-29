import { Component } from '@angular/core';
import { IRegistrations, ICompetitions, ICegs, ITiers, IParticipants, ITeams } from './registrations.interface';

@Component({
    template: ''
})
export class RegistrationsConstants {
    public lblcompetitions: string = "Competitions";
    public lblselectcompetitions: string = "Select the competition";
    public lblEmployee: string = "Employee Id";
    public lblEmployeeName: string = "Employee Name";
    public lbltiers: string = "Tiers";
    public lblcegs: string = "Cegs";
    public lblContactNumber: string = "Contact Number";
    public contactValidation: string = "Please enter a 10 digit number";
    public lblTeamName: string = "Team Name";
    public lblTeamMembers: string = "Team Members";
    public isIndividual: boolean = false;
    public isGroup: boolean = false;
    public registrationTitle: string;
    public loadingData: boolean = false;
    public teamMemberCount: boolean;
    public tiers: ITiers[];
    public cegs: ICegs[];
    public participants: any[];
    public errorMessage: string;
    public registrationList: IRegistrations[];
    public competitions: ICompetitions[] = [];
    public teamMembers: ITeams[];
    public registrations: IRegistrations = {
        participantId: 0,
        employeeId: '',
        employeeName: '',
        teamName: '',
        teamMembers: [],
        contact: '',
        cegId: 0,
        competitionsId: 0,
        isGroup: false,
        competitionName: '',
        teamPath: '',
        tierId: 0,
        teamId: 0
    };

    public phoneNumbr  = /^\+?\d{2}[- ]?\d{3}[- ]?\d{5}$/;
    

}   

