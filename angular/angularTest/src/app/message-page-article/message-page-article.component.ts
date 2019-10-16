import { Component, OnInit } from '@angular/core';
import { ArticleService } from 'src/app/article.service';
import { Observable } from 'rxjs';
import { Router, ActivatedRoute, ParamMap, convertToParamMap } from '@angular/router';
import { switchMap } from 'rxjs/operators';
import { Article } from '../article.models';
import { DomSanitizer, SafeHtml } from '@angular/platform-browser';

@Component({
  selector: 'app-message-page-article',
  templateUrl: './message-page-article.component.html',
  styleUrls: ['./message-page-article.component.scss']
})
export class MessagePageArticleComponent implements OnInit {
  constructor(private articleService: ArticleService,
              private route: ActivatedRoute,
              private router: Router,
              private sanitizer: DomSanitizer) {
  }

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
