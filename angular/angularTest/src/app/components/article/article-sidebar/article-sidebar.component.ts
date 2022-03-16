import { Component, OnInit } from '@angular/core';
import { ArticleSummary } from '../../../models/articles/article.models';
import { ArticleService } from '../../../services/articles/article.service';
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

  articleSummary: ArticleSummary;

  articleSummaryByTagPath$: Observable<Array<ArticleSummary>>;
  articleSummaryByTagPath: Array<ArticleSummary>;
  urlSegments: Array<UrlSegment>;
  tagPath: string;

  ngOnInit() {
    this.getArticlesSummary();

    const id: Observable<string> = this.route.params.pipe(map(p => p.id));
    const url: Observable<string> = this.route.url.pipe(map(segments => segments.join('')));
    // route.data includes both `data` and `resolve`
    const user = this.route.data.pipe(map(d => d.user));

    const tree: UrlTree = this.router.parseUrl(this.router.url);
    const g: UrlSegmentGroup = tree.root.children[PRIMARY_OUTLET];
    this.urlSegments = g.segments;
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

    this.tagPath = urlSegmentsArr.join('/');

    this.articleSummaryByTagPath$ = this.articleService.getArticlesSummaryByTagPath(null);

    this.articleSummaryByTagPath$.subscribe((summary: Array<ArticleSummary>) => {
      summary.forEach(x=>{
        x.headerImage = 
        this.articleService.appendApiUrlToHeaderImage(x.headerImage);});
        
      this.articleSummaryByTagPath = summary;
    });
  }
}
