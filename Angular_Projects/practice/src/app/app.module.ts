import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomepageComponent } from './Components/Homepage/homepage.component';
import { OverviewComponent } from './Components/Overview/overview.component';
import { LoginPageComponent } from './Components/login-page/login-page.component';

@NgModule({
  declarations: [
    AppComponent,
    HomepageComponent,
    OverviewComponent,
    LoginPageComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
