import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { QuestionsComponent } from './questions/questions.component';


const routes: Routes = [
  { path:'', redirectTo: '/questions', pathMatch: 'full'},
  { path: 'questions', component: QuestionsComponent }
];

@NgModule({
  exports: [ RouterModule ],
  imports: [ RouterModule.forRoot(routes) ]
})
export class AppRoutingModule { }
