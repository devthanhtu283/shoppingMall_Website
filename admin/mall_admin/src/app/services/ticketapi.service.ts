import { Injectable } from "@angular/core";
import { BaseUrlService } from "./baseurl.service";
import { HttpClient } from "@angular/common/http";
import { lastValueFrom } from "rxjs";
import { TicketAPI } from "../models/ticketapi.model";

@Injectable()
export class TicketAPIService{
    constructor(
        private baseUrlService : BaseUrlService,
        private httpClient : HttpClient
    ){}
    
    async Add(ticket: TicketAPI){
        return await lastValueFrom(this.httpClient.post(this.baseUrlService.getBaseUrl() + 'tickets/add', ticket ));
    }
    
    async Delete(id: number){
        return await lastValueFrom(this.httpClient.delete(this.baseUrlService.getBaseUrl() + 'tickets/delete/' + id));
    }

    async GetListByCustomerName(customerName : string){
        return await lastValueFrom(this.httpClient.get(this.baseUrlService.getBaseUrl() + 'tickets/getlistbycustomername/' + customerName));
    }

    async GetListByCustomerPhone(customerPhone : string){
        return await lastValueFrom(this.httpClient.get(this.baseUrlService.getBaseUrl() + 'tickets/getlistbycustomerphone/' + customerPhone));
    }

    async GetList(){
        return await lastValueFrom(this.httpClient.get(this.baseUrlService.getBaseUrl() + 'tickets/getlist'));
    }

    async GetItem(id: number){
        return await lastValueFrom(this.httpClient.get(this.baseUrlService.getBaseUrl() + 'tickets/getitem/' + id));
    }
}