import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { routing } from './app-routing';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { MatDialogModule } from '@angular/material/dialog';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatTooltipModule } from '@angular/material/tooltip';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ButtonComponent } from './components/button/button.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { HomeComponent } from './components/home/home.component';
import { MenuComponent } from './components/menu/menu.component';
import { StartComponent } from './components/start/start.component';
import { HistoryComponent } from './components/history/history.component';
import { NavigationbarComponent } from './components/navigationbar/navigationbar.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { DetailDialogComponent } from './components/detail-dialog/detail-dialog.component';
import { NeedHelpDialogComponent } from './components/need-help-dialog/need-help-dialog.component';
import { ContinueDialogComponent } from './components/continue-dialog/continue-dialog.component';


@NgModule({
  declarations: [
    AppComponent,
    ButtonComponent,
    LoginComponent,
    RegisterComponent,
    HomeComponent,
    MenuComponent,
    StartComponent,
    HistoryComponent,
    NavigationbarComponent,
    DetailDialogComponent,
    NeedHelpDialogComponent,
    ContinueDialogComponent,


  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    routing,
    HttpClientModule,
    FormsModule,
    FontAwesomeModule,
    MatDialogModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatIconModule,
    MatTooltipModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
