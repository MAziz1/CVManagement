export class ExperienceInformationModel
{
  id: number = 0;
  companyName: string = '';
  city: string = '';
  companyField: string = '';
  isDeleted: boolean = false;

  constructor(_companyName: string = '', _city:string = '', _companyField: string = ''){
    this.companyName = _companyName;
    this.city = _city;
    this.companyField = _companyField;
  }
}
