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

  private articleSummaryByTagPath$: Observable<ArticleSummary>;
  private articleSummaryByTagPath: ArticleSummary;
  private urlSegments: Array<UrlSegment>;

  ngOnInit() {
    this.getArticlesSummary(this.router.url);

    const id: Observable<string> = this.route.params.pipe(map(p => p.id));
    const url: Observable<string> = this.route.url.pipe(map(segments => segments.join('')));
    // route.data includes both `data` and `resolve`
    const user = this.route.data.pipe(map(d => d.user));

    const tree: UrlTree = this.router.parseUrl(this.router.url);
    const g: UrlSegmentGroup = tree.root.children[PRIMARY_OUTLET];
    this.urlSegments = g.segments;
    console.log(this.urlSegments);
    // s[0].path; // returns 'team'
    // s[0].parameters; // returns {id: 33}
    // console.log(this.urlSegments[0].path);


    this.urlSegments.forEach(segment => {
      if (segment.path === 'articles') {
        console.log('in there in there in there ');
        console.log(segment);
      }
    });
  }

  getArticlesSummary(tagPath: string) {
    // console.log(tagPath);

    const searchIndex = tagPath.search('articles');
    if (searchIndex > 0) {
      // console.log('search works');
      // console.log(searchIndex);
      tagPath = tagPath.substring(0, searchIndex - 1);
      // console.log(tagPath);
    }

    this.articleSummaryByTagPath$ = this.articleService.getArticlesSummaryByTagPath(tagPath);

    this.articleSummaryByTagPath$.subscribe((summary: ArticleSummary) => {
      // console.log(summary);
      this.articleSummaryByTagPath = summary;
    });
  }
}
