import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { Router, ActivatedRoute } from '@angular/router';
import { AttendanceService } from './attendance.service';
import { IAttendance, ICompetitions, ISessions } from './attendance.interface';
import { NgForm } from "@angular/forms";



@Component({
    selector: 'attendance-competition',
    templateUrl: './attendance.competition.component.html',
    styleUrls: ['./attendance.component.css'],
    providers: [AttendanceService]
})

export class AttendanceCompetitionComponent implements OnInit {
    isCompetition: boolean = true;
    isSubmited: boolean = false;

    lblAttendanceTitle: string = "Competition Attendances";

    lblCompetition: string = "Competition Name";
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

    competitions: ICompetitions[] = [];

    constructor(private attendanceService: AttendanceService,
        private router: Router) {
        this.isCompetition = true;
    }

    onSubmit() {
        if (this.attendance.employeeId) {
            this.isCompetition = true;
            this.attendanceService.attendanceSave(this.attendance)
                .subscribe((result: number) => {
                    if (result == 1) {
                        //this.router.navigateByUrl('/api/attendance');
                        //window.history.back();
                        //this.location.back(); 
                        //this.router.navigate(["session"]);

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
        this.getCompetitions();
    };

    getCompetitions() {
        this.attendanceService.getCompetitionsData().subscribe((competition: ICompetitions[]) => this.competitions = competition);
    };

}