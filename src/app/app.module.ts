import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ModalModule } from 'ngb-modal';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { OverviewComponent } from './Components/Overview/overview.component';
import { AboutMeComponent } from './Components/About Me/aboutMe.component';
import { FeedbackComponent } from './Components/Feedback/feedback.component';
import { HomepageComponent } from './Components/Homepage/homepage.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AppDemosComponent } from './Components/AppDemos/appDemos.component';
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AdditionalDemosComponent } from './Components/Additional-demos/additional-demos.component';
import {StarRatingModule} from 'angular-star-rating';
import { RatingModule } from 'ng-starrating';
import { TransitionComponent } from './Components/transition/transition.component';
import { HttpClientModule, HttpClientJsonpModule } from '@angular/common/http';
import { WeatherAppComponent } from './Components/weather-app/weather-app.component';
import { SkyconsModule } from 'ngx-skycons';
import { ToDoListComponent } from './Components/to-do-list/to-do-list.component';
import { BrainGameComponent } from './Components/brain-game/brain-game.component';
import { CalendarAppComponent } from './Components/calendar-app/calendar-app.component';
import { CountdownModule } from 'ngx-countdown';

/* import { IgxToastModule, IgxCalendarModule, IgxTimePickerModule, IgxDatePickerModule } from 'igniteui-angular';
 */

@NgModule({
  declarations: [
    AppComponent,
    OverviewComponent,
    AboutMeComponent,
    FeedbackComponent,
    HomepageComponent,
    AppDemosComponent,
    AdditionalDemosComponent,
    TransitionComponent,
    WeatherAppComponent,
    ToDoListComponent,
    BrainGameComponent,
    CalendarAppComponent,
  ],
  imports: [
    HttpClientModule,
    HttpClientJsonpModule,
    BrowserModule,
    AppRoutingModule,
    ModalModule,
    NgbModule,
    BrowserAnimationsModule,
    FormsModule,
    RatingModule,
    SkyconsModule,


/*     IgxToastModule, IgxCalendarModule, IgxTimePickerModule, IgxDatePickerModule, */
    StarRatingModule.forRoot(),
    CountdownModule
  ],
  providers: [
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
