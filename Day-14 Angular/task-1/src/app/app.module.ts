import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeSectionComponent } from './home-section/home-section.component';
import { HomeCardsComponent } from './home-cards/home-cards.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeSectionComponent,
    HomeCardsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
