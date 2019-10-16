import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { FormsModule  } from '@angular/forms';

import { MaterialModule } from './material.module';
import { MatDatepickerModule, MatInputModule, MatNativeDateModule } from '@angular/material';
import { MatTabsModule } from '@angular/material/tabs';
import { MatIconModule } from '@angular/material/icon';
import { MatStepperModule } from '@angular/material/stepper';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatTreeModule } from '@angular/material/tree';
import { MatCheckboxModule } from '@angular/material/checkbox';

import { CKEditorModule } from '@ckeditor/ckeditor5-angular';

import { PublisherComponent } from './publisher/publisher.component';
import { PublisherStep1Component } from './publisher/publisher-step1/publisher-step1.component';
import { PublisherStep2Component } from './publisher/publisher-step2/publisher-step2.component';
import { HeaderComponent } from './header/header.component';
import { NavComponent } from './nav/nav.component';
import { FooterComponent } from './footer/footer.component';
import { IntroComponent } from './intro/intro.component';
import { BannerComponent } from './banner/banner.component';
import { MainComponent } from './main/main.component';
import { HighlightNewsComponent } from './highlight-news/highlight-news.component';
import { HighlightBlogComponent } from './highlight-blog/highlight-blog.component';
import { MessagePageComponent } from './message-page/message-page.component';
import { HomeComponent } from './home/home.component';
import { MessagePageArticleRightComponent } from './message-page-article-right/message-page-article-right.component';
import { MessagePageArticleLeftComponent } from './message-page-article-left/message-page-article-left.component';
import { MessagePageSidebarLeftComponent } from './message-page-sidebar-left/message-page-sidebar-left.component';
import { MessagePageSidebarRightComponent } from './message-page-sidebar-right/message-page-sidebar-right.component';
import { MessagePageArticleComponent } from './message-page-article/message-page-article.component';
import { ArticleSidebarComponent } from './article-sidebar/article-sidebar.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { PublisherStep5Component } from './publisher/publisher-step5/publisher-step5.component';


// import { MatMomentDateModule } from '@angular/material-moment-adapter';


@NgModule({
  declarations: [
    AppComponent,
    PublisherComponent,
    PublisherStep1Component,
    PublisherStep2Component,
    HeaderComponent,
    NavComponent,
    FooterComponent,
    IntroComponent,
    BannerComponent,
    MainComponent,
    HighlightNewsComponent,
    HighlightBlogComponent,
    MessagePageComponent,
    HomeComponent,
    MessagePageArticleRightComponent,
    MessagePageArticleLeftComponent,
    MessagePageSidebarLeftComponent,
    MessagePageSidebarRightComponent,
    MessagePageArticleComponent,
    ArticleSidebarComponent,
    PublisherStep5Component
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    CKEditorModule,

    MaterialModule,
    MatDatepickerModule, MatInputModule, MatNativeDateModule,
    MatStepperModule,
    MatTabsModule,
    MatIconModule,
    MatProgressSpinnerModule,
    MatTreeModule,
    MatCheckboxModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
