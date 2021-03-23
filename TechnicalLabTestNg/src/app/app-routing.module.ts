import { PersonalInformationViewComponent } from './personal-information-view/personal-information-view.component';
import { PersonalInformationDtComponent } from './personal-information-dt/personal-information-dt.component';
import { PersonalInformationComponent } from './personal-information/personal-information.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  {path: 'PersonalInformation', component: PersonalInformationComponent},
  {path: 'PersonalInformationDt', component: PersonalInformationDtComponent},
  {path: 'PersonalInformationView', component: PersonalInformationViewComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
