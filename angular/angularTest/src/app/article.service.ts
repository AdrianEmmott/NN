import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse, HttpHeaders } from '@angular/common/http';
import { Article, ArticleSummary } from './article.models';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ArticleService {

  constructor(private httpClient: HttpClient) { }

  public getArticle(id: number): Observable<Article> {
    const article = this.httpClient
      .get<Article>('https://localhost:8080/api/articles/' + id);
    return article;
  }

  public getArticles(): Observable<Article> {
    const articles = this.httpClient
      .get<Article>('https://localhost:8080/api/articles');

    return articles;
  }

  public getArticlesSummary(): Observable<ArticleSummary> {
    const articlesSummary = this.httpClient
      .get<ArticleSummary>('https://localhost:8080/api/articles/summary');

    return articlesSummary;
  }

  public getArticlesSummaryByTagPath(tagPath: string): Observable<Article> {
    const myHeaders = new HttpHeaders();
    myHeaders.set('Content-Type', 'application/json');

    const article = this.httpClient
      .get<Article>('https://localhost:8080/api/articles/summary/tagpath?path=' + encodeURIComponent(tagPath));
    return article;
  }
}
