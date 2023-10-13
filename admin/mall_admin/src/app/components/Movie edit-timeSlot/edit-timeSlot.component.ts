import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { MessageService } from 'primeng/api';
import { TimeSlotAPI } from 'src/app/models/timeslotapi.model';
import { TimeSlotAPIService } from 'src/app/services/timeslotapi.service';

@Component({
    templateUrl: './edit-timeSlot.component.html',
})
export class EditTimeSlotComponent implements OnInit{

    editTimeSlotForm: FormGroup;
    file: File;
    timeSlot: TimeSlotAPI;

    constructor(
        private formBuilder : FormBuilder,
        private router : Router,
        private messageService : MessageService,
        private activatedRoute : ActivatedRoute,
        private timeSlotAPIService : TimeSlotAPIService
    ){}

    ngOnInit(){

    this.activatedRoute.paramMap.subscribe(p => {
        var id = p.get('id');
        this.timeSlotAPIService.GetItem(id).then(
        res => {
            this.timeSlot = res as TimeSlotAPI;
            this.editTimeSlotForm = this.formBuilder.group({
                name: this.timeSlot.name,
                startTime: this.timeSlot.startTime,
                endTime: this.timeSlot.endTime,
                status: this.timeSlot.status,
            });
        },
        err => {
            console.log(err);
        }
    );
    });
}

    save(){
        var timeSlot : TimeSlotAPI = this.editTimeSlotForm.value as TimeSlotAPI;
        timeSlot.id = this.timeSlot.id;
        this.timeSlotAPIService.Update(timeSlot).then(
        res => {
            var result : any = res as any;
            if(result.status){
                this.router.navigate(['/admin/timeSlot-listing'])
            } else {
                this.messageService.add({ 
                    severity: 'error',
                    summary: 'failed',
                    detail: 'Edit Failed' 
                });
            }
        },
        err => {
            this.messageService.add({ 
                severity: 'error',
                summary: 'failed',
                detail: 'Edit Failed' 
            });
        }
        );  
    }
}