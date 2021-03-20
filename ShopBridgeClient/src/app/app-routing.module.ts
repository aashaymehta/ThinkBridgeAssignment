import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ItemListComponent } from './inventory/item-list/item-list.component';
import { ItemDetailsComponent } from './inventory/item-details/item-details.component';
import { PageNotFoundComponent } from './inventory/page-not-found.component';


const routes: Routes = [
  {path: 'items', component: ItemListComponent},
  {path: 'item/:id', component: ItemDetailsComponent},
  {path: '', redirectTo: 'items', pathMatch: 'full'},
  {path: '**', component: PageNotFoundComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
