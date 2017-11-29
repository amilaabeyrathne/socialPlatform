import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { Router, ActivatedRoute } from '@angular/router';
import { ExportService } from './export.service';
import { NgForm } from "@angular/forms";


@Component({
    selector: 'export-excel',
    templateUrl: './excel-export.component.html',
    styleUrls: ['./excel-export.component.css'],
    providers: [ExportService]
})



export class ExcelExportComponent {
    errorMessage: string = "";
    exportTitle: string;
    filePath: string;
    constructor(private exportService: ExportService,
        private router: Router) {
        this.exportTitle = "Export Data To Excel";
    };

    ExcelExportSubmit() {
       debugger;
        //if (this.sessions.sessionName) {
        this.exportService.exportData()
            .subscribe((result: string) => {
                this.filePath = result;
                },
                (err: any) => console.log(err));;
        /*}
        else {
            console.log("Invalid Form Submitted!");
        }*/
    }
}
