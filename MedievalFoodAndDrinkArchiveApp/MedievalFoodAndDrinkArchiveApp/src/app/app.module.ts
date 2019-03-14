import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { HttpClientModule } from '@angular/common/http';

import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatRadioButton } from '@angular/material/radio';
import { MatSelectModule } from '@angular/material/select';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatSliderModule } from '@angular/material/slider';
import { MatSidenavModule } from '@angular/material/sidenav';


import { AppRoutingModule } from './app-routing.module';

import { 
    MatButtonModule, 
    MatInputModule, 
    MatCardModule, 
    MatListModule, 
    MatToolbarModule,
    MatExpansionModule,
    MatRadioModule,
    MatDialogModule
  } from '@angular/material'

import 'hammerjs';

import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { DishesComponent } from './dishes.component';
import { ApiService } from './medievalmealarchive.service';




@NgModule({
    declarations: [
        AppComponent,
        HeaderComponent,
        DishesComponent

    ],
    imports: [
        BrowserModule,
        AppRoutingModule,
        MatToolbarModule,
        HttpClientModule,
        MatCardModule,
        MatListModule,
        MatToolbarModule,
        MatExpansionModule,
        MatRadioModule,
        MatDialogModule

    ],
    providers: [ApiService],
    bootstrap: [AppComponent]
})
export class AppModule { }
