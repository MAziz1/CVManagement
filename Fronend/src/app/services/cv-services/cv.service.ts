import { CVModel } from '@/model/CVs/CVModel';
import { CVsListModel } from '@/model/CVs/CVsListModel';
import { Response } from '@/model/Respone';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CvService {

  constructor(private http: HttpClient) { }

  AddCv(cvModel: CVModel): Observable<Response<CVModel>>{
    return this.http.post<Response<CVModel>>(`${environment.baseUrl}/Cvs/Create`, cvModel);
  }

  GetAllCvs(page:number = 1, pageSize:number = 10):Observable<Response<CVsListModel>>{
    return this.http.get<Response<CVsListModel>>(`${environment.baseUrl}/CVs/List?page=${page}&pageSize=${pageSize}`);
  }

  GetCv(id: number): Observable<Response<CVModel>>{
    return this.http.get<Response<CVModel>>(`${environment.baseUrl}/CVs?id=${id}`);
  }

  UpdateCV(cvModel: CVModel): Observable<Response<CVModel>>{
    return this.http.put<Response<CVModel>>(`${environment.baseUrl}/Cvs`, cvModel);
  }

  DeleteCV(id: number): Observable<Response<CVModel>>{
    return this.http.delete<Response<CVModel>>(`${environment.baseUrl}/CVs?id=${id}`);
  }
}
