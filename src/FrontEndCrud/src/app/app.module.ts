import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
//1. To work with Reactive Forms
import { ReactiveFormsModule } from '@angular/forms';
//2. To work with http requests
import { HttpClientModule } from '@angular/common/http';
//3. To work with material table
import { MatTableModule } from "@angular/material/table";
import { MatPaginatorModule } from '@angular/material/paginator';
//4. To work with material form controls
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from "@angular/material/input";
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';
import { MatDatepickerModule } from "@angular/material/datepicker";
import { MatNativeDateModule } from '@angular/material/core';
import { MomentDateModule } from "@angular/material-moment-adapter";
//5. To work with alerts
import { MatSnackBarModule } from "@angular/material/snack-bar";
//6. To work with icons
import { MatIconModule } from "@angular/material/icon";
//7. To work with modals
import { MatDialogModule } from "@angular/material/dialog";
//8. To work with Grids
import { MatGridListModule } from "@angular/material/grid-list";
import { DialogAddEditComponent } from './Dialogs/dialog-add-edit/dialog-add-edit.component';

@NgModule({
    declarations: [
        AppComponent,
        DialogAddEditComponent
    ],
    imports: [
        BrowserModule,
        BrowserAnimationsModule,
        ReactiveFormsModule,
        HttpClientModule,
        MatTableModule,
        MatPaginatorModule,
        MatFormFieldModule,
        MatInputModule,
        MatSelectModule,
        MatButtonModule,
        MatDatepickerModule,
        MatNativeDateModule,
        MomentDateModule,
        MatSnackBarModule,
        MatIconModule,
        MatDialogModule,
        MatGridListModule
    ],
    providers: [],
    bootstrap: [AppComponent]
})
export class AppModule { }
