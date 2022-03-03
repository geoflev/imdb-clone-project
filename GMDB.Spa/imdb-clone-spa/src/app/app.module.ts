import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './views/public/home/home.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SharedModule } from './shared/shared.module';
import { MovieCardComponent } from './views/public/movie-card/movie-card.component';
import { HttpClientModule } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { API_BASE_URL } from './shared/services/ImdbClient';
import { AdminComponent } from './views/admin/admin.component';
import { DashboardComponent } from './views/admin/dashboard/dashboard.component';
import { MoviesComponent } from './views/admin/movies/movies.component';
import { MovieFormComponent } from './views/admin/movies/movie-form/movie-form.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    MovieCardComponent,
    AdminComponent,
    DashboardComponent,
    MoviesComponent,
    MovieFormComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    SharedModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule
  ],
  providers: [
    {
      provide: API_BASE_URL,
      useValue: environment.apiBaseUrl
    },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
