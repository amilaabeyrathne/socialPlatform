import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { HomeService } from "./home.service";



@Component({
    selector: 'home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.css'],
    providers: [HomeService]
})
export class HomeComponent {

    constructor(private homeService: HomeService, private router: Router) {
    }

    ngOnInit(): void {
        debugger;
        this.homeService
            .login()
            .then(result => {
                if (result.State == 1) {
                    this.router.navigate(["./home"]);
                }
                else {
                    alert(result.Msg);
                }
            });
    }
}
//import { Component } from '@angular/core';
//import { HomeService } from "./home.service";
//import { Router } from '@angular/router';

//@Component({
//    selector: 'home',
//    templateUrl: './home.component.html',
//    styleUrls: ['./home.component.css'],
//    providers: [HomeService],
//})
//export class HomeComponent {

//    constructor(private homeService: HomeService, private router: Router) {
//    }

//    //ngOnInit(): void {
//    //    debugger;
//    //    this.homeService
//    //        .login()
//    //        .then(result => {
//    //            if (result.State == 1) {
//    //                this.router.navigate(["./home"]);
//    //            }
//    //            else {
//    //                alert(result.Msg);
//    //            }
//    //        });
//    //}
//}