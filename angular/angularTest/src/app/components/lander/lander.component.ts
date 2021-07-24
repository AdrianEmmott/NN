import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap, convertToParamMap, UrlTree, PRIMARY_OUTLET, UrlSegment, UrlSegmentGroup } from '@angular/router';
import { TagService } from '../../services/tag.service';
import { ArticleService } from '../../services/article.service';
import { TagModel, ArticleSummary } from '../../models/article.models';
import { Observable } from 'rxjs';
import { AppSettingsService } from '../../services/app-settings.service';

@Component({
  selector: 'app-lander',
  templateUrl: './lander.component.html',
  styleUrls: ['./lander.component.scss']
})
export class LanderComponent implements OnInit {

  constructor(private router: Router,
              private route: ActivatedRoute,
              private articleService: ArticleService,
              private tagService: TagService
              , private appSettingsService: AppSettingsService) { }

  public tagObservable$: Observable<Array<TagModel>>;
  public tags: Array<TagModel>;
  public pageTitle: string;

  private articleSummaryByTagPath$: Observable<Array<ArticleSummary>>;
  private articleSummaryByTagPath: Array<ArticleSummary>;
  private urlSegments: Array<UrlSegment>;
  urlSegmentsArr = new Array<string>();
    
  ngOnInit() {
    this.getArticlesSummary(this.router.url);
    
    this.pageTitle = this.router.url;

    const tree: UrlTree = this.router.parseUrl(this.router.url);
    const g: UrlSegmentGroup = tree.root.children[PRIMARY_OUTLET];
    this.urlSegments = g.segments;
    // console.log(this.urlSegments);

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

    this.articleSummaryByTagPath$ = this.articleService.getArticlesSummaryByTagPath(urlSegmentsArr);

    this.articleSummaryByTagPath$.subscribe((response: Array<ArticleSummary>) => {
      response = this.articleService.appendApiUrlToHeaderImage_articleSummaryList(response) ;
      this.articleSummaryByTagPath = response;
    });
  }
}
