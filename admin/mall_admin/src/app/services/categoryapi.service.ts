import { Injectable } from "@angular/core";
import { BaseUrlService } from "./baseurl.service";
import { HttpClient } from "@angular/common/http";
import { lastValueFrom } from "rxjs";

@Injectable()
export class CategoryAPIService{
    constructor(
        private baseUrlService : BaseUrlService,
        private httpClient : HttpClient
    ){}
    
    async findAll(){
        return await lastValueFrom(this.httpClient.get(this.baseUrlService.getBaseUrl() + 'category/findall'));
    }
    
}