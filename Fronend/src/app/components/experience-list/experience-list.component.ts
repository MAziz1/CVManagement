import { FormMode } from '@/model/enum/FormMode';
import { ExperienceInformationModel } from '@/model/experience-information/ExperienceInformation';
import { Component, Input } from '@angular/core';
import { ExperienceAddComponent } from '@components/experience-add/experience-add.component';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ExperienceinfoService } from '@services/experience-info-service/experienceinfo.service';

@Component({
  selector: 'app-experience-list',
  templateUrl: './experience-list.component.html',
  styleUrls: ['./experience-list.component.scss']
})
export class ExperienceListComponent {
  @Input("experienceList") experienceList: ExperienceInformationModel[] = []
  constructor(private experienceInfoService: ExperienceinfoService, private modalService: NgbModal) {

  }
  Delete(experienceInfoId: number) {
    this.experienceInfoService.onExperienceDelete.emit(experienceInfoId);
  }

  Update(experienceInfo: ExperienceInformationModel) {
    this.experienceInfoService.onExperienceUpdated.emit(experienceInfo);
  }

  OpenUpdateExperienceInfo(experiecneInfo: ExperienceInformationModel) {
    const componentRef = this.modalService.open(ExperienceAddComponent, {
      size: 'lg',
      centered: true,
      backdrop: false
    });
    const experiecneInfoComponent = (componentRef.componentInstance as ExperienceAddComponent);
    experiecneInfoComponent.experienceInfoModel = experiecneInfo;
    experiecneInfoComponent.formMode = FormMode.Update;
  }
}
