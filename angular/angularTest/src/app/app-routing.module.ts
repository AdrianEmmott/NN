import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from 'src/app/home/home.component';
import { PublisherComponent } from 'src/app/publisher/publisher.component';
import { ArticleComponent } from 'src/app/article/article.component';

const routes: Routes = [
  {path: '', component: HomeComponent, pathMatch: 'full', outlet: 'outlet-home'},
  {path: 'publisher/article/:id', component: PublisherComponent}
  , {path: 'articles/:id', component: ArticleComponent, pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
