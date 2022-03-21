import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { AppRoutingModule } from "../app-routing.module";
import { CardLinkComponent } from "./components/cards/card-link/card-link.component";
import { MatTabsModule } from '@angular/material/tabs';
import { MatInputModule } from '@angular/material/input';
import { MatChipsModule } from '@angular/material/chips';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatBottomSheetModule } from '@angular/material/bottom-sheet';
import { MatListModule } from '@angular/material/list';
import { MatDialogModule } from '@angular/material/dialog';
import { MatSelectModule } from '@angular/material/select';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import {MatSlideToggleModule} from '@angular/material/slide-toggle';
import {MatTableModule} from '@angular/material/table';
import { FormComponent } from './components/forms/form/form.component';
import {MatRadioModule} from '@angular/material/radio';

//TODO
export const MATERIAL_ELEMENTS = [
    MatTabsModule,
    MatInputModule,
    MatChipsModule,
    MatButtonModule,
    MatIconModule,
    MatBottomSheetModule,
    MatListModule,
    MatDialogModule,
    MatSelectModule,
    MatCheckboxModule,
    MatTooltipModule,
    MatSnackBarModule,
    MatProgressBarModule,
    MatSlideToggleModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatPaginatorModule,
    MatTableModule,
    MatRadioModule
  ];
  
  export const APP_ELEMENTS = [
    CardLinkComponent,
    FormComponent
  ];

  @NgModule({
    declarations: [
      APP_ELEMENTS,
      FormComponent
    ],
    imports: [
      CommonModule,
      FormsModule,
      AppRoutingModule,
      MATERIAL_ELEMENTS
    ],
    exports: [
      MATERIAL_ELEMENTS,
      APP_ELEMENTS,
      AppRoutingModule
    ]
  })
  export class SharedModule { }