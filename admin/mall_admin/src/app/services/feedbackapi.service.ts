import { Injectable } from "@angular/core";
import { BaseUrlService } from "./baseurl.service";
import { HttpClient } from "@angular/common/http";
import { lastValueFrom } from "rxjs";
import { FeedbackAPI } from "../models/feedbackapi.model";

@Injectable()
export class FeedbackAPIService{
    constructor(
        private baseUrlService : BaseUrlService,
        private httpClient : HttpClient
    ){}

    async findAll(){
        return await lastValueFrom(this.httpClient.get(this.baseUrlService.getBaseUrl() + 'feedback/findall'));
    }

    async delete(id: number){
        return await lastValueFrom(this.httpClient.delete(this.baseUrlService.getBaseUrl() + 'feedback/delete/' + id));
    }
    
    async findById(id: string){
        return await lastValueFrom(this.httpClient.get(this.baseUrlService.getBaseUrl() + 'feedback/find/' + id));
    }

    async create(feedback : FeedbackAPI){
        return await lastValueFrom(this.httpClient.post(this.baseUrlService.getBaseUrl() + 'feedback/create', feedback));
    }
}