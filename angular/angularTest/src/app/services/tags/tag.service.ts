import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse, HttpHeaders } from '@angular/common/http';
import { TagModel, ArticleTagModel } from '../../models/articles/article.models';
import { Observable, pipe } from 'rxjs';
import { AppSettingsService } from '../app-settings.service';
import { delay, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class TagService {
  controllerName: string;
  delay: any;

  constructor(private httpClient: HttpClient
    , private appSettingsService: AppSettingsService) {

      this.appSettingsService.loadAppConfig().subscribe((data: any) => {
        this.appSettingsService.apiUrl = data.APIUrl;

        this.controllerName = this.appSettingsService.apiUrl + 'tags';
      });

      
    this.controllerName = 'http://localhost:8090/api/tags';
  }

  public getTagByPath(path: string): Observable<TagModel> {
    if (path.startsWith('/')) {
      path = path.substring(1);
    }

    path = encodeURI(path);

    var model = this.httpClient
      .get<TagModel>(this.controllerName + '/path/' + path);

    return model;

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

  public getTagsByArticleId(id: string): Observable<ArticleTagModel> {
    const articleTags = this.httpClient
      //.get<ArticleTagModel>(this.controllerName + '/article/' + id);
      .get<ArticleTagModel>(this.controllerName + '/article/a266a0b3-a4a7-4b7d-942b-35a67bc2a320');
    return articleTags;
  }

  public createArticleTags(articleTags: ArticleTagModel) {
    const myHeaders = new HttpHeaders();
    myHeaders.set('Content-Type', 'application/json');

    this.httpClient.post(this.controllerName + '/create-article-tags'
      , articleTags
      , { headers: myHeaders })
      .subscribe();
  }

  public updateArticleTags(articleTags: Array<ArticleTagModel>) {
    const myHeaders = new HttpHeaders();
    myHeaders.set('Content-Type', 'application/json');

    this.httpClient.post(this.controllerName + '/update-article-tags'
      , articleTags
      , { headers: myHeaders }
    )
      .subscribe();
  }
}
