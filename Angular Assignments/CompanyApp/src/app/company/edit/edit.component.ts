import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DataService } from 'src/app/services/data.service';
import { Branch } from '../add/add.component';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css'],
})
export class EditComponent implements OnInit {
  companyData;
  branch = new Branch();
  branchList = [] as any;

  constructor(
    private dataService: DataService,
    private router: Router,
    private activeRouter: ActivatedRoute
  ) {}

  ngOnInit(): void {
    const id = this.activeRouter.snapshot.queryParamMap.get('id');
    this.dataService.getCompanyDetailsById(id).subscribe((data) => {
      this.companyData = data;
      this.branchList = this.companyData.companyBranch;
    });
  }

  UpdateCompany() {
    this.companyData.totalBranch = this.branchList.length;
    this.companyData.companyBranch = this.branchList;

    console.log(this.companyData);

    this.dataService.updateComapny(this.companyData).subscribe(
      (res) => {
        this.router.navigateByUrl('');
      },
      (error) => {
        console.log(error);
      }
    );
  }

  removeBranch(index: number) {
    this.branchList.splice(index, 1);
    console.log(this.branchList);
  }

  AddMore() {
    if (
      this.branch.branchid != undefined &&
      this.branch.branchname != undefined &&
      this.branch.branchaddress != undefined
    ) {
      this.branchList.push(this.branch);
    }
    this.branch = new Branch();
    console.log(this.branchList);
  }
}
