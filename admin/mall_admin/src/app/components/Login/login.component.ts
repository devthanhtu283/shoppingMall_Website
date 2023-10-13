import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { AccountAPI } from 'src/app/models/accountapi.model';
import { AccountAPIService } from 'src/app/services/accountapi.service';
import { MessageService } from 'primeng/api';

@Component({

  templateUrl: './login.component.html',
})
export class LoginComponent implements OnInit {

  username: string;
  password: string;
  account: AccountAPI;
  logInForm: FormGroup

  constructor(
    private router: Router,
    private accountAPIService: AccountAPIService,
    private formBuilder: FormBuilder,
    private messageService: MessageService
  ) { }


  ngOnInit() {
    this.logInForm = this.formBuilder.group({
      username: '',
      password: ''
    });
  }

  login() {
    this.username = this.logInForm.value.username;
    this.password = this.logInForm.value.password;
    this.accountAPIService.login(this.username, this.password).then(
      res => {
        var value = res as any;
        if (value) {
          this.accountAPIService.setLogin(true);
          this.router.navigate(['/admin/dashboard']);
          console.log(this.accountAPIService.login(this.username, this.password));
        } else {
          this.router.navigate(['/forbidden']);
        }
      },
      err => {
        this.messageService.add({ 
          severity: 'error',
          summary: 'failed',
          detail: 'Username & Password are missing' 
      });
      }
    );
  }
}


