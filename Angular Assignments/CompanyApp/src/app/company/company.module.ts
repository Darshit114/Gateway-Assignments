import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddComponent } from './add/add.component';
import { ViewComponent } from './view/view.component';
import { EditComponent } from './edit/edit.component';
import { ListComponent } from './list/list.component';
import { DataService } from '../services/data.service';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [AddComponent, ViewComponent, EditComponent, ListComponent],
  imports: [CommonModule, FormsModule],
  exports: [AddComponent, EditComponent, ListComponent, ViewComponent],
  providers: [DataService],
})
export class CompanyModule {}
