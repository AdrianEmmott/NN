import { SafeHtml } from '@angular/platform-browser';

export class Article {
    id: string;
    title: string;
    headerImage: string;
    subtitle: string;
    summary: string;
    viewCount: number;
    content: string;
    author: string;
    publishDate: Date;
    attachments: Array<string> = new Array<string>();

    tags: Array<TagModel>;
  }

export class ArticleSummary {
    id: number;
    title: string;
    headerImage: string;
    summary: string;
    viewCount: number;
    author: string;
    publishDate: Date;
    formattedPublishDate: string;
    path: string;
  }

export class TagModel {
    id: string;
    title: string;
    showInNav: boolean;
    sortOrder: number;
    path: string;
    tags?: Array<TagModel>;
    expandable: boolean;
    selected: boolean;
    level: number;
  }

export class ArticleTagModel {
  articleId: string;
  tagId: string;
  //tagIds: Array<string>;
  //tags: Array<TagModel>;
}
