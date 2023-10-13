import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { ConfirmationService, MessageService } from 'primeng/api';
import { FeedbackAPI } from 'src/app/models/feedbackapi.model';
import { FeedbackAPIService } from 'src/app/services/feedbackapi.service';

@Component({

    templateUrl: './feebacklisting.component.html',
})
export class FeedBackListingComponent implements OnInit {
    feedbacks: FeedbackAPI[];
    keyword: string;
    formGroup: FormGroup;
    constructor(
        private router: Router,
        private messageService: MessageService,
        private confirmationService: ConfirmationService,
        private feedbackAPIService: FeedbackAPIService
    ) { }
    ngOnInit() {
        this.feedbackAPIService.findAll().then(
            res => {
                this.feedbacks = res as FeedbackAPI[];
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
                this.feedbackAPIService.delete(id).then(
                    res => {
                        var result: any = res as any;
                        if (result.status) {
                            this.messageService.add({
                                severity: 'success',
                                detail: 'Done'
                            });
                            this.feedbackAPIService.findAll().then(
                                res => {
                                    this.feedbacks = res as FeedbackAPI[];
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
    
    clear() {
        this.keyword = '';
        this.feedbackAPIService.findAll().then(
            res => {
                this.feedbacks = res as FeedbackAPI[];
            },
            err => {
                console.log(err);
            }
        );

    }
}