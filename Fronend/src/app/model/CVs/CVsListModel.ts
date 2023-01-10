import { Response } from "../Respone"
import { CVModel } from "./CVModel";

export class CVsListModel
{
  recordsTotal: number;
  recordsFiltered: number;
  data: CVModel[] = []

}
