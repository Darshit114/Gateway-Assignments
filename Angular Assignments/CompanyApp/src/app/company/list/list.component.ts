import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DataService } from 'src/app/services/data.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css'],
})
export class ListComponent implements OnInit {
  companydata: any;

  constructor(private dataService: DataService, private router: Router) {}

  ngOnInit(): void {
    this.dataService.getAllCompanyData().subscribe((response: any) => {
      console.log(response);
      this.companydata = response;
    });
  }

  editCompany(company) {
    setTimeout(() => {
      this.router.navigateByUrl('/edit?id=' + company.id).then(() => {
        window.location.reload();
      });
    }, 1000);
  }

  deleteCompany(company) {
    const isdelete = confirm(
      'Are you sure you want to delete company: ' + company.name + '?'
    );

    if (isdelete) {
      this.dataService.deleteCompany(company.id).subscribe(
        (res) => {
          window.location.reload();
        },
        (error) => {
          console.log(error);
        }
      );
    }
  }

  viewCompany(company){
    setTimeout(() => {
      this.router.navigateByUrl('/view?id='+company.id).then(() => {
        window.location.reload();
      });
      
    }, 1000);
  }
}
