import { Injectable } from "@angular/core";
import { BaseUrlService } from "./baseurl.service";
import { HttpClient } from "@angular/common/http";
import { lastValueFrom } from "rxjs";
import { ShowAPI } from "../models/showapi.model";

@Injectable()
export class ShowAPIService{
    constructor(
        private baseUrlService : BaseUrlService,
        private httpClient : HttpClient
    ){}
    
    async Add(show: ShowAPI){
        return await lastValueFrom(this.httpClient.post(this.baseUrlService.getBaseUrl() + 'shows/add', show));
    }
    
    async Delete(id: number){
        return await lastValueFrom(this.httpClient.put(this.baseUrlService.getBaseUrl() + 'shows/delete/' + id.toString(),null));
    }

    async GetList(){
        return await lastValueFrom(this.httpClient.get(this.baseUrlService.getBaseUrl() + 'shows/getlist'));
    }

    async GetItem(id: number){
        return await lastValueFrom(this.httpClient.get(this.baseUrlService.getBaseUrl() + 'shows/getitem/' + id));
    }

    async GetShowById(id: number){
        return await lastValueFrom(this.httpClient.get(this.baseUrlService.getBaseUrl() + 'shows/getshowbyid/' + id));
    }
}