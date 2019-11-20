import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap, convertToParamMap, UrlTree, PRIMARY_OUTLET, UrlSegment, UrlSegmentGroup } from '@angular/router';
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
  private urlSegments: Array<UrlSegment>;

  ngOnInit() {
    this.getArticlesSummary(this.router.url);
  }

  getArticlesSummary(tagPath: string) {
    const tree: UrlTree = this.router.parseUrl(this.router.url);
    const g: UrlSegmentGroup = tree.root.children[PRIMARY_OUTLET];
    this.urlSegments = g.segments;
    // console.log(this.urlSegments);

    const urlSegmentsArr = new Array<string>();
    this.urlSegments.forEach(segment => {
        // console.log('in there in there in there ');
        urlSegmentsArr.push(segment.path);
        // console.log(urlSegmentsArr);
    });

    console.log(urlSegmentsArr);

    this.articleSummaryByTagPath$ = this.articleService.getArticlesSummaryByTagPath(urlSegmentsArr);

    this.articleSummaryByTagPath$.subscribe((summary: Array<ArticleSummary>) => {
      this.articleSummaryByTagPath = summary;
    });
  }
}
