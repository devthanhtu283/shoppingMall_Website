import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ConfirmationService, MessageService } from 'primeng/api';
import { GalleryAPI } from 'src/app/models/galleryapi.model';
import { GalleryAPIService } from 'src/app/services/galleryapi.service';

@Component({

    templateUrl: './gallerylisting.component.html',
})
export class GalleryListingComponent implements OnInit {

    galleries: GalleryAPI[];

    constructor(
        private router: Router,
        private messageService: MessageService,
        private confirmationService: ConfirmationService,
        private galleryAPIService: GalleryAPIService
    ) { }

    ngOnInit() {
        this.galleryAPIService.findAll().then(
            res => {
                this.galleries = res as GalleryAPI[];
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
                this.galleryAPIService.delete(id).then(
                    res => {
                        var result: any = res as any;
                        if (result.status) {
                            this.messageService.add({
                                severity: 'success',
                                detail: 'Done'
                            });
                            this.galleryAPIService.findAll().then(
                                res => {
                                    this.galleries = res as GalleryAPI[];
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
        this.router.navigate(['/admin/add-gallery'])
    }

}