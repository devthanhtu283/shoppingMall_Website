import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { MessageService } from 'primeng/api';
import { TicketAPI } from 'src/app/models/ticketapi.model';
import { TicketAPIService } from 'src/app/services/ticketapi.service';

@Component({
  templateUrl: './add-ticket.component.html',
})
export class AddTicketComponent implements OnInit {

  addTicketForm: FormGroup;
  file: File;
  tickets: TicketAPI[];

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private messageService: MessageService,
    private ticketAPIService: TicketAPIService,
  ) { }

  ngOnInit() {
    this.addTicketForm = this.formBuilder.group({
      nameCustomer: '',
      phoneCustomer: '',
      timeBooked: '',
      status: true,
      seatStatusId: ''
    });
  }

  save() {
    var ticket: TicketAPI = this.addTicketForm.value as TicketAPI;
    this.ticketAPIService.Add(ticket).then(
      res => {
        var result: any = res as any;
        if (result.status) {
          this.router.navigate(['/admin/ticket-listing'])
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