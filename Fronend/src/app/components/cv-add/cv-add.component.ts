import { CVModel } from '@/model/CVs/CVModel';
import { FormMode } from '@/model/enum/FormMode';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ActivatedRoute, ActivatedRouteSnapshot } from '@angular/router';
import { ExperienceAddComponent } from '@components/experience-add/experience-add.component';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { CvService } from '@services/cv-services/cv.service';
import { ExperienceinfoService } from '@services/experience-info-service/experienceinfo.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-cv-add',
  templateUrl: './cv-add.component.html',
  styleUrls: ['./cv-add.component.scss']
})
export class CvAddComponent implements OnInit {
  dtOptions: DataTables.Settings = {};
  // form control properties
  CVAddForm: FormGroup;
  cvNameCtrl: FormControl;
  fullNameCtrl: FormControl;
  cityNameCtrl: FormControl;
  emailCtrl: FormControl;
  mobileNumberCtrl: FormControl;
  formMode: FormMode = FormMode.Add;
  //#endregion end of properties
  cvModel: CVModel;
  private route: ActivatedRouteSnapshot;
  //#region functions

  constructor(private cvService: CvService, private modalService: NgbModal,
    private experienceInfoService: ExperienceinfoService, private activatedRoute: ActivatedRoute,
    private toastr: ToastrService,) {
    this.cvModel = new CVModel();
    this.route = activatedRoute.snapshot;
    this.formMode = this.route.data.mode;

  }
  ngOnInit(): void {
    this.BuildFormControls();
    this.CVAddForm = new FormGroup({
      cvNameCtrl: this.cvNameCtrl,
      fullNameCtrl: this.fullNameCtrl,
      cityNameCtrl: this.cityNameCtrl,
      emailCtrl: this.emailCtrl,
      mobileNumberCtrl: this.mobileNumberCtrl,
    });

    this.experienceInfoService.onExperienceAdded.subscribe(experienceInfo => {
      this.cvModel.experienceInformation.push(experienceInfo);
    })

    this.experienceInfoService.onExperienceDelete.subscribe(experienceInfoId => {
      const experienceInfo = this.cvModel.experienceInformation.find(experiecneInfo => experiecneInfo.id == experienceInfoId);
      experienceInfo.isDeleted = true;
    })

    this.experienceInfoService.onExperienceUpdated.subscribe(experienceInfo => {
      const index = this.cvModel.experienceInformation.findIndex(experiecneInfo => experiecneInfo.id == experiecneInfo.id);
      if (index > -1) { // only splice array when item is found
        this.cvModel.experienceInformation.splice(index, 1); // 2nd parameter means remove one item only
      }
      this.cvModel.experienceInformation.push(experienceInfo);
    });

    if(this.formMode == FormMode.Update){
      const cvId = this.route.params["id"];
      this.cvService.GetCv(cvId).subscribe(cv => {
        this.cvModel = cv.data;
      })
    }

  }


  // build form control
  BuildFormControls(): void {
    this.cvNameCtrl = new FormControl('', [Validators.required]);
    this.fullNameCtrl = new FormControl('', [Validators.required]);
    this.cityNameCtrl = new FormControl('');
    this.emailCtrl = new FormControl('', [Validators.email]);
    this.mobileNumberCtrl = new FormControl('', [Validators.required, Validators.pattern(/^-?(0|[1-9]\d*)?$/)]);
  }

  AddCV(): void {
    if (this.CVAddForm.valid) {
      this.cvService.AddCv(this.cvModel).subscribe(response => {
        if (response.status == 200) {
          this.toastr.success("CV addedd successfully");
          this.CVAddForm.reset();
        }
      })
    }
    else{
      this.CVAddForm.markAllAsTouched();
    }
  }
  UpdateCV(): void{
    if (this.CVAddForm.valid) {
      this.cvService.UpdateCV(this.cvModel).subscribe(response => {
        if (response.status == 200) {
          this.toastr.success("CV updated successfully");
        }
      })
    }
    else{
      this.CVAddForm.markAllAsTouched();
    }
  }
  OpenAddExperience() {
    this.modalService.open(ExperienceAddComponent, {
      size: 'lg',
      centered: true,
      backdrop: false
    });
  }

}
