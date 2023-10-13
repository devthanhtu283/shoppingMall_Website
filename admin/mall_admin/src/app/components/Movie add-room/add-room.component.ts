import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { MessageService } from 'primeng/api';
import { MovieAPI } from 'src/app/models/movieapi.model';
import { RoomAPI } from 'src/app/models/roomapi.model';
import { RoomAPIService } from 'src/app/services/roomapi.service';

@Component({
  templateUrl: './add-room.component.html',
})
export class AddRoomComponent implements OnInit {

  addRoomForm: FormGroup;
  file: File;
  rooms: RoomAPI[];

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private messageService: MessageService,
    private roomAPIService: RoomAPIService,
  ) { }

  ngOnInit() {
    this.addRoomForm = this.formBuilder.group({
      name: 'Room ',
      row: '',
      col: '',
      status: true
    });
  }

  save() {
    var room: RoomAPI = this.addRoomForm.value as RoomAPI;
    this.roomAPIService.Add(room).then(
      res => {
        var result: any = res as any;
        if (result.status) {
          this.router.navigate(['/admin/room-listing'])
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