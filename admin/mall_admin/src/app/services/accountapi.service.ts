import { Injectable } from "@angular/core";
import { BaseUrlService } from "./baseurl.service";
import { HttpClient } from "@angular/common/http";
import { lastValueFrom } from "rxjs";

@Injectable()
export class AccountAPIService {

    public _status: boolean = false;

    constructor(
        private baseUrlService: BaseUrlService,
        private httpClient: HttpClient,
    ) { }

    async login(username: String, password: String) {
        return await lastValueFrom(this.httpClient.get(this.baseUrlService.getBaseUrl() + 'account/login/' + username + '/' + password));
    }

    isLogged() {
        return this._status;
    }
    
    setLogin(status: boolean) {
        this._status = status;
    }
}