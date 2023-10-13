import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { MessageService } from 'primeng/api';
import { StoreAPI } from 'src/app/models/storeapi.model';
import { CategoryAPI } from "src/app/models/categoryapi.model";
import { StoreAPIService } from 'src/app/services/storeapi.service';
import { CategoryAPIService } from "src/app/services/categoryapi.service";

@Component({
    templateUrl: './editstore.component.html',
})
export class EditStoreComponent implements OnInit{

    editStoreForm: FormGroup;
    file: File;
    store : StoreAPI;
    categories: CategoryAPI[];
    formGroup : FormGroup

    constructor(
        private formBuilder : FormBuilder,
        private storeAPIService : StoreAPIService,
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
        this.storeAPIService.findById(id).then(
        res => {
            this.store = res as StoreAPI;
            this.editStoreForm = this.formBuilder.group({
                name:this.store.name,
                description: this.store.description,
                categoryId: this.store.categoryId
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
        var store : StoreAPI = this.editStoreForm.value as StoreAPI;
        store.id = this.store.id;
        var formData = new FormData();
        formData.append('file', this.file);
        formData.append('strStore', JSON.stringify(store));
        this.storeAPIService.update(formData).then(
        res => {
            var result : any = res as any;
            if(result.status){
                this.router.navigate(['/admin/store-listing'])
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