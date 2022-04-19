import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
  styleUrls: ['./homepage.component.css']
})
export class HomepageComponent implements OnInit {
  fullTime = '';
  fullDate = '';
  finalWeather = '';
  object = '';

  constructor() { }

  ngOnInit(): void {
    this.displayTime();
  }

  displayTime() {
    let now = new Date();

    let hours = now.getHours();
    let minutes = now.getMinutes();
    if (minutes < 10) {
      minutes = 0 + minutes;
    }

    let suffix = 'AM';
    if (hours > 12) {
      hours -= 12;
      suffix = 'PM';
    } else if  (hours === 12) {
      suffix = 'PM';
    }

    this.fullTime = hours + ':' + minutes + '' + suffix;

    let month = now.getMonth() + 1;
    let day = now.getDate();
    let year = now.getFullYear();
    this.fullDate = month + '/' + day + '/' + year;

  }



}
