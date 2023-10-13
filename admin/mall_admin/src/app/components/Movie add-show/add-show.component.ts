import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { MessageService } from 'primeng/api';
import { ShowAPI } from 'src/app/models/showapi.model';
import { MovieAPI } from 'src/app/models/movieapi.model';
import { RoomAPI } from 'src/app/models/roomapi.model';
import { TimeSlotAPI } from 'src/app/models/timeslotapi.model';
import { TimeSlotAPIService } from 'src/app/services/timeslotapi.service';
import { MovieAPIService } from 'src/app/services/movieapi.service';
import { RoomAPIService } from 'src/app/services/roomapi.service';
import { ShowAPIService } from 'src/app/services/showapi.service';

@Component({
  templateUrl: './add-show.component.html',
})
export class AddShowComponent implements OnInit {

  addShowForm: FormGroup;
  file: File;
  shows: ShowAPI[];
  rooms:RoomAPI[];
  movies:MovieAPI[];
  timeslots:TimeSlotAPI[];

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private messageService: MessageService,
    private showAPIService: ShowAPIService,
    private timeslotAPIService: TimeSlotAPIService,
    private movieAPIService: MovieAPIService,
    private roomAPIService: RoomAPIService,
  ) { }

  ngOnInit() {
    this.addShowForm = this.formBuilder.group({
      dateRelease: '',
      price: '',
      status: '',
      roomId: '',
      movieId: '',
      timeslotId: '',
    });

    this.roomAPIService.GetList().then(
      res => {
        this.rooms = res as RoomAPI[];
      },
      err => {
        console.log(err);
      }
    );

    this.movieAPIService.findAll().then(
      res => {
        this.movies = res as MovieAPI[];
      },
      err => {
        console.log(err);
      }
    );
    
    this.timeslotAPIService.GetList().then(
      res => {
        this.timeslots = res as TimeSlotAPI[];
      },
      err => {
        console.log(err);
      }
    );

  }

  save() {
    var show: ShowAPI = this.addShowForm.value as ShowAPI;
    this.showAPIService.Add(show).then(
      res => {
        var result: any = res as any;
        if (result.status) {
          this.router.navigate(['/admin/show-listing'])
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