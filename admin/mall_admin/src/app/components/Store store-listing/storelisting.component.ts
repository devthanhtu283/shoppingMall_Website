import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ConfirmationService, MessageService } from "primeng/api";
import { StoreAPI } from 'src/app/models/storeapi.model';
import { StoreAPIService } from 'src/app/services/storeapi.service';


@Component({
    templateUrl: './storelisting.component.html',
})
export class StoreListingComponent implements OnInit {

    keyword: string;
    stores: StoreAPI[];
    first = 0;
    rows = 10;

    constructor(
        private router: Router,
        private messageService: MessageService,
        private confirmationService: ConfirmationService,
        private storeAPIService: StoreAPIService
    ) { }

    ngOnInit() {
        this.storeAPIService.findAll().then(
            res => {
                this.stores = res as StoreAPI[];
            },
            err => {
                console.log(err);
            }
        );
    }

    searchByKeyword() {
            this.storeAPIService.findByKeyword(this.keyword).then(
                res => {
                    this.stores = res as StoreAPI[];
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
                this.storeAPIService.delete(id).then(
                    res => {
                        var result: any = res as any;
                        if (result.status) {
                            this.messageService.add({
                                severity: 'success',
                                detail: 'Done'
                            });
                            this.storeAPIService.findAll().then(
                                res => {
                                    this.stores = res as StoreAPI[];
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

    next() {
        this.first = this.first + this.rows;
    }

    prev() {
        this.first = this.first - this.rows;
    }

    reset() {
        this.first = 0;
    }

    isLastPage(): boolean {
        return this.stores ? this.first === this.stores.length - this.rows : true;
    }

    isFirstPage(): boolean {
        return this.stores ? this.first === 0 : true;
    }

    clear(){
        this.keyword = '';
        this.storeAPIService.findAll().then(
            res => {
                this.stores = res as StoreAPI[];
            },
            err => {
                console.log(err);
            }
        );
    }

    addNew(){
        this.router.navigate(['/admin/add-store'])
    }
}