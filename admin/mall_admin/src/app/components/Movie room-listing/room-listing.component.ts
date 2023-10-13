import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ConfirmationService, MessageService } from "primeng/api";
import { RoomAPI } from 'src/app/models/roomapi.model';
import { RoomAPIService } from 'src/app/services/roomapi.service';

@Component({
    templateUrl: './room-listing.component.html',
})
export class RoomListingComponent implements OnInit {

    keyword: string;
    rooms: RoomAPI[];

    constructor(
        private router: Router,
        private messageService: MessageService,
        private confirmationService: ConfirmationService,
        private roomAPIService: RoomAPIService
    ) { }

    ngOnInit() {
        this.roomAPIService.GetList().then(
            res => {
                this.rooms = res as RoomAPI[];
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
                this.roomAPIService.Delete(id).then(
                    res => {
                        var result: any = res as any;
                        if (result.status) {
                            this.messageService.add({
                                severity: 'success',
                                detail: 'Done'
                            });
                            this.roomAPIService.GetList().then(
                                res => {
                                    this.rooms = res as RoomAPI[];
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
        this.router.navigate(['/admin/add-room'])
    }
}