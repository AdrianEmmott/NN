import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse, HttpHeaders } from '@angular/common/http';
import { Article, ArticleSummary } from '../../../models/articles/article.models';
import { Observable } from 'rxjs';
import { map, tap } from 'rxjs/operators';
import { CreateArticleResponseModel } from '../../../models/response.model';
import { AppSettingsService } from '../../app-settings.service';

@Injectable({
  providedIn: 'root'
})
export class ArticlePublisherService {
  controllerName: string;

  constructor(private httpClient: HttpClient
    , private appSettingsService: AppSettingsService) {
      this.controllerName = this.appSettingsService.apiUrl + 'articles/publisher'
    }

  public upsertArticle(article: Article) {
    if (article.id === 0) {
      return this.createArticle(article);
    } else {
      return this.updateArticle(article);
    }
  }

  public createArticle(article: Article): Observable<CreateArticleResponseModel> {
    const myHeaders = new HttpHeaders();
    myHeaders.set('Content-Type', 'application/json');

    return this.httpClient.post<CreateArticleResponseModel>(this.controllerName + '/create-article'
      , article
      , { headers: myHeaders }).pipe(tap());
  }

  public updateArticle(article: Article) {
    const myHeaders = new HttpHeaders();
    myHeaders.set('Content-Type', 'application/json');

    this.httpClient.post(this.controllerName + '/update-article'
      , article
      , { headers: myHeaders })
      .subscribe();
  }
}
