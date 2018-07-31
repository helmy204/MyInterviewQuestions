import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { QuestionsComponent } from './questions/questions.component';
import { AppRoutingModule } from './/app-routing.module';
import { AccountRegisterComponent } from './account-register/account-register.component';

@NgModule({
  declarations: [
    AppComponent,
    QuestionsComponent,
    AccountRegisterComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
