import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { MessageService } from 'primeng/api';
import { MovieAPI } from 'src/app/models/movieapi.model';
import { MovieAPIService } from 'src/app/services/movieapi.service';

@Component({
  templateUrl: './add-movie.component.html',
})
export class AddMovieComponent implements OnInit {

  addMovieForm: FormGroup;
  file: File;
  movies: MovieAPI[];

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private messageService: MessageService,
    private movieAPIService: MovieAPIService,
  ) { }

  ngOnInit() {
    this.addMovieForm = this.formBuilder.group({
      name: '',
      description: '',
      timeLast: '00:00:00',
      dateExpect: '',
      genre: '',
      language: '',
      status: ''
    });

  }

  selectFile(evt: any) {
    this.file = evt.target.files[0];
  }

  save() {
    var movie: MovieAPI = this.addMovieForm.value as MovieAPI;
    var formData = new FormData();
    formData.append('file', this.file);
    formData.append('strMovie', JSON.stringify(movie));
    this.movieAPIService.create(formData).then(
      res => {
        var result: any = res as any;
        if (result.status) {
          this.router.navigate(['/admin/movie-listing'])
        } else {
          this.messageService.add({
            severity: 'error',
            summary: 'failed',
            detail: 'Add Failed'
          });
        }
      },
      err => {
        console.log(err);
      }
    );
  }
}