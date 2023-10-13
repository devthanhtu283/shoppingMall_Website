import { Injectable } from "@angular/core";
import { BaseUrlService } from "./baseurl.service";
import { HttpClient } from "@angular/common/http";
import { lastValueFrom } from "rxjs";

@Injectable()
export class StoreAPIService{
    constructor(
        private baseUrlService : BaseUrlService,
        private httpClient : HttpClient
    ){}

    async findAll(){
        return await lastValueFrom(this.httpClient.get(this.baseUrlService.getBaseUrl() + 'store/findall'));
    }

    async create(formData : FormData){
        return await lastValueFrom(this.httpClient.post(this.baseUrlService.getBaseUrl() + 'store/create2', formData));
    }

    async delete(id: number){
        return await lastValueFrom(this.httpClient.delete(this.baseUrlService.getBaseUrl() + 'store/delete/' + id));
    }

    async findByKeyword(keyword: string){
        return await lastValueFrom(this.httpClient.get(this.baseUrlService.getBaseUrl() + 'store/findByKeyword/' + keyword));
    }

    async findById(id: string){
        return await lastValueFrom(this.httpClient.get(this.baseUrlService.getBaseUrl() + 'store/find/' + id));
    }

    async update(formData : FormData){
        return await lastValueFrom(this.httpClient.put(this.baseUrlService.getBaseUrl() + 'store/update2', formData));
    }
}