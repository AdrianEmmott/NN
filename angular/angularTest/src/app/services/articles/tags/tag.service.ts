import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse, HttpHeaders } from '@angular/common/http';
import { TagModel, ArticleTagModel } from '../../../models/articles/article.models';
import { Observable } from 'rxjs';
import { AppSettingsService } from '../../app-settings.service';

@Injectable({
  providedIn: 'root'
})
export class TagService {
  controllerName: string;

  constructor(private httpClient: HttpClient
    , private appSettingsService: AppSettingsService) {
      //this.controllerName = this.appSettingsService.apiUrl + 'articles/tags';
      this.controllerName = 'http://localhost:8090/api/articles/tags';
    }

  public getTags(): Observable<TagModel[]> {
    const article = this.httpClient
      .get<TagModel[]>(this.controllerName + '/all/tree');
    return article;
  }

  public getTagsFlattened(): Observable<TagModel[]> {
    const article = this.httpClient
      .get<TagModel[]>(this.controllerName + '/all/flattened');
    return article;
  }

  public getTagsByArticleId(id: number): Observable<ArticleTagModel> {
    const articleTags = this.httpClient
      .get<ArticleTagModel>(this.controllerName + '/article/' + id);
    return articleTags;
  }

  public createArticleTags(articleTags: ArticleTagModel) {
    const myHeaders = new HttpHeaders();
    myHeaders.set('Content-Type', 'application/json');

    console.log(articleTags);

    this.httpClient.post(this.controllerName + '/create-article-tags'
      , articleTags
      , { headers: myHeaders })
      .subscribe();
  }

  public updateArticleTags(articleTags: ArticleTagModel) {
    const myHeaders = new HttpHeaders();
    myHeaders.set('Content-Type', 'application/json');

    this.httpClient.post(this.controllerName + '/update-article-tags'
      , articleTags
      , { headers: myHeaders }
      )
      .subscribe();
  }
}
