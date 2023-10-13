import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ConfirmationService, MessageService } from "primeng/api";
import { TimeSlotAPI } from 'src/app/models/timeslotapi.model';
import { TimeSlotAPIService } from 'src/app/services/timeslotapi.service';

@Component({
    templateUrl: './timeSlot-listing.component.html',
})
export class TimeSlotListingComponent implements OnInit {

    keyword: string;
    timeSlots: TimeSlotAPI[];

    constructor(
        private router: Router,
        private messageService: MessageService,
        private confirmationService: ConfirmationService,
        private timeSlotAPIService: TimeSlotAPIService
    ) { }

    ngOnInit() {
        this.timeSlotAPIService.GetList().then(
            res => {
                this.timeSlots = res as TimeSlotAPI[];
            },
            err => {
                console.log(err);
            }
        );
    }

    delete(id: number) {
        this.confirmationService.confirm({
            message: 'Are you sure that you want to proceed?',
            header: 'Confirmation',
            icon: 'pi pi-exclamation-triangle',
            accept: () => {
                this.timeSlotAPIService.Delete(id).then(
                    res => {
                        var result: any = res as any;
                        if (result.status) {
                            this.messageService.add({
                                severity: 'success',
                                detail: 'Done'
                            });
                            this.timeSlotAPIService.GetList().then(
                                res => {
                                    this.timeSlots = res as TimeSlotAPI[];
                                },
                                err => {
                                    console.log(err);
                                }
                            );
                        } else {
                            this.messageService.add({
                                severity: 'error',
                                detail: 'Failed'
                            });
                        }
                    },
                    err => {
                        this.messageService.add({
                            severity: 'error',
                            detail: err
                        });
                    }
                );
            },
            reject: (type) => {

            }
        });
    }


    addNew(){
        this.router.navigate(['/admin/add-timeSlot'])
    }
}