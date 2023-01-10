import { ExperienceInformationModel } from '@/model/experience-information/ExperienceInformation';
import { HttpClient } from '@angular/common/http';
import { EventEmitter, Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ExperienceinfoService {
  onExperienceAdded: EventEmitter<ExperienceInformationModel> = new EventEmitter();
  onExperienceUpdated: EventEmitter<ExperienceInformationModel> = new EventEmitter();
  onExperienceDelete: EventEmitter<number> = new EventEmitter();
  constructor(private http: HttpClient) { }
}
