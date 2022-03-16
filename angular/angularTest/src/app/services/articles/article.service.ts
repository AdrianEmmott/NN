import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse, HttpHeaders } from '@angular/common/http';
import { Article, ArticleSummary } from '../../models/articles/article.models';
import { Observable } from 'rxjs';
import { AppSettingsService } from '../app-settings.service';

@Injectable({
  providedIn: 'root'
})
export class ArticleService {
  controllerName: string;

  constructor(private httpClient: HttpClient
    , private appSettingsService: AppSettingsService) {

    this.controllerName = this.appSettingsService.apiUrl + 'articles';
  }

  public getArticle(id: string): Observable<Article> {
    const article = this.httpClient
      //.get<Article>(this.controllerName + '/' + 'a266a0b3-a4a7-4b7d-942b-35a67bc2a320');
      .get<Article>(this.controllerName + '/' + id);
    return article;
  }

  public getArticles(): Observable<Article> {/*  */
    const articles = this.httpClient
      .get<Article>(this.controllerName);

    return articles;
  }

  public getArticlesSummary(): Observable<ArticleSummary> {
    const articlesSummary = this.httpClient
      .get<ArticleSummary>(this.controllerName + '/summary');
    return articlesSummary;
  }

  public getArticlesSummaryByTagPath(tagId: string): Observable<Array<ArticleSummary>> {
    var articleSummaries = this.httpClient
      .get<Array<ArticleSummary>>(this.controllerName + '/summary/' + tagId);

    return articleSummaries;
  }

  appendApiUrlToHeaderImage_articleSummaryList(articleSummaries: Array<ArticleSummary>): Array<ArticleSummary> {
    articleSummaries.forEach((article: ArticleSummary) => {
      article.headerImage = this.appendApiUrlToHeaderImage(article.headerImage);
    });

    return articleSummaries;
  }

  appendApiUrlToHeaderImage(headerImage: string): string {
    if (!headerImage.includes(this.appSettingsService.baseUrl)) {
      headerImage = this.appSettingsService.baseUrl + headerImage;
    }

    headerImage = headerImage.replace("//wwwroot", "/wwwroot");
    return headerImage;
  }
}
