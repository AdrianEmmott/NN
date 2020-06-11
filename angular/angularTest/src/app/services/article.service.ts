import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse, HttpHeaders } from '@angular/common/http';
import { Article, ArticleSummary } from '../models/article.models';
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

  public getArticlesSummaryByTagPath(tagPaths: Array<string>): Observable<Array<ArticleSummary>> {
    // const tagPathsQueryString = '';

    // tagPaths.forEach(tagPath => {
    //   tagPathsQueryString.push(tagPath)
    //   console.log(tagPath);
    // });


    console.log(tagPaths);

    const articleSummaries = this.httpClient
      .get<Array<ArticleSummary>>('https://localhost:8080/api/articles/summary/tagpaths?tags=' + tagPaths);
    return articleSummaries;
  }
}
