import { Component, Inject, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { OrdersService } from './orders.service';
import { IOrders } from './orders';
import { Router, ActivatedRoute } from '@angular/router';
import { NgForm } from "@angular/forms";

@Component({
    selector: 'add-orders',
    templateUrl: './add-orders.component.html',
    styleUrls: ['./orders.component.css'],
    providers: [OrdersService]
})

export class AddOrderComponent {
    isAddOrder: boolean = true;
    lblOrderTitle: string = "Add Order";
    lblEmployeeId: string = "Employee ID";
    lblSize: string = "Size";
    lblQuantity: string = "Quantity";
    lblPrice: string = "Price";
    //lblValue: number = 2000

    
    errorMessage: string = "";

    orders: IOrders = {
        employeeId:'',
        orderDate: new Date().toLocaleString(),
        orderId:0,
        quantity:'',
        size: '',
        totalPrice:2000
    };
   

    constructor(private ordersService: OrdersService,
        private router: Router) {
        this.isAddOrder = true;


              
    };

    Sizes = ['Small', 'Medium', 'Large'];

   

    onSubmit() {
        if (this.orders.employeeId) {
            this.ordersService.add(this.orders)
                .subscribe((result: number) => {
                    if (result == 1) {
                        this.router.navigateByUrl('/api/OrderDetails');
                    }
                    else {
                        this.errorMessage = 'Unable to add order';
                    }
                        
                },
                (err: any) => console.log(err));;

        }
        else {
            console.log("Invalid Form Submitted!");
        }
    
    }
}