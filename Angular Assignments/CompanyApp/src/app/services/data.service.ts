import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DataService {


  sourceUrl = "http://localhost:3000/company";

  constructor(private http:HttpClient) { }

  getAllCompanyData(){
   return  this.http.get(this.sourceUrl);
  }

  createCompany(company:any){
    return this.http.post(this.sourceUrl,company);
  }

  getCompanyDetailsById(id:any)
  {
    return this.http.get(this.sourceUrl+"/"+id)
  }

  updateComapny(company:any){
    return this.http.put(this.sourceUrl+"/"+company.id,company)
  }

  deleteCompany(id){
    return this.http.delete(this.sourceUrl+"/"+id);
  }
}
