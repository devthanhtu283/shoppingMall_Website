import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { MessageService } from 'primeng/api';
import { CategoryAPI } from "src/app/models/categoryapi.model";
import { CategoryAPIService } from "src/app/services/categoryapi.service";
import { ProductAPI } from 'src/app/models/productapi.model';
import { ProductAPIService } from 'src/app/services/productapi.service';

@Component({
    templateUrl: './editproduct.component.html',
})
export class EditProductComponent implements OnInit{

    editProductForm: FormGroup;
    file: File;
    product : ProductAPI;
    categories: CategoryAPI[];
    formGroup : FormGroup

    constructor(
        private formBuilder : FormBuilder,
        private productAPIService : ProductAPIService ,
        private categoryAPIService : CategoryAPIService,
        private router : Router,
        private messageService : MessageService,
        private activatedRoute : ActivatedRoute
    ){}

    ngOnInit(){
    this.categoryAPIService.findAll().then(
        res => {
            this.categories = res as CategoryAPI[];
        },
        err => {
            console.log(err);
        }
    );

    this.activatedRoute.paramMap.subscribe(p => {
        var id = p.get('id');
        this.productAPIService.findById(id).then(
        res => {
            this.product = res as ProductAPI;
            this.editProductForm = this.formBuilder.group({
                name: this.product.name,
                price: this.product.price,
                description: this.product.description,
                categoryId: this.product.idcategory
            });
        },
        err => {
            console.log(err);
        }
    );
    });
}

    selectFile(evt: any){
    this.file = evt.target.files[0];
    }

    save(){
        var product : ProductAPI = this.editProductForm.value as ProductAPI;
        product.id = this.product.id;
        var formData = new FormData();
        formData.append('file', this.file);
        formData.append('strProduct', JSON.stringify(product));
        this.productAPIService.update(formData).then(
        res => {
            var result : any = res as any;
            if(result.status){
                this.router.navigate(['/admin/product-listing'])
            } else {
                this.messageService.add({ 
                    severity: 'error',
                    summary: 'failed',
                    detail: 'Edit Failed' 
                });
            }
        },
        err => {
            this.messageService.add({ 
                severity: 'error',
                summary: 'failed',
                detail: 'Edit Failed' 
            });
        }
        );  
    }
}