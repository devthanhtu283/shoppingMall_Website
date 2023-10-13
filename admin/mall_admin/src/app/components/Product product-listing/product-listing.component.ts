import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ConfirmationService, MessageService } from "primeng/api";
import { ProductAPI } from 'src/app/models/productapi.model';
import { ProductAPIService } from 'src/app/services/productapi.service';

@Component({
    templateUrl: './product-listing.component.html',
})
export class ProductListingComponent implements OnInit {

    keyword: string;
    products: ProductAPI[];

    constructor(
        private router: Router,
        private messageService: MessageService,
        private confirmationService: ConfirmationService,
        private productAPIService: ProductAPIService
    ) { }

    ngOnInit() {
        this.productAPIService.findAll().then(
            res => {
                this.products = res as ProductAPI[];
            },
            err => {
                console.log(err);
            }
        );
    }

    searchByKeyword() {
        this.productAPIService.findByKeyword(this.keyword).then(
            res => {
                this.products = res as ProductAPI[];
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
                this.productAPIService.delete(id).then(
                    res => {
                        var result: any = res as any;
                        if (result.status) {
                            this.messageService.add({
                                severity: 'success',
                                detail: 'Done'
                            });
                            this.productAPIService.findAll().then(
                                res => {
                                    this.products = res as ProductAPI[];
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
        this.productAPIService.findAll().then(
            res => {
                this.products = res as ProductAPI[];
            },
            err => {
                console.log(err);
            }
        );
    }

    addNew(){
        this.router.navigate(['/admin/add-product'])
    }
}