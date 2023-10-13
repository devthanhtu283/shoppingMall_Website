import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { MessageService } from 'primeng/api';
import { MovieAPI } from 'src/app/models/movieapi.model';
import { RoomAPI } from 'src/app/models/roomapi.model';
import { TimeSlotAPI } from 'src/app/models/timeslotapi.model';
import { RoomAPIService } from 'src/app/services/roomapi.service';
import { TimeSlotAPIService } from 'src/app/services/timeslotapi.service';

@Component({
  templateUrl: './add-timeSlot.component.html',
})
export class AddTimeSlotComponent implements OnInit {

  addTimeSlotForm: FormGroup;
  file: File;
  timeSlots: TimeSlotAPI[];

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private messageService: MessageService,
    private timeSlotAPIService: TimeSlotAPIService,
  ) { }

  ngOnInit() {
    this.addTimeSlotForm = this.formBuilder.group({
      name: '',
      startTime: '00:00:00',
      endTime: '00:00:00',
      status: true
    });
  }

  save() {
    var timeSlot: TimeSlotAPI = this.addTimeSlotForm.value as TimeSlotAPI;
    this.timeSlotAPIService.Add(timeSlot).then(
      res => {
        var result: any = res as any;
        if (result.status) {
          this.router.navigate(['/admin/timeSlot-listing'])
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