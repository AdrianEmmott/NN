import { Component, OnInit, Input } from '@angular/core';
import { Article, ArticleTagModel } from '../../../models/article.models';
import { TagService } from '../../../services/tag.service';
import { Router, ActivatedRoute, ParamMap, convertToParamMap } from '@angular/router';
import { Observable } from 'rxjs';
import { switchMap } from 'rxjs/operators';

@Component({
  selector: 'app-article-metadata',
  templateUrl: './article-metadata.component.html',
  styleUrls: ['./article-metadata.component.scss']
})
export class ArticleMetadataComponent implements OnInit {
  @Input() article: Article;

  constructor(private router: Router,
              private route: ActivatedRoute,
              private tagService: TagService) { }

  public articleTagsObservable$: Observable<ArticleTagModel>;
  public articleTags: ArticleTagModel;

  ngOnInit() {
    this.getArticleTags();
  }

  getArticleTags() {
    this.articleTagsObservable$ = this.route.paramMap.pipe(
      switchMap((params: ParamMap) =>
        this.tagService.getTagsByArticleId(+params.get('id')))
    );

    this.articleTagsObservable$.subscribe((articleTags: ArticleTagModel) => {
      this.articleTags = articleTags;
    });
  }
}
