import { Component, OnInit } from '@angular/core';
import { StoreAPI } from 'src/app/models/storeapi.model';
import { ActivatedRoute } from "@angular/router";
import { ProductAPIService } from 'src/app/services/productapi.service';
import { ProductAPI } from 'src/app/models/productapi.model';

@Component({
    templateUrl: './productdetail.component.html',
})
export class ProductDetailComponent implements OnInit {

    product: ProductAPI;

    constructor(
        private productAPIService: ProductAPIService,
        private activatedRoute : ActivatedRoute
    ) { }

    ngOnInit() {
        this.activatedRoute.paramMap.subscribe(p => {
            var id = p.get('id');
            this.productAPIService.findById(id).then(
                res => {
                    this.product = res as ProductAPI;
                },
                err => {
                    console.log(err);
                }
            );
        });
    }
}