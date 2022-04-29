import { BrowserModule } from '@angular/platform-browser';
import { NgModule, Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { OverviewComponent } from './Components/Overview/overview.component';
import { AboutMeComponent } from './Components/About Me/aboutMe.component';
import { FeedbackComponent } from './Components/Feedback/feedback.component';
import { HomepageComponent } from './Components/Homepage/homepage.component';
import { AppDemosComponent } from './Components/AppDemos/appDemos.component';
import { AdditionalDemosComponent } from './Components/Additional-demos/additional-demos.component';
import { TransitionComponent } from './Components/transition/transition.component';
import { WeatherAppComponent } from './Components/weather-app/weather-app.component';
import { ToDoListComponent } from './Components/to-do-list/to-do-list.component';
import { BrainGameComponent } from './Components/brain-game/brain-game.component';
import { CalendarAppComponent } from './Components/calendar-app/calendar-app.component';

const routes: Routes = [
  { path: '', component: HomepageComponent },
  { path: 'overview', component: OverviewComponent },
  { path: 'aboutMe', component: AboutMeComponent },
  { path: 'feedback', component: FeedbackComponent },
  { path: 'demos', component: AppDemosComponent },
  { path: 'additional', component: AdditionalDemosComponent },
  { path: 'transition', component: TransitionComponent },
  { path: 'weather', component: WeatherAppComponent },
  { path: 'todo', component: ToDoListComponent },
  { path: 'brain', component: BrainGameComponent },
  { path: 'calendar', component: CalendarAppComponent },
];

@NgModule({
  declarations: [
    AppComponent,
    HomepageComponent,
    BrainGameComponent,
    OverviewComponent,
    FeedbackComponent,
    AppDemosComponent,
    AboutMeComponent,
    AdditionalDemosComponent,
    TransitionComponent,
    WeatherAppComponent,
    ToDoListComponent,
    CalendarAppComponent
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    FormsModule,
    RouterModule,
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
