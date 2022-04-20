import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import DarkSkyApi from 'dark-sky-api';
import {Daily} from '../../Objects/Daily';
import {SingleDay} from '../../Objects/SingleDay';
import { SkyconsModule } from 'ngx-skycons';
import { SkyconsTypes } from 'ngx-skycons';

@Component({
  selector: 'app-weather-app',
  templateUrl: './weather-app.component.html',
  styleUrls: ['./weather-app.component.css']
})
export class WeatherAppComponent implements OnInit {
  todayTemp: any;
  fullForecast: any;
  dayOne: any;
  dayOfWeek: any;
  theDay: any;
  days: any[] = [];


  public constructor(private http: HttpClient) {
   }

   public ngOnInit() {
    this.darkSkyWeather();
  }


  // dark sky
  public darkSkyWeather() {
    DarkSkyApi.apiKey = 'bdc733d36a3ba76b2003ef8bd09468d9';
    let position;
    DarkSkyApi.loadPosition().then(pos => {
        position = pos;
      });

    DarkSkyApi.loadCurrent().then((data) => {
        this.todayTemp = data.temperature;
        console.log(this.todayTemp);
    });

    DarkSkyApi.loadForecast().then((data) => {
      this.fullForecast = data;
      console.log(this.fullForecast);

      let jsonObj: any = JSON.parse(JSON.stringify(data)); // string to generic object first
      let darkSky: Daily = <Daily>jsonObj;


      for (let i = 0; i < 8; i++) {
//        this.days[i] = darkSky.daily.data[i];
        this.days[i] = this.fullForecast.daily.data[i];
        console.log(this.days[i]);





        // This sets the "time" object to correct date
        this.days[i].time = new Date(this.days[i].time * 1000);
        this.days[i].time = this.days[i].time.toDateString();
        console.log(this.days[i].time);

        // Sunrise
        this.days[i].sunriseTime = new Date(this.days[i].sunriseTime * 1000);
        this.days[i].sunriseTime = this.days[i].sunriseTime.toLocaleString();

        // Sunset
        this.days[i].sunsetTime = new Date(this.days[i].sunsetTime * 1000);
        this.days[i].sunsetTime = this.days[i].sunsetTime.toLocaleString();

        console.log('Low: ' + this.days[i].temperatureLow + ' ºF');
        console.log('High: ' + this.days[i].temperatureHigh + ' ºF');
        console.log(this.days[i].precipType);
        this.days[i].precipProbability = this.days[i].precipProbability * 100 + '%';
      }

    });

  }



  getDayOfWeek(date) {
    const dayOfWeek = new Date(date).getDay();
    return isNaN(dayOfWeek) ? null :
      ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday'][dayOfWeek];
  }


}


