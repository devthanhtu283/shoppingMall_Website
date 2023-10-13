import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { MessageService } from 'primeng/api';
import { ProductAPI } from 'src/app/models/productapi.model';
import { ProductAPIService } from 'src/app/services/productapi.service';
import { CategoryAPIService } from "src/app/services/categoryapi.service";
import { CategoryAPI } from "src/app/models/categoryapi.model";

@Component({
  templateUrl: './add-product.component.html',
})
export class AddProductComponent implements OnInit {

  addProductForm: FormGroup;
  file: File;
  categories: CategoryAPI[];

  constructor(
    private formBuilder: FormBuilder,
    private productAPIService: ProductAPIService,
    private router: Router,
    private messageService: MessageService,
    private categoryAPIService: CategoryAPIService,
  ) { }

  ngOnInit() {
    this.addProductForm = this.formBuilder.group({
      name: '',
      price: '',
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

  selectFile(evt: any) {
    this.file = evt.target.files[0];
  }

  save() {
    var product: ProductAPI = this.addProductForm.value as ProductAPI;
    var formData = new FormData();
    formData.append('file', this.file);
    formData.append('strProduct', JSON.stringify(product));
    this.productAPIService.create(formData).then(
      res => {
        var result: any = res as any;
        if (result.status) {
          this.router.navigate(['/admin/product-listing'])
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