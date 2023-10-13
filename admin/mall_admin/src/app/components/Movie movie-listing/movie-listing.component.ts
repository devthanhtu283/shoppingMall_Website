import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ConfirmationService, MessageService } from "primeng/api";
import { MovieAPI } from 'src/app/models/movieapi.model';
import { MovieAPIService } from 'src/app/services/movieapi.service';

@Component({
    templateUrl: './movie-listing.component.html',
})
export class MovieListingComponent implements OnInit {

    keyword: string;
    movies: MovieAPI[];

    constructor(
        private router: Router,
        private messageService: MessageService,
        private confirmationService: ConfirmationService,
        private movieAPIService: MovieAPIService
    ) { }

    ngOnInit() {
        this.movieAPIService.findAll().then(
            res => {
                this.movies = res as MovieAPI[];
                for(var i = 0 ; i < this.movies.length ; i++){
                    var des = this.movies[i].description.slice(0, 100) + '...';
                    this.movies[i].description = des;
                }
            },
            err => {
                console.log(err);
            }
        );
    }

    searchByKeyword() {
        this.movieAPIService.findByKeyword(this.keyword).then(
            res => {
                this.movies = res as MovieAPI[];
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
                this.movieAPIService.delete(id).then(
                    res => {
                        var result: any = res as any;
                        if (result.status) {
                            this.messageService.add({
                                severity: 'success',
                                detail: 'Done'
                            });
                            this.movieAPIService.findAll().then(
                                res => {
                                    this.movies = res as MovieAPI[];
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
        this.movieAPIService.findAll().then(
            res => {
                this.movies = res as MovieAPI[];
            },
            err => {
                console.log(err);
            }
        );
    }

    addNew(){
        this.router.navigate(['/admin/add-movie'])
    }
}