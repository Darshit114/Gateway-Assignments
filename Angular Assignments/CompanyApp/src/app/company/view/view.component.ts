import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DataService } from 'src/app/services/data.service';

@Component({
  selector: 'app-view',
  templateUrl: './view.component.html',
  styleUrls: ['./view.component.css']
})
export class ViewComponent implements OnInit {

  companyData:any;

  constructor(private dataService:DataService,private activeRouter:ActivatedRoute) { }

  ngOnInit(): void {
    const id=this.activeRouter.snapshot.queryParamMap.get('id');
    
    this.dataService.getCompanyDetailsById(id).subscribe(data=>{
      this.companyData=data;
    })
  }

}
