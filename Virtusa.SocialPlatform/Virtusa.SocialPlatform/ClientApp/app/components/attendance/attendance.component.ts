import { Component } from '@angular/core';
import { Http } from '@angular/http';
import { AttendanceService } from './attendance.service';
import { IAttendance, ICompetitions, ISessions } from './attendance.interface';

@Component({
    selector: 'attendance',
    templateUrl: './attendance.component.html',
    styleUrls: ['./attendance.component.css'],
    providers: [AttendanceService]
})

export class AttendanceComponent {
    attendanceType: boolean = true;
    isCompetition: boolean = false;
    isSession: boolean = false;
    registrationTitle: string;

    constructor(private attendanceService: AttendanceService) {
        this.attendanceType = true;
    }


    sessionClick(): void {
        this.isCompetition = false;
        this.isSession = true;
        this.attendanceType = false;
    }

    competitionClick(): void {
        this.isSession = false;
        this.isCompetition = true;
        this.attendanceType = false;
    }

}