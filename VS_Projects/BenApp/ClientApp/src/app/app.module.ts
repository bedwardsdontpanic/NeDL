import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { HomepageComponent } from './Components/Homepage/homepage.component';
import { OverviewComponent } from './Components/Overview/overview.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { AboutMeComponent } from './Components/About Me/aboutMe.component';
import { AppDemosComponent } from './Components/AppDemos/appDemos.component';
import { TransitionComponent } from './Components/transition/transition.component';
import { BrainGameComponent } from './Components/brain-game/brain-game.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    HomepageComponent,
    CounterComponent,
    FetchDataComponent,
    OverviewComponent,
    TransitionComponent,
    AppDemosComponent,
    AboutMeComponent,
    BrainGameComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomepageComponent, pathMatch: 'full' },
      { path: 'overview', component: OverviewComponent },
      { path: 'aboutMe', component: AboutMeComponent },
      { path: 'demos', component: AppDemosComponent },
      { path: 'transition', component: TransitionComponent },
      { path: 'brain', component: BrainGameComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
