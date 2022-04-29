import { Component, OnInit, ViewChild } from '@angular/core';
import { NgbModal, NgbRating, ModalManager } from 'bootstrap';
import { Feedback } from '../../Objects/Feedback';
import { Inject } from '@angular/core';
import { DOCUMENT } from '@angular/common';
import { Validators, FormControl } from '@angular/forms';
import { HttpClient, HttpClientModule, HttpResponse, HttpHeaders } from '@angular/common/http'

@Component({
  selector: 'app-feedback',
  templateUrl: './feedback.component.html',
  styleUrls: ['./feedback.component.css']
})
export class FeedbackComponent implements OnInit {
 /* closeResult: string;
  currentRate;
  previousFeedback: Feedback[];
  element: HTMLElement;
  showTable: boolean;
  buttonChange: boolean;

  @ViewChild('myModal', { static: false }) myModal;
  private modalRef;*/
  constructor() {

  }


  ngOnInit(): void {
/*    this.previousFeedback = [];
    this.showTable = false;
    this.buttonChange = false;*/
  }


  submitForm(fname: string, fpicklist: string, fsuggestions: string, fcomments: string, frating: NgbRating) {
/*    console.log('form submit button pressed');
    // tslint:disable-next-line: prefer-const
    let fb: Feedback = {
    name: fname,
    comments: fcomments,
    picklist: fpicklist,
    rating: frating,
    suggestions: fsuggestions
    };


    fb.rating.readonly = true;
    this.previousFeedback.push(fb);
    console.log(fb);
    this.modalService.dismissAll();*/
  }

  openWindowCustomClass(fb) {
/*    console.log('Form opened');
    this.modalService.open(fb, { windowClass: 'dark-modal' });*/
  }

  showHideTable() {
/*    if (this.showTable === true) {
      this.showTable = false;
      this.buttonChange = false;
    } else {
      this.showTable = true;
      this.buttonChange = true;
    }*/
  }

}
