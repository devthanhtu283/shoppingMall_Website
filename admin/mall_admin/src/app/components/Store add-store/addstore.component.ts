import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { MessageService } from 'primeng/api';
import { StoreAPI } from 'src/app/models/storeapi.model';
import { StoreAPIService } from 'src/app/services/storeapi.service';
import { CategoryAPI } from "src/app/models/categoryapi.model";
import { CategoryAPIService } from "src/app/services/categoryapi.service";


@Component({
  templateUrl: './addstore.component.html',
})
export class AddStoreComponent implements OnInit{

  addStoreForm: FormGroup;
  file: File;
  categories: CategoryAPI[];

  constructor(
    private formBuilder : FormBuilder,
    private storeAPIService : StoreAPIService,
    private router : Router,
    private messageService : MessageService,
    private categoryAPIService : CategoryAPIService
  ){}

  ngOnInit(){
    this.addStoreForm = this.formBuilder.group({
      name:'',
      description: '', 
      categoryId: ''
  });

  this.categoryAPIService.findAll().then(
    res => {
        this.categories = res as CategoryAPI[];
    },
    err => {
        console.log(err);
    }
);
  }

  selectFile(evt: any){
    this.file = evt.target.files[0];
  }

  save(){
    var store : StoreAPI = this.addStoreForm.value as StoreAPI;
    var formData = new FormData();
    formData.append('file', this.file);
    formData.append('strStore', JSON.stringify(store));
    this.storeAPIService.create(formData).then(
        res => {
            var result : any = res as any;
            if(result.status){
                this.router.navigate(['/admin/store-listing'])
            } else {
                this.messageService.add({ 
                    severity: 'error',
                    summary: 'failed',
                    detail: 'Add Failed' 
                });
            }
        },
        err => {
            console.log(err);
        }
    ); 
  }
}