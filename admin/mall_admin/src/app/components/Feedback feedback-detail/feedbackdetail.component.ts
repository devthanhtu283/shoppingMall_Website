import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from "@angular/router";
import { FeedbackAPIService } from 'src/app/services/feedbackapi.service';
import { FeedbackAPI } from 'src/app/models/feedbackapi.model';

@Component({
    templateUrl: './feedbackdetail.component.html',
})
export class FeedbackDetailComponent implements OnInit {

    feedback: FeedbackAPI;

    constructor(
        private feedbackAPIService: FeedbackAPIService,
        private activatedRoute : ActivatedRoute
    ) { }

    ngOnInit() {
        this.activatedRoute.paramMap.subscribe(p => {
            var id = p.get('id');
            this.feedbackAPIService.findById(id).then(
                res => {
                    this.feedback = res as FeedbackAPI;
                },
                err => {
                    console.log(err);
                }
            );
        });
    }
}