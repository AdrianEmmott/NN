import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse, HttpHeaders } from '@angular/common/http';
import { Article, ArticleSummary } from '../models/article.models';
import { Observable } from 'rxjs';
import { map, tap } from 'rxjs/operators';
import { CreateArticleResponseModel } from '../models/response.model';

@Injectable({
  providedIn: 'root'
})
export class ArticlePublisherService {

  constructor(private httpClient: HttpClient) { }

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

    return this.httpClient.post<CreateArticleResponseModel>('https://localhost:8080/api/publisher/create-article'
      , article
      , { headers: myHeaders }).pipe(tap());
  }

  public updateArticle(article: Article) {
    const myHeaders = new HttpHeaders();
    myHeaders.set('Content-Type', 'application/json');

    this.httpClient.post('https://localhost:8080/api/publisher/update-article'
      , article
      , { headers: myHeaders })
      .subscribe();
  }
}
