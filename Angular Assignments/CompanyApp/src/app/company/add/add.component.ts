import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DataService } from 'src/app/services/data.service';

export class Branch {
  branchid: any;
  branchname: any;
  branchaddress: any;
}

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css'],
})
export class AddComponent implements OnInit {
  companyobj = {
    email: '',
    name: '',
    totalEmployee: '',
    address: '',
    isCompanyActive: '',
    totalBranch: '',
    companyBranch: [],
  };

  branch = new Branch();
  branchArray = [] as any;

  companydata: any;

  constructor(private dataService: DataService, private router: Router) {}

  ngOnInit(): void {
    this.branch = new Branch();
  }

  AddCompany(formObject: any) {
    const data = {
      email: formObject.email,
      name: formObject.name,
      totalEmployee: formObject.totalEmployee,
      address: formObject.address,
      isCompanyActive: formObject.isCompanyActive,
      totalBranch: this.branchArray.length,
      companyBranch: this.branchArray,
    };
    this.dataService.createCompany(data).subscribe((res) => {
      alert('Added Successfully.');
      setTimeout(() => {
        this.router.navigate(['/index']).then(() => {
          window.location.reload();
        });
      }, 1000);
      // this.getLatestDetails();
    });
  }

  removeBranch(index: number) {
    this.branchArray.splice(index, 1);
    console.log(this.branchArray);
  }

  AddMore() {
    if (
      this.branch.branchid != undefined &&
      this.branch.branchname != undefined &&
      this.branch.branchaddress != undefined
    ) {
      this.branchArray.push(this.branch);
    }
    this.branch = new Branch();
    console.log(this.branchArray);
  }
}
