import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { ListComponent } from './company/list/list.component';
import { AddComponent } from './company/add/add.component';
import { EditComponent } from './company/edit/edit.component';
import { ViewComponent } from './company/view/view.component';


const routes: Routes = [
  { path: '', component: ListComponent },
  {path:'add',component:AddComponent},
  {path:'edit',component:EditComponent},
  {path:'view',component:ViewComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
