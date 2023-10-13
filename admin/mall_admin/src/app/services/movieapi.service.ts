import { Injectable } from "@angular/core";
import { BaseUrlService } from "./baseurl.service";
import { HttpClient } from "@angular/common/http";
import { lastValueFrom } from "rxjs";

@Injectable()
export class MovieAPIService{
    constructor(
        private baseUrlService : BaseUrlService,
        private httpClient : HttpClient
    ){}

    async findAll(){
        return await lastValueFrom(this.httpClient.get(this.baseUrlService.getBaseUrl() + 'movie/findall'));
    }

    async create(formData : FormData){
        return await lastValueFrom(this.httpClient.post(this.baseUrlService.getBaseUrl() + 'movie/create2', formData));
    }

    async delete(id: number){
        return await lastValueFrom(this.httpClient.delete(this.baseUrlService.getBaseUrl() + 'movie/delete/' + id));
    }

    async findByKeyword(keyword: string){
        return await lastValueFrom(this.httpClient.get(this.baseUrlService.getBaseUrl() + 'movie/findByKeyword/' + keyword));
    }

    async findById(id: string){
        return await lastValueFrom(this.httpClient.get(this.baseUrlService.getBaseUrl() + 'movie/find/' + id));
    }

    async update(formData : FormData){
        return await lastValueFrom(this.httpClient.put(this.baseUrlService.getBaseUrl() + 'movie/update2', formData));
    }
}