import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { MatSelectModule,
         MatTableModule,
         MatFormFieldModule,
         MatDatepickerModule,
         MatButtonModule,
         MatIconModule,
         MatCardModule,
         MatInputModule,
  MatNativeDateModule
} from '@angular/material';

import { SimulacaoService } from './simulacao.service';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    FormsModule,
    BrowserModule,
    MatIconModule,
    MatSelectModule,
    MatCardModule,
    MatTableModule,
    MatFormFieldModule,
    MatDatepickerModule,
    MatButtonModule,
    MatInputModule,
    MatNativeDateModule,
    ReactiveFormsModule,
    BrowserAnimationsModule
  ],
  providers: [
    SimulacaoService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
