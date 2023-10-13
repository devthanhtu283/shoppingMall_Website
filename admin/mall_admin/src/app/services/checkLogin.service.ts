import { Injectable } from "@angular/core";
import { CanActivate} from "@angular/router";
import { AccountAPIService } from "./accountapi.service";

@Injectable()
export class checkLoginService implements CanActivate{

    constructor(
        private accountAPIService: AccountAPIService
    ){}

    canActivate() {
        return this.accountAPIService.isLogged();
    }
    
}