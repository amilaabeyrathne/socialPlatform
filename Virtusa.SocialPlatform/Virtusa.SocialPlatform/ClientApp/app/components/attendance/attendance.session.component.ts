import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { Router, ActivatedRoute } from '@angular/router';
import { AttendanceService } from './attendance.service';
import { IAttendance, ICompetitions, ISessions } from './attendance.interface';
import { NgForm } from "@angular/forms";



@Component({
    selector: 'attendance-session',
    templateUrl: './attendance.session.component.html',
    styleUrls: ['./attendance.component.css'],
    providers: [AttendanceService]
})

export class AttendanceSessionComponent implements OnInit {
    isSession: boolean = true;
    isSubmited: boolean = false;

    lblAttendanceTitle: string = "Session Attendances";

    lblSession: string = "Session Name";
    lblEmployeeId: string = "Employee Id";

    errorMessage: string = "";
    lblMessage: string = "Attendance added sucesfully";

    attendance: IAttendance = {
        id: 0,
        employeeId: '',
        employeeName: '',
        sessionId: 0,
        competitionId: 0,
        dateCreated: new Date().toLocaleString(),
        createdBy: 'Admin',
        isDelete: false
    };

    sessions: ISessions[] = [];

    constructor(private attendanceService: AttendanceService,
        private router: Router) {
        this.isSession = true;
    }

    onSubmit() {
        if (this.attendance.employeeId) {
            this.isSession = true;
            this.attendanceService.attendanceSave(this.attendance)
                .subscribe((result: number) => {
                    if (result == 1) {
                        this.isSubmited = true;
                        setTimeout(() => { 
                            this.isSubmited = false;
                        }, 3000);
                    }
                    else {
                        this.errorMessage = 'Unable to add attendance';
                    }
                },
                (err: any) => console.log(err));;
        }
        else {
            console.log("Invalid Form Submitted!");
        }
    }

    ngOnInit(): void {
        this.getSessions();
    };

    getSessions() {
        this.attendanceService.getSessionsData().subscribe((session: ISessions[]) => this.sessions = session);
    };

}