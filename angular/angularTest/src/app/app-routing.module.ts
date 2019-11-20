import { NgModule } from '@angular/core';
import { Routes, RouterModule, Router, Route } from '@angular/router';
import { HomeComponent } from 'src/app/home/home.component';
import { PublisherComponent } from 'src/app/publisher/publisher.component';
import { ArticleComponent } from 'src/app/article/article.component';
import { TagModel } from './article.models';
import { Observable } from 'rxjs';
import { TagService } from './tag.service';
import { LanderComponent } from './lander/lander.component';

const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full', outlet: 'outlet-home' },
  { path: 'publisher/article/:id', component: PublisherComponent },
  { path: 'publisher/create', component: PublisherComponent },
  { path: 'articles/:id', component: ArticleComponent, pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { scrollPositionRestoration: 'enabled' })],
  exports: [RouterModule]
})
export class AppRoutingModule {
  public tagsObservable$: Observable<TagModel[]>;
  public tags: TagModel[];

  constructor(private tagService: TagService,
              private router: Router) {
    this.tagsObservable$ = this.tagService.getTagsFlattened();

    const dynamicRoutes = routes;

    this.tagsObservable$.subscribe((tags: Array<TagModel>) => {
      this.tags = tags;
      tags.forEach(tag => {
        dynamicRoutes.unshift(
          { path: tag.path.substring(1), component: LanderComponent, data: { tagId: tag.id } }
          , { path: tag.path.substring(1) + '/articles/:id', component: ArticleComponent }
        );
      });


      this.router.resetConfig(dynamicRoutes);
      this.router.onSameUrlNavigation = 'reload';
      // console.log(routes);
    });
  }
}
