import { Component } from "@angular/core";
import { FormBuilder, FormGroup } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { ShowDetail } from "src/app/models/show.model";
import { ShowAPIService } from "src/app/services/showAPI.service";
import * as moment from "moment";
import { TicketAddPost } from "src/app/models/ticket.model";
import { TicketAPIService } from "src/app/services/ticketAPI.service";
import { MessageService } from "primeng/api";

@Component({
  templateUrl: "./detailscinema.component.html",
})
export class DetailsCinemaComponent {
  constructor(
    private route: ActivatedRoute,
    private showAPIService: ShowAPIService,
    private formBuilder: FormBuilder,
    private ticketAPIService: TicketAPIService,
    private messageService: MessageService,
    private router: Router
  ) {}

  showDetail: ShowDetail;
  showId: string;
  widthGrid: string;
  BuyTicketForm: FormGroup;
  selectedSeatStatusesId: string[] = [];
  selectedSeatNames: string[] = [];
  dynamicSeatPlaceholder: string;
  tickets: TicketAddPost[];

  ngOnInit() {
    this.route.params.subscribe((params) => {
      const showIdParam = params["showId"];
      this.showId = showIdParam;
    });

    this.showAPIService.getDetail(Number(this.showId)).then(
      (res) => {
        this.showDetail = res as ShowDetail;
        this.widthGrid = `${this.showDetail.room.col * 38}px`;
        console.log("show details", res);
      },
      (err) => {
        console.log(err);
      }
    );

    this.selectedSeatStatusesId = [];
    this.selectedSeatNames = [];
    this.dynamicSeatPlaceholder = "";

    this.BuyTicketForm = this.formBuilder.group({
      NameCustomer: "",
      PhoneCustomer: "",
      TimeBooked: this.convertDateToString(new Date()),
      Status: true,
      SeatStatusId: this.selectedSeatStatusesId,
    });

    this.tickets = [];
  }

  toggleSeatNames(option: string) {
    if (this.selectedSeatNames.includes(option)) {
      this.selectedSeatNames = this.selectedSeatNames.filter(
        (val) => val !== option
      );
    } else {
      this.selectedSeatNames.push(option);
    }

    this.dynamicSeatPlaceholder = this.selectedSeatNames.join(", ");

    console.log(
      "🍳 ~ file: detailscinema.component.ts:60 ~ DetailsCinemaComponent ~ toggleSeatNames ~ this.selectedSeatNames:",
      this.selectedSeatNames
    );
  }
  toggleSeatStatusesId(option: string) {
    if (this.selectedSeatStatusesId.includes(option)) {
      this.selectedSeatStatusesId = this.selectedSeatStatusesId.filter(
        (val) => val !== option
      );
    } else {
      this.selectedSeatStatusesId.push(option);
    }
    console.log("this.selectedSeatStatusesId", this.selectedSeatStatusesId);
    this.BuyTicketForm.patchValue({
      SeatStatusId: this.selectedSeatStatusesId,
    });
  }
  convertDateToString(date: Date) {
    const formattedDate = moment(date).format("DD/MM/YYYY");

    return formattedDate;
  }
  reloadCurrentRoute(): void {
    const currentUrl = this.router.url;
    this.router.navigateByUrl("/", { skipLocationChange: true }).then(() => {
      this.router.navigate([currentUrl]);
    });
  }
  handleBuyTicket() {
    // var tickets: TicketAddPost = this.BuyTicketForm.value as TicketAddPost;
    var ticketTemp = this.BuyTicketForm.value;
    console.log(
      "🍳 ~ file: detailscinema.component.ts:101 ~ DetailsCinemaComponent ~ handleBuyTicket ~ ticketTemp:",
      ticketTemp
    );

    for (var i = 0; i < ticketTemp.SeatStatusId.length; i++) {
      var ticket = new TicketAddPost();
      ticket.NameCustomer = this.BuyTicketForm.get("NameCustomer").value;
      ticket.PhoneCustomer = this.BuyTicketForm.get("PhoneCustomer").value;
      ticket.Status = this.BuyTicketForm.get("Status").value;
      ticket.TimeBooked = this.BuyTicketForm.get("TimeBooked").value;
      ticket.SeatStatusId = ticketTemp.SeatStatusId[i];

      this.tickets.push(ticket);
    }

    console.log(
      "🍳 ~ file: detailscinema.component.ts:124 ~ DetailsCinemaComponent ~ handleBuyTicket ~ tickets:",
      this.tickets
    );

    this.ticketAPIService.add(this.tickets).then(
      (res) => {
        var result: any = res as any;
        console.log(result);
        if (result.status == true) {
          this.messageService.add({
            severity: "success",
            summary: "Success",
            detail: "Booked Success!",
          });
          setTimeout(() => {
            this.reloadCurrentRoute();
          }, 3000);
        } else {
          this.messageService.add({
            severity: "success",
            summary: "Success",
            detail: result.status,
          });
        }
      },
      (err) => {
        this.messageService.add({
          severity: "error",
          summary: "Failed",
          detail: "Something went wrong...",
        });
      }
    );
  }
}
