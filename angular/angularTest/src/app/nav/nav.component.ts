import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap, convertToParamMap } from '@angular/router';
import { TagService } from '../tag.service';
import { TagModel } from '../article.models';
import { Observable } from 'rxjs';
import { switchMap } from 'rxjs/operators';
import { LanderComponent } from '../lander/lander.component';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss']
})
export class NavComponent implements OnInit {

  constructor(private router: Router,
              private route: ActivatedRoute,
              private tagService: TagService) { }

  public tagObservable$: Observable<Array<TagModel>>;
  public tags: Array<TagModel>;

  ngOnInit() {
    this.getTags();
  }

  getTags() {
    this.tagObservable$ = this.tagService.getTags();

    this.tagObservable$.subscribe((tags: Array<TagModel>) => {
      this.tags = tags;

      this.tags.forEach(tag => {
        this.router.config.unshift(
          { path: tag.path, component: LanderComponent, pathMatch: 'full' }
        );
      });

      console.log(this.router);
    });
  }
}
