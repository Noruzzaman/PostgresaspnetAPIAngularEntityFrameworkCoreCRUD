import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { DatePipe } from '@angular/common';
import { FurnitureDetailsComponent } from './furniture-details/furniture-details.component';
import { FurnitureFormComponent } from './furniture-details/furniture-form/furniture-form.component';

@NgModule({
  declarations: [
    AppComponent,
    FurnitureDetailsComponent,
    FurnitureFormComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [DatePipe],
  bootstrap: [AppComponent]
})
export class AppModule { }
