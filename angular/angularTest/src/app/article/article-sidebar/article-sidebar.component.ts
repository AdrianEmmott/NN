import { Component, OnInit } from '@angular/core';
import { ArticleSummary } from '../../article.models';
import { ArticleService } from '../../article.service';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Router, ActivatedRoute, UrlTree, UrlSegmentGroup, PRIMARY_OUTLET, UrlSegment } from '@angular/router';

@Component({
  selector: 'app-article-sidebar',
  templateUrl: './article-sidebar.component.html',
  styleUrls: ['./article-sidebar.component.scss']
})
export class ArticleSidebarComponent implements OnInit {

  constructor(private articleService: ArticleService,
              private router: Router,
              private route: ActivatedRoute) { }

  private articleSummary: ArticleSummary;

  private articleSummaryByTagPath$: Observable<Array<ArticleSummary>>;
  private articleSummaryByTagPath: Array<ArticleSummary>;
  private urlSegments: Array<UrlSegment>;
  private tagPath: string;

  ngOnInit() {
    this.getArticlesSummary();

    const id: Observable<string> = this.route.params.pipe(map(p => p.id));
    const url: Observable<string> = this.route.url.pipe(map(segments => segments.join('')));
    // route.data includes both `data` and `resolve`
    const user = this.route.data.pipe(map(d => d.user));

    const tree: UrlTree = this.router.parseUrl(this.router.url);
    const g: UrlSegmentGroup = tree.root.children[PRIMARY_OUTLET];
    this.urlSegments = g.segments;
    // console.log(this.urlSegments);
    // s[0].path; // returns 'team'
    // s[0].parameters; // returns {id: 33}
    // console.log(this.urlSegments[0].path);


    // this.urlSegments.forEach(segment => {
    //   if (segment.path === 'articles') {
    //     console.log('in there in there in there ');
    //     console.log(segment);
    //   }
    // });
  }

  getArticlesSummary() {
    const tree: UrlTree = this.router.parseUrl(this.router.url);
    const g: UrlSegmentGroup = tree.root.children[PRIMARY_OUTLET];
    this.urlSegments = g.segments;

    const urlSegmentsArr = new Array<string>();

    for (const segment of this.urlSegments) {
      if (segment.path === 'articles') {
        break;
      }
      urlSegmentsArr.push(segment.path);
    }

    console.log(urlSegmentsArr);
    this.tagPath = urlSegmentsArr.join('/');

    this.articleSummaryByTagPath$ = this.articleService.getArticlesSummaryByTagPath(urlSegmentsArr);

    this.articleSummaryByTagPath$.subscribe((summary: Array<ArticleSummary>) => {
      this.articleSummaryByTagPath = summary;
    });
  }
}
