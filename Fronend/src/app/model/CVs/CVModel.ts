import { ExperienceInformationModel } from "../experience-information/ExperienceInformation";
import { PersonalInformationModel } from "../PersonalInformation";

export class CVModel {
  id: number = 0;
  name: string = "";
  personalInformation: PersonalInformationModel = new PersonalInformationModel();
  experienceInformation: ExperienceInformationModel[] = [];
}
