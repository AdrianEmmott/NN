import { Component, OnInit } from '@angular/core';
import { ArticleSummary } from '../../article.models';
import { ArticleService } from '../../article.service';

@Component({
  selector: 'app-article-sidebar',
  templateUrl: './article-sidebar.component.html',
  styleUrls: ['./article-sidebar.component.scss']
})
export class ArticleSidebarComponent implements OnInit {

  constructor(private articleService: ArticleService) { }

  private articleSummary: ArticleSummary;

  ngOnInit() {
    this.getArticlesSummary();
  }

  getArticlesSummary() {
    const articleObservable$ = this.articleService.getArticlesSummary();

    articleObservable$.subscribe(
      x => this.articleSummary = x
    );
  }
}
