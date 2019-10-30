import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse, HttpHeaders } from '@angular/common/http';
import { TagModel, ArticleTagModel } from './article.models';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class TagService {

  constructor(private httpClient: HttpClient) { }

  public getTags(): Observable<TagModel[]> {
    const article = this.httpClient
      .get<TagModel[]>('https://localhost:8080/api/tags/all');
    return article;
  }

  public getTagsByArticleId(id: number): Observable<ArticleTagModel> {
    const articleTags = this.httpClient
      .get<ArticleTagModel>('https://localhost:8080/api/tags/article/' + id);
    return articleTags;
  }
}