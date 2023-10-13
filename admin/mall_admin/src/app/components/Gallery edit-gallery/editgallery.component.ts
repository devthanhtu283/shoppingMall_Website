import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { MessageService } from 'primeng/api';
import { GalleryAPI } from 'src/app/models/galleryapi.model';
import { GalleryAPIService } from 'src/app/services/galleryapi.service';

@Component({
    templateUrl: './editgallery.component.html',
})
export class EditGalleryComponent implements OnInit {

    editGalleryForm: FormGroup;
    file: File;
    gallery: GalleryAPI;
    formGroup: FormGroup

    constructor(
        private formBuilder: FormBuilder,
        private galleryAPIService: GalleryAPIService,
        private router: Router,
        private messageService: MessageService,
        private activatedRoute: ActivatedRoute
    ) { }

    ngOnInit() {
        this.activatedRoute.paramMap.subscribe(p => {
            var id = p.get('id');
            this.galleryAPIService.findById(id).then(
                res => {
                    this.gallery = res as GalleryAPI;
                    this.editGalleryForm = this.formBuilder.group({
                        description: this.gallery.description,
                    });
                },
                err => {
                    console.log(err);
                }
            );
        });
    }

    selectFile(evt: any) {
        this.file = evt.target.files[0];
    }

    save() {
        var gallery: GalleryAPI = this.editGalleryForm.value as GalleryAPI;
        gallery.id = this.gallery.id;
        var formData = new FormData();
        formData.append('file', this.file);
        formData.append('strGallery', JSON.stringify(gallery));
        this.galleryAPIService.update(formData).then(
            res => {
                var result: any = res as any;
                if (result.status) {
                    this.router.navigate(['/admin/gallery-listing'])
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