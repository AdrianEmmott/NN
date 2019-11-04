import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap, convertToParamMap } from '@angular/router';
import { TagService } from '../tag.service';
import { ArticleService } from '../article.service';
import { TagModel, ArticleSummary } from '../article.models';
import { Observable } from 'rxjs';
import { switchMap } from 'rxjs/operators';


@Component({
  selector: 'app-lander',
  templateUrl: './lander.component.html',
  styleUrls: ['./lander.component.scss']
})
export class LanderComponent implements OnInit {

  constructor(private router: Router,
              private route: ActivatedRoute,
              private articleService: ArticleService,
              private tagService: TagService) { }

  public tagObservable$: Observable<Array<TagModel>>;
  public tags: Array<TagModel>;

  private articleSummaryByTagPath$: Observable<Array<ArticleSummary>>;
  private articleSummaryByTagPath: Array<ArticleSummary>;

  ngOnInit() {
    this.getArticlesSummary(this.router.url);
  }

  getArticlesSummary(tagPath: string) {
    this.articleSummaryByTagPath$ = this.articleService.getArticlesSummaryByTagPath(tagPath);

    this.articleSummaryByTagPath$.subscribe((summary: Array<ArticleSummary>) => {
      this.articleSummaryByTagPath = summary;
    });
  }
}
