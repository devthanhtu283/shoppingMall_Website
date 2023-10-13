import { Component, OnInit } from '@angular/core';
import { Shop } from 'src/app/models/shop.model';
import { ShopAPIService } from 'src/app/services/shopAPI.service';
import { FormBuilder, FormGroup } from '@angular/forms';
@Component({

  templateUrl: './shopping.component.html',
})
export class ShoppingComponent implements OnInit{
  searchByName: FormGroup;
  constructor(
    private shopAPIService: ShopAPIService,
    private formBuilder: FormBuilder,
  ){}
  shops: Shop[];
  
  ngOnInit(): void {
    this.shopAPIService.findByCategoryID(2).then(
      res => {
          this.shops = res as Shop[]; 
          console.log(this.shops);
          
      },
      err => {
          console.log(err);
      }
     );
     this.searchByName = this.formBuilder.group({
      keyword: ''
    });
  }
  search(){
    
    var keyword: string = this.searchByName.value.keyword;
    this.shopAPIService.findByName(keyword, 2).then(
      res => {
          this.shops = res as Shop[]; 
          console.log(this.shops);
          
      },
      err => {
          console.log(err);
      }
     );
     if(keyword == ''){
      this.shopAPIService.findByCategoryID(1).then(
        res => {
            this.shops = res as Shop[]; 
            console.log(this.shops);
            
        },
        err => {
            console.log(err);
        }
       );
     }
  }
}