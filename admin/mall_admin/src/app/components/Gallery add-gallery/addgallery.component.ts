
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { MessageService } from 'primeng/api';
import { GalleryAPI } from 'src/app/models/galleryapi.model';
import { GalleryAPIService } from 'src/app/services/galleryapi.service';

@Component({

  templateUrl: './addgallery.component.html',
})
export class AddGalleryComponent implements OnInit {

  addGalleryForm: FormGroup;
  file: File;

  constructor(
    private formBuilder: FormBuilder,
    private galleryAPIService: GalleryAPIService,
    private router: Router,
    private messageService: MessageService
  ) { }

  ngOnInit() {
    this.addGalleryForm = this.formBuilder.group({
      description: '',
    });

  }

  selectFile(evt: any) {
    this.file = evt.target.files[0];
  }

  save() {
    var gallery: GalleryAPI = this.addGalleryForm.value as GalleryAPI;
    var formData = new FormData();
    formData.append('file', this.file);
    formData.append('strGallery', JSON.stringify(gallery));
    this.galleryAPIService.create(formData).then(
      res => {
        var result: any = res as any;
        if (result.status) {
          this.messageService.add({
            severity: 'success',
            summary: 'Success',
            detail: 'Success'
          });
          this.router.navigate(['/admin/gallery-listing'])
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