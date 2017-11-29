import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { CKEditorModule } from 'ng2-ckeditor';
import { DateTimePickerModule } from 'ng-pick-datetime';
//import { ModalComponent } from 'ng2-bs3-modal/ng2-bs3-modal';
//import { ModalService } from 'ng2-modal-dialog/modal.module';
import { PopupModule } from 'ng2-opd-popup';


import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { NewsComponent } from './components/news/news.component';
import { CompetitionComponent } from './components/competition/competition.component';
import { AddNewsComponent } from './components/news/add-news.component';
import { AdminComponent } from './components/admin/admin.component';
import { RegistrationsComponent } from './components/registrations/registrations.component';
import { RegistrationsIndividualComponent } from './components/registrations/registrations.individual.component';
import { RegistrationsGroupComponent } from './components/registrations/registrations.group.component';
import { AddCompetitionComponent } from './components/competition/add-competition.component';
import { ManageRegistrationsComponent } from './components/registrations/manage.registrations.component';
import { RegistrationsConstants } from './components/registrations/registrations.constants';
import { SessionsComponent } from './components/sessions/sessions.component';
import { AddSessionsComponent } from './components/sessions/add-sessions.component';
import { AddOrderComponent } from './components/orders/add-orders.component';
import { ManageNewsComponent } from './components/news/manage.news.component';
import { NewsDetailComponent } from './components/news/news-detail.component';
import { AttendanceComponent } from './components/attendance/attendance.component';
import { AttendanceSessionComponent } from './components/attendance/attendance.session.component';
import { AttendanceCompetitionComponent } from './components/attendance/attendance.competition.component';
import { ExcelExportComponent } from "./components/excelexport/excel-export.component";

import { SanitizeHtmlPipe } from '../utility/sanitizing';
import { GroupByPipe } from '../utility/group-by.pipe';
import { CommonConstants } from '../utility/common.constants';




@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent,
        NewsComponent,
        AddNewsComponent,
        AdminComponent,
        RegistrationsComponent,
        RegistrationsIndividualComponent,
        RegistrationsGroupComponent,
        CompetitionComponent,
        SessionsComponent,
        AddSessionsComponent,
        CompetitionComponent,
        ManageRegistrationsComponent,
        AddOrderComponent,
        ManageNewsComponent,
        NewsDetailComponent,
        AttendanceComponent,
        AttendanceSessionComponent,
        AttendanceCompetitionComponent,
        SanitizeHtmlPipe,
        ExcelExportComponent,
        GroupByPipe,
        CommonConstants,
        RegistrationsConstants

    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        CKEditorModule,
        DateTimePickerModule,
        PopupModule.forRoot(),
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: 'news', component: NewsComponent },
            { path: 'add-news', component: AddNewsComponent },
            { path: 'admin', component: AdminComponent },
            { path: 'registrations', component: RegistrationsComponent },
            { path: 'competition', component: CompetitionComponent },
            { path: 'session', component: SessionsComponent },
            { path: 'manage-registrations', component: ManageRegistrationsComponent },
            { path: 'add-orders', component: AddOrderComponent },
            { path: 'manage-news', component: ManageNewsComponent },
            { path: 'news-detail/:id', component: NewsDetailComponent },
            { path: 'attendance', component: AttendanceComponent },
            { path: 'excel-export', component: ExcelExportComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ]
})
export class AppModuleShared {
}
