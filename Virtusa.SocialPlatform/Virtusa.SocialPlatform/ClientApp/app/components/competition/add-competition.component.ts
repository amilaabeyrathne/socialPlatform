import { Component } from '@angular/core';
import { Modal } from 'ng2-modal-dialog/modal.module';

@Component({
    selector: 'app-competition-modal',
    templateUrl: './add-competition.component.html',
    //styleUrls: ['./add-competition.component.css']
})
// the Modal import allows the usage of the @Modal alias that adds the Modal functions.
@Modal()
export class AddCompetitionComponent {


    closeModal: Function;

    // will hold modal paramaters passed from parent component
    constructor() {
        debugger;
    }

    test()
    {
        debugger;
    }

     //onCancel(): void {
    //    this.closeModal();
    //}

    //onSubmit(): void {
    //   // event.preventDefault();

   // }
}
