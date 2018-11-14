import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppComponent } from './app.component';
import { ClubsComponent } from './clubs/clubs.component';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { EventsComponent } from './events/events.component';
import { EventInfoComponent } from './event-info/event-info.component';
import { LoginComponent } from './login/login.component';
import { PagenotfoundComponent } from './pagenotfound/pagenotfound.component';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    ClubsComponent,
    HomeComponent,
    RegisterComponent,
    EventsComponent,
    EventInfoComponent,
    LoginComponent,
    PagenotfoundComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent },
      { path: 'events', component: EventsComponent },
      { path: 'register', component: RegisterComponent },
      { path: 'login', component: LoginComponent },
      { path: 'clubs', component: ClubsComponent },
      { path: 'event-info', component: EventInfoComponent },
      { path: '**', component: PagenotfoundComponent }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
