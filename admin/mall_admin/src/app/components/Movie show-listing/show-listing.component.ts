import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ConfirmationService, MessageService } from "primeng/api";
import { ShowAPI } from 'src/app/models/showapi.model';
import { ShowAPIService } from 'src/app/services/showapi.service';

@Component({
    templateUrl: './show-listing.component.html',
})
export class ShowListingComponent implements OnInit {

    keyword: string;
    shows: ShowAPI[];

    constructor(
        private router: Router,
        private messageService: MessageService,
        private confirmationService: ConfirmationService,
        private showAPIService: ShowAPIService
    ) { }

    ngOnInit() {
        this.showAPIService.GetList().then(
            res => {
                this.shows = res as ShowAPI[];
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
                this.showAPIService.Delete(id).then(
                    res => {
                        var result: any = res as any;
                        if (result.status) {
                            this.messageService.add({
                                severity: 'success',
                                detail: 'Done'
                            });
                            this.showAPIService.GetList().then(
                                res => {
                                    this.shows = res as ShowAPI[];
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
        this.router.navigate(['/admin/add-show'])
    }
}