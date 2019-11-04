import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { TagModel } from './article.models';
import { TagService } from './tag.service';
import { LanderComponent } from './lander/lander.component';
import { ArticleComponent } from './article/article.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  constructor(private router: Router,
              private tagService: TagService, ) { }

  title = 'Network News';

  public tagObservable$: Observable<Array<TagModel>>;
  public tags: Array<TagModel>;


  ngOnInit(): void {
    this.getTags();
  }

  getTags() {
    this.tagObservable$ = this.tagService.getTagsFlattened();

    this.tagObservable$.subscribe((tags: Array<TagModel>) => {
      this.tags = tags;

      this.tags.forEach(tag => {
        this.router.config.unshift(
          { path: tag.path.substring(1), component: LanderComponent, data: { tagId: tag.id } }
          , { path: tag.path.substring(1) + '/articles/:id', component: ArticleComponent, pathMatch: 'full' }
        );
      });

      console.log(this.router);
    });
  }
}
