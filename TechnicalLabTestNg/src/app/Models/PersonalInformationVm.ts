import { PersonalInformationDetailVm } from './PersonalInformationDetailVm';
export class PersonalInformationVm{
    id: number;
    name: string;
    countryId: number;
    cityId: number;
    dateTime: Date;
    file: number;
    personalInformationDetails: PersonalInformationDetailVm[]= []

    // Use for only View
    cityName: string;
    countryName: string;
}