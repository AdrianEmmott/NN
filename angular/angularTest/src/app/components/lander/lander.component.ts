import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap, convertToParamMap, UrlTree, PRIMARY_OUTLET, UrlSegment, UrlSegmentGroup } from '@angular/router';
import { TagService } from '../../services/tags/tag.service';
import { ArticleService } from '../../services/articles/article.service';
import { TagModel, ArticleSummary } from '../../models/articles/article.models';
import { Observable } from 'rxjs';
import { AppSettingsService } from '../../services/app-settings.service';

@Component({
  selector: 'app-lander',
  templateUrl: './lander.component.html',
  styleUrls: ['./lander.component.scss']
})
export class LanderComponent implements OnInit {

  constructor(public router: Router,
    private route: ActivatedRoute,
    private articleService: ArticleService,
    private tagService: TagService
    , private appSettingsService: AppSettingsService) {
     }

  tagObservable$: Observable<Array<TagModel>>;
  tags: Array<TagModel>;
  pageTitle: string;

  articleSummaryByTagPath$: Observable<Array<ArticleSummary>>;
  articleSummaryByTagPath: Array<ArticleSummary>;
  urlSegments: Array<UrlSegment>;
  urlSegmentsArr = new Array<string>();

  ngOnInit() {
    this.getArticlesSummary(this.router.url);

    this.pageTitle = this.router.url;

    const tree: UrlTree = this.router.parseUrl(this.router.url);
    const g: UrlSegmentGroup = tree.root.children[PRIMARY_OUTLET];
    this.urlSegments = g.segments;

    var previousSegment: string = "";

    this.urlSegments.forEach(segment => {
      if (previousSegment.length) {
        this.urlSegmentsArr.push("/" + previousSegment + "/" + segment.path);
        previousSegment += "/" + segment.path;
      }
      else {
        this.urlSegmentsArr.push("/" + segment.path);
        previousSegment = segment.path;
      }
    });
  }

  getArticlesSummary(tagPath: string) {
    var tag$ = this.tagService.getTagByPath(tagPath);
    tag$.subscribe((tagResponse: TagModel) => {
      this.articleSummaryByTagPath$ = this.articleService.getArticlesSummaryByTagPath(tagResponse.id);

      this.articleSummaryByTagPath$.subscribe((response: Array<ArticleSummary>) => {
        response = this.articleService.appendApiUrlToHeaderImage_articleSummaryList(response);

        this.articleSummaryByTagPath = response;
      });
    });
  }
}
