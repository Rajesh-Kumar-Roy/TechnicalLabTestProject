import { Router } from '@angular/router';
import { PersonalInformationDetailVm } from './../Models/PersonalInformationDetailVm';
import { LanguageVm } from './../Models/LanguageVm';
import { CityVm } from './../Models/CityVm';
import { PersonalInformationVm } from './../Models/PersonalInformationVm';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CountryVm } from '../Models/CountryVm';

import { TechnicalLabTestService } from '../Service/technical-lab-test.service';
import { ToastRef, ToastrService } from 'ngx-toastr';



@Component({
  selector: 'app-personal-information',
  templateUrl: './personal-information.component.html',
  styleUrls: ['./personal-information.component.css']
})
export class PersonalInformationComponent implements OnInit, OnDestroy {

  public personalInfomationForm: FormGroup;
  public submitted = false;
  $Model: PersonalInformationVm = null;
  public countryList: CountryVm[] = [];
  public cityList: CityVm[] = [];
  public languageList: LanguageVm[] = [];
  $PersonalDetailsModel: PersonalInformationDetailVm = null;
  Modelid: number;



  constructor(
    private fb: FormBuilder,
    private _service: TechnicalLabTestService,
    private _tosterService: ToastrService,
    private router: Router
   

  ) {
    this.getDropDownData();
    this.$Model = new PersonalInformationVm();
    this.$PersonalDetailsModel = new PersonalInformationDetailVm();

  

  }


  ngOnInit(): void {
    this._service.currentData.subscribe(c => {
      if (c != null) {
        this.$Model = c;
        this.Modelid = c.id;
        this.getCitys(c.countryId);
        this.newForm();
       
      }
    });
    this.newForm();
  }

  ngOnDestroy(): void {
    this.personalInfomationForm = null;
  }
  getDropDownData(): void {
    // Calling County Data
    this._service.getAllCountry().subscribe((data: CountryVm[]) => {
      if (data?.length != 0) {
        this.countryList = data;
      }
    });

    // calling Language Data
    this._service.getAllLanguage().subscribe((data: LanguageVm[]) => {
      if (data?.length != 0) {
        this.languageList = data;
        this.newForm();
      }
    });
  }

  private newForm(): void {
    this.personalInfomationForm = this.fb.group({
      name: [this.$Model.name, [Validators.required]],
      countryId: [this.$Model.countryId, [Validators.required]],
      cityId: [this.$Model.cityId, [Validators.required]],
      dateTime: [this.$Model.dateTime, [Validators.required]],
      // file: [this.$Model.file, [Validators.required]],
      personalInformationDetails: this.addPersonalInformationDetailsGroup()

    });
  }

  private addPersonalInformationDetailsGroup(): FormArray {
    const formArray = new FormArray([]);
    let detail: PersonalInformationDetailVm[] = [];
    if (this.$Model.personalInformationDetails?.length > 0) {
      detail = this.$Model.personalInformationDetails;
    }
    else {
      this.languageList.forEach(element => {
        let obj = new PersonalInformationDetailVm();
        obj.id = 0;
        obj.personalInformationId = 0;
        obj.languageId = element.id;
        obj.languageName = element.name;
        obj.isChecked = false;
        detail.push(obj);
      });
    }
    detail?.forEach(element => {
      let sf = this.fb.group({
        id: element.id,
        personalInformationId: element.personalInformationId,
        languageId: element.languageId,
        languageName: element.languageName,
        isChecked: element.isChecked
      });
      formArray.push(sf);
    });

    return formArray;
  }

  public get personalInfo(): any {
    return this.personalInfomationForm.controls;
  }

  public get personalInfoDetail(): any {
    return this.personalInfomationForm.get('personalInformationDetails') as FormArray;
  }

  public countryChangedvalue(event) {
    const countryId = event.target.value;
   this.getCitys(countryId);
  }

  getCitys(countryId: number): void{
    this.cityList = [];
    this._service.getCityByCountryId(countryId).subscribe((data: CityVm[]) => {
      if (data?.length != 0) {
        this.cityList = data;
      }
    });
  }


  $ValidationCheckFile(fileEvent: any) {
    const file = fileEvent.target.files[0];
    if (String(file.type).slice(-3) == "pdf" || String(file.type).slice(-3) == "doc" || String(file.type).slice(-3) == "ord") {
      return null;
    } else {
      this.personalInfomationForm.controls.file.setErrors({ notValid: true });
    }
  }

  public onAdd(): void {
    this.submitted = true;
    if (this.personalInfomationForm.invalid) {
      return;
    }
    
    this.$Model = this.personalInfomationForm.value;
   this.$Model.id = this.Modelid;
    if(this.$Model.id > 0){
      this._service.update(this.$Model).subscribe((data: PersonalInformationVm) => {
        this._tosterService.info('Update Successfully!', 'Personal Information!');
        this.router.navigateByUrl('/PersonalInformationDt');
      });
    }
    else{
      this._service.add(this.$Model).subscribe((c: PersonalInformationVm) => {
        if (c.id > 0) {
          this._tosterService.success('Save Successfully!', 'Personal Information!');
        }
      });
    }
    }
   
}
