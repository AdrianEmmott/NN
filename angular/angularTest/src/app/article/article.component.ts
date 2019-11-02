import { Component, OnInit, ViewChild } from '@angular/core';
import { ArticleService } from 'src/app/article.service';
import { ArticleBodyComponent } from 'src/app/article/article-body/article-body.component';
import { ArticleMetadataComponent } from 'src/app/article/article-metadata/article-metadata.component';
import { Observable } from 'rxjs';
import { Router, ActivatedRoute, ParamMap, convertToParamMap } from '@angular/router';
import { switchMap } from 'rxjs/operators';
import { Article } from '../article.models';
import { DomSanitizer, SafeHtml } from '@angular/platform-browser';

@Component({
  selector: 'app-article',
  templateUrl: './article.component.html',
  styleUrls: ['./article.component.scss']
})
export class ArticleComponent implements OnInit {
  @ViewChild(ArticleBodyComponent, { static: false }) articleBodyComponent: ArticleBodyComponent;
  @ViewChild(ArticleMetadataComponent, { static: false }) articleMetaDataComponent: ArticleMetadataComponent;


  constructor(private articleService: ArticleService,
              private route: ActivatedRoute,
              private router: Router,
              private sanitizer: DomSanitizer) { }

  public articleObservable$: Observable<Article>;
  public safeContent: SafeHtml;
  private article: Article;

  ngOnInit() {
    this.getArticle();
  }

  getArticle() {
    this.articleObservable$ = this.route.paramMap.pipe(
      switchMap((params: ParamMap) =>
        this.articleService.getArticle(+params.get('id')))
    );

    this.articleObservable$.subscribe((article: Article) => {
      this.article = article;
      this.safeContent = this.sanitizer.bypassSecurityTrustHtml(this.article.content);
      console.log(this.safeContent);
      }
    );
  }
}
