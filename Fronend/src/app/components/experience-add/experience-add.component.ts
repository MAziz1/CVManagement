import { CVModel } from '@/model/CVs/CVModel';
import { FormMode } from '@/model/enum/FormMode';
import { ExperienceInformationModel } from '@/model/experience-information/ExperienceInformation';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ExperienceinfoService } from '@services/experience-info-service/experienceinfo.service';

@Component({
  selector: 'app-experience-add',
  templateUrl: './experience-add.component.html',
  styleUrls: ['./experience-add.component.scss']
})
export class ExperienceAddComponent implements OnInit {
  experienceInfoModel: ExperienceInformationModel;
  formMode: FormMode = FormMode.Add

  constructor(private experienceInfoService: ExperienceinfoService) {
    this.experienceInfoModel = new ExperienceInformationModel();
  }

  ngOnInit(): void {
    this.BuildFormControls();
    this.experienceForm = new FormGroup({
      companyNameCtrl: this.companyNameCtrl,
      cityCtrl: this.cityCtrl,
      companyFieldCtrl: this.companyFieldCtrl,
    });
  }

  // form control properties
  experienceForm: FormGroup;
  companyNameCtrl: FormControl;
  cityCtrl: FormControl;
  companyFieldCtrl: FormControl;

  //#endregion end of properties
  experienceInfo: ExperienceInformationModel = new ExperienceInformationModel();
  //#region functions

  // build form control
  BuildFormControls(): void {
    this.companyNameCtrl = new FormControl('', [Validators.required, Validators.max(20)]);
    this.cityCtrl = new FormControl('');
    this.companyFieldCtrl = new FormControl('');
  }

  AddExperience() {
    if (this.experienceForm.valid) {
      const experienceInfo = new ExperienceInformationModel(this.experienceInfoModel.companyName,
        this.experienceInfoModel.city,
        this.experienceInfoModel.companyField);
      this.experienceInfoService.onExperienceAdded.emit(experienceInfo);
      this.experienceForm.reset();
    }
    else{
      this.experienceForm.markAllAsTouched();
    }
  }
  UpdateExperience() {
    if (this.experienceForm.valid) {
      this.experienceInfoService.onExperienceUpdated.emit(this.experienceInfoModel);
    }
    else{
      this.experienceForm.markAllAsTouched();
    }
  }
}
