import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { MessageService } from 'primeng/api';
import { MovieAPI } from 'src/app/models/movieapi.model';
import { MovieAPIService } from 'src/app/services/movieapi.service';

@Component({
    templateUrl: './editmovie.component.html',
})
export class EditMovieComponent implements OnInit{

    editMovieForm: FormGroup;
    file: File;
    movie: MovieAPI;

    constructor(
        private formBuilder : FormBuilder,
        private router : Router,
        private messageService : MessageService,
        private activatedRoute : ActivatedRoute,
        private movieAPIService : MovieAPIService
    ){}

    ngOnInit(){

    this.activatedRoute.paramMap.subscribe(p => {
        var id = p.get('id');
        this.movieAPIService.findById(id).then(
        res => {
            this.movie = res as MovieAPI;
            this.editMovieForm = this.formBuilder.group({
                name: this.movie.name,
                description: this.movie.description,
                timeLast: this.movie.timeLast,
                dateExpect: this.movie.dateExpect,
                genre: this.movie.genre,
                language: this.movie.language,
                status: this.movie.status,
            });
        },
        err => {
            console.log(err);
        }
    );
    });
}

    selectFile(evt: any){
    this.file = evt.target.files[0];
    }

    save(){
        var movie : MovieAPI = this.editMovieForm.value as MovieAPI;
        movie.id = this.movie.id;
        var formData = new FormData();
        formData.append('file', this.file);
        formData.append('strMovie', JSON.stringify(movie));
        this.movieAPIService.update(formData).then(
        res => {
            var result : any = res as any;
            if(result.status){
                this.router.navigate(['/admin/movie-listing'])
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