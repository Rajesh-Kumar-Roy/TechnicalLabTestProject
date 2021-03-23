import { PersonalInformationVm } from './../Models/PersonalInformationVm';
import { LanguageVm } from './../Models/LanguageVm';
import { CityVm } from './../Models/CityVm';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { CountryVm } from '../Models/CountryVm';

const baseUrl = 'https://localhost:44343/api/';
const headerOptions = {
  headers: new HttpHeaders({
    'content-Type': 'application/json'
  })
};
@Injectable({
  providedIn: 'root'
})
export class TechnicalLabTestService {

  private getData = new BehaviorSubject<PersonalInformationVm>(null);
  currentData = this.getData.asObservable();

  constructor(private http: HttpClient) { }

  //#region country

  getAllCountry(): Observable<CountryVm[]> {
    return this.http.get<CountryVm[]>(baseUrl + 'Country');
  }

  getCountryById(id: number): Observable<CountryVm> {
    return this.http.get<CountryVm>(`${baseUrl + 'country'}/${id}`);
  }

  //#endregion Country

  //#region City
  getAllCity(): Observable<CityVm[]> {
    return this.http.get<CityVm[]>(baseUrl + 'city');
  }

  getCityById(id: number): Observable<CityVm> {
    return this.http.get<CityVm>(`${baseUrl + 'city'}/${id}`);
  }
  getCityByCountryId(id: number): Observable<CityVm[]> {
    return this.http.get<CityVm[]>(`${baseUrl + 'city/GetByCountryId'}/${id}`);
  }

  //#endregion City

  //#region Language


  getAllLanguage(): Observable<LanguageVm[]> {
    return this.http.get<LanguageVm[]>(baseUrl + 'language');
  }

  getLanguageById(id: number): Observable<LanguageVm> {
    return this.http.get<LanguageVm>(`${baseUrl + 'language'}/${id}`);
  }
  //#endregion Language

  //#region Personal Information


  add(model: PersonalInformationVm): Observable<PersonalInformationVm> {
    return this.http.post<PersonalInformationVm>(baseUrl + 'PersonalInformation', model, headerOptions);
  }

  update(model: PersonalInformationVm): Observable<PersonalInformationVm> {
    return this.http.put<PersonalInformationVm>(`${baseUrl + 'PersonalInformation'}/${model.id}`, model, headerOptions);
  }
  delete(id: number): Observable<any> {
    return this.http.delete<any>(baseUrl + 'PersonalInformation' + `/${id}`)
  }
  getAllPersonalInfo(): Observable<PersonalInformationVm[]> {
    return this.http.get<PersonalInformationVm[]>(baseUrl + 'PersonalInformation');
  }

  getPersonalInfoById(id: number): Observable<PersonalInformationVm> {
    return this.http.get<PersonalInformationVm>(`${baseUrl + 'PersonalInformation'}/${id}`);
  }
  //#endregion Personal Information

  setData(data: PersonalInformationVm): void {
    this.getData.next(data);
  }
}
