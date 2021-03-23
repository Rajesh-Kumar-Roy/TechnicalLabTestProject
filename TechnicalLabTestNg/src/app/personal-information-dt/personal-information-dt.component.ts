import { PersonalInformationVm } from './../Models/PersonalInformationVm';
import { Component, EventEmitter, OnDestroy, OnInit, Output } from '@angular/core';
import { TechnicalLabTestService } from '../Service/technical-lab-test.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-personal-information-dt',
  templateUrl: './personal-information-dt.component.html',
  styleUrls: ['./personal-information-dt.component.css']
})
export class PersonalInformationDtComponent implements OnInit, OnDestroy {

  public personalInfoDataList: PersonalInformationVm[] = [];
  public personalInfo: PersonalInformationVm;
  deleteId: number;
  public showPersonalinfoModel = false;

  constructor(
    private _service: TechnicalLabTestService,
    private router: Router,
    private toastr: ToastrService
  ) {
  }

  ngOnInit(): void {
   this.fetchData();
  }
  ngOnDestroy(): void {
    this.personalInfoDataList = [];
  }
  public deleteIdClick(id: any): void {
    this.deleteId = id;
  }

  editClick(data): void {
    this._service.setData(data);
    this.router.navigate(['/PersonalInformation']);
  }
  
  public getPeronalInformation(id: number): void {
    this.showPersonalinfoModel = true;
    this._service.getPersonalInfoById(id).subscribe((data: PersonalInformationVm) => {
      this.personalInfo = data;
    });
  }
  public deleteButtonClick(): void {
    this._service.delete(this.deleteId).subscribe( (res: any)=> {
      this.toastr.error('Delete Successfull', 'Message');
      this.fetchData();
    });
  }
  private fetchData(): void{
    this._service.getAllPersonalInfo().subscribe((data: PersonalInformationVm[]) => {
      if (data?.length != 0) {
        this.personalInfoDataList = data;
      }
    });
  }

}
