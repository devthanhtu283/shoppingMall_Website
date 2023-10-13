import { Injectable } from "@angular/core";
import { BaseUrlService } from "./baseurl.service";
import { HttpClient } from "@angular/common/http";
import { lastValueFrom } from "rxjs";

@Injectable()
export class GalleryAPIService{
    constructor(
        private baseUrlService : BaseUrlService,
        private httpClient : HttpClient
    ){}
    
    async findAll(){
        return await lastValueFrom(this.httpClient.get(this.baseUrlService.getBaseUrl() + 'gallery/findall'));
    }
    async create(formData : FormData){
        return await lastValueFrom(this.httpClient.post(this.baseUrlService.getBaseUrl() + 'gallery/create2', formData));
    }
    async delete(id: number){
        return await lastValueFrom(this.httpClient.delete(this.baseUrlService.getBaseUrl() + 'gallery/delete/' + id));
    }
    async update(formData : FormData){
        return await lastValueFrom(this.httpClient.put(this.baseUrlService.getBaseUrl() + 'gallery/update2', formData));
    }
    async findById(id: string){
        return await lastValueFrom(this.httpClient.get(this.baseUrlService.getBaseUrl() + 'gallery/find/' + id));
    }

}