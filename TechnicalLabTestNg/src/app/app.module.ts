import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';

import { ToastrModule } from 'ngx-toastr';



import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PersonalInformationComponent } from './personal-information/personal-information.component';
import { PersonalInformationDtComponent } from './personal-information-dt/personal-information-dt.component';
import { PersonalInformationViewComponent } from './personal-information-view/personal-information-view.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { TechnicalLabTestService } from './Service/technical-lab-test.service';

@NgModule({
  declarations: [
    AppComponent,
    PersonalInformationComponent,
    PersonalInformationDtComponent,
    PersonalInformationViewComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule.withConfig({ warnOnNgModelWithFormControl: 'never' }),
    FormsModule,
    BrowserAnimationsModule,
    HttpClientModule,
    BsDatepickerModule.forRoot(),
    ToastrModule.forRoot({
      timeOut: 2000,
      progressBar: true,
      progressAnimation: 'increasing',
      preventDuplicates: true,
      positionClass: 'toast-top-center',

    }), 
  
  ],
  providers: [TechnicalLabTestService],
  bootstrap: [AppComponent]
})
export class AppModule { }
