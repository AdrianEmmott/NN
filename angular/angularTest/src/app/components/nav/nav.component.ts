import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap, convertToParamMap } from '@angular/router';
import { TagService } from '../../services/articles/tags/tag.service';
import { TagModel } from '../../models/articles/article.models';
import { Observable } from 'rxjs';

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
  public navTags: Array<TagModel>;

  ngOnInit() {
    this.getTags();
  }

  getTags() {
    this.tagObservable$ = this.tagService.getTagsFlattened();

    this.tagObservable$.subscribe((tags: Array<TagModel>) => {
      this.navTags = new Array<TagModel>();

      tags.forEach(tag => {
        if (tag.showInNav) {
          this.navTags.push(tag);
        }
      });
    });
  }
}
