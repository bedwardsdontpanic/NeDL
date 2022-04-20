import { Component, OnInit, Input, ViewChild, ElementRef, HostListener  } from '@angular/core';
import { Calendar } from '@fullcalendar/core';
import { ActivatedRoute, Router } from '@angular/router';
import dayGridPlugin from '@fullcalendar/daygrid';
import interactionPlugin from '@fullcalendar/interaction'; // for selectable
import timeGridPlugin from '@fullcalendar/timegrid';
import listPlugin, { ListView } from '@fullcalendar/list';
import * as moment from 'moment';
import { Options } from 'fullcalendar';
import * as $ from 'jquery';
// import view from '@fullcalendar/list/ListView';
import { data } from 'jquery';
import { DatePipe } from '@angular/common';
import { AUTO_STYLE } from '@angular/animations';
import 'bootstrap/dist/css/bootstrap.css';
import '@fortawesome/fontawesome-free/css/all.css'; // needs additional webpack config!


@Component({
  selector: 'app-calendar-app',
  templateUrl: './calendar-app.component.html',
  styleUrls: ['./calendar-app.component.css']
})
export class CalendarAppComponent implements OnInit {
  calendarPlugins = [dayGridPlugin, timeGridPlugin, listPlugin, interactionPlugin];
  calendarOptions = {
    plugins: [dayGridPlugin],
    initialView: 'dayGridMonth'
  };
  

  constructor() {
    const name = Calendar.name;
   }

  ngOnInit(): void {
    let calendarEl: HTMLElement = document.getElementById('calendar')!;

    let calendar = new Calendar(calendarEl, {
      plugins: [interactionPlugin, dayGridPlugin, timeGridPlugin, listPlugin ],
      navLinks: true, // can click day/week names to navigate views
      themeSystem: 'bootstrap',
      selectable: true,
      editable: true,
      eventOverlap: false,
      buttonText: {
          today:    'today',
          month:    'month',
          week:     'week',
          day:      'day',
          list:     'list',
          next:     'next',
          prev:     'back'
      },
      headerToolbar: {
        left: 'prev,next today',
        center: 'title',
        right: 'dayGridMonth,timeGridWeek,timeGridDay,listWeek'
      }

    });

    calendar.render();
  }
}
