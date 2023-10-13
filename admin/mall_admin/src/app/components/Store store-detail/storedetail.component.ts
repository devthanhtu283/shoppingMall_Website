import { Component, OnInit } from '@angular/core';
import { StoreAPI } from 'src/app/models/storeapi.model';
import { StoreAPIService } from 'src/app/services/storeapi.service';
import { ActivatedRoute } from "@angular/router";

@Component({
    templateUrl: './storedetail.component.html',
})
export class StoreDetailsComponent implements OnInit {

    store: StoreAPI;

    constructor(
        private storeAPIService: StoreAPIService,
        private activatedRoute : ActivatedRoute
    ) { }

    ngOnInit() {
        this.activatedRoute.paramMap.subscribe(p => {
            var id = p.get('id');
            this.storeAPIService.findById(id).then(
                res => {
                    this.store = res as StoreAPI;
                },
                err => {
                    console.log(err);
                }
            );
        });
    }
}