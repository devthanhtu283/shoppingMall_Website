import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ConfirmationService, MessageService } from "primeng/api";
import { TicketAPI } from 'src/app/models/ticketapi.model';
import { TicketAPIService } from 'src/app/services/ticketapi.service';


@Component({
    templateUrl: './ticket-listing.component.html',
})
export class TicketListingComponent implements OnInit {

    keyword: string;
    tickets: TicketAPI[];

    constructor(
        private router: Router,
        private messageService: MessageService,
        private confirmationService: ConfirmationService,
        private ticketAPIService: TicketAPIService
    ) { }

    ngOnInit() {
        this.ticketAPIService.GetList().then(
            res => {
                this.tickets = res as TicketAPI[];
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
                this.ticketAPIService.Delete(id).then(
                    res => {
                        var result: any = res as any;
                        if (result.status) {
                            this.messageService.add({
                                severity: 'success',
                                detail: 'Done'
                            });
                            this.ticketAPIService.GetList().then(
                                res => {
                                    this.tickets = res as TicketAPI[];
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

    clear(){
        this.keyword = '';
        this.ticketAPIService.GetList().then(
            res => {
                this.tickets = res as TicketAPI[];
            },
            err => {
                console.log(err);
            }
        );
    }

    GetListSearch(){
        this.GetListByCustomerPhone();
        this.GetListByCustomerName();
    }

    GetListByCustomerPhone(){
        this.ticketAPIService.GetListByCustomerPhone(this.keyword).then(
            res => {
                this.tickets = res as TicketAPI[];
            },
            err => {
                console.log(err);
            }
        );
    }

    GetListByCustomerName(){
        this.ticketAPIService.GetListByCustomerName(this.keyword).then(
            res => {
                this.tickets = res as TicketAPI[];
            },
            err => {
                console.log(err);
            }
        );
    }

    addNew(){
        this.router.navigate(['/admin/add-ticket'])
    }

}