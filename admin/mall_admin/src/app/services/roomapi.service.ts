import { Injectable } from "@angular/core";
import { BaseUrlService } from "./baseurl.service";
import { HttpClient } from "@angular/common/http";
import { lastValueFrom } from "rxjs";
import { RoomAPI } from "../models/roomapi.model";

@Injectable()
export class RoomAPIService{
    constructor(
        private baseUrlService : BaseUrlService,
        private httpClient : HttpClient
    ){}
    
    async GetList(){
        return await lastValueFrom(this.httpClient.get(this.baseUrlService.getBaseUrl() + 'rooms/findall'));
    }

    async Add(room: RoomAPI){
        return await lastValueFrom(this.httpClient.post(this.baseUrlService.getBaseUrl() + 'rooms/add', room));
    }

    async Delete(id: number){
        return await lastValueFrom(this.httpClient.delete(this.baseUrlService.getBaseUrl() + 'rooms/delete/' + id));
    }

    async GetItem(id: number){
        return await lastValueFrom(this.httpClient.get(this.baseUrlService.getBaseUrl() + 'rooms/' + id));
    }
    
}