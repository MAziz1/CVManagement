import { CVModel } from '@/model/CVs/CVModel';
import { Component, OnInit, ViewChild } from '@angular/core';
import { CvService } from '@services/cv-services/cv.service';
import { DataTableDirective } from 'angular-datatables';

@Component({
  selector: 'app-cv-list',
  templateUrl: './cv-list.component.html',
  styleUrls: ['./cv-list.component.scss']
})
export class CvListComponent implements OnInit {
  dtOptions: DataTables.Settings = {};
  cvList: CVModel[];
  @ViewChild(DataTableDirective, { static: false }) dtElement: DataTableDirective;
  constructor(private cvService: CvService) {
    this.cvList = [];
  }

  ngOnInit(): void {
    this.GetAllCVs();
  }

  GetAllCVs() {
    this.dtOptions = {
      serverSide: true,
      processing: true,
      pageLength: 10,
      lengthChange: false,
      info: false,
      searching: false,
      ajax: (dataTablesParameters: any, callback: any) => {
        debugger;
        const pageNumber: number = (dataTablesParameters.start / 10) + 1;
        this.cvService.GetAllCvs(pageNumber, 10).subscribe((cvs) => {
          this.cvList = cvs.data.data;
          debugger;
          callback({
            recordsTotal: cvs.data.recordsTotal,
            recordsFiltered: cvs.data.recordsFiltered,
            data: [],
          });
        });
      }
    }
  }

  Delete(id: number) {
    this.cvService.DeleteCV(id).subscribe(response => {
      if (response.status == 200) {
        alert("CV delete successfully");
        this.GetAllCVs();
        this.dtElement.dtInstance.then((dtInstance: DataTables.Api) => {
          dtInstance.draw();
        });
      }
    });
  }
}
