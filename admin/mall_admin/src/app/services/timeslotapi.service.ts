import { Injectable } from "@angular/core";
import { BaseUrlService } from "./baseurl.service";
import { HttpClient } from "@angular/common/http";
import { lastValueFrom } from "rxjs";
import { TimeSlotAPI } from "../models/timeslotapi.model";

@Injectable()
export class TimeSlotAPIService{
    constructor(
        private baseUrlService : BaseUrlService,
        private httpClient : HttpClient
    ){}

    async GetList(){
        return await lastValueFrom(this.httpClient.get(this.baseUrlService.getBaseUrl() + 'timeslots'));
    }

    async Add(timeSlot : TimeSlotAPI){
        return await lastValueFrom(this.httpClient.post(this.baseUrlService.getBaseUrl() + 'timeslots/add', timeSlot));
    }

    async Delete(id: number){
        return await lastValueFrom(this.httpClient.put(this.baseUrlService.getBaseUrl() + 'timeslots/delete/' + id, null));
    }

    async GetItem(id: string){
        return await lastValueFrom(this.httpClient.get(this.baseUrlService.getBaseUrl() + 'timeslots/find/' + id));
    }

    async Update(timeSlot : TimeSlotAPI){
        return await lastValueFrom(this.httpClient.put(this.baseUrlService.getBaseUrl() + 'timeslots/update', timeSlot));
    }
}