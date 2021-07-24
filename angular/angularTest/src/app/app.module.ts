import { BrowserModule } from '@angular/platform-browser';
import { NgModule, APP_INITIALIZER } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './components/app.component';

import { FormsModule  } from '@angular/forms';

import { CKEditorModule } from '@ckeditor/ckeditor5-angular';

import { MaterialModule } from './material.module';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatInputModule } from '@angular/material/input';
import { MatNativeDateModule } from '@angular/material/core';
import { MatTabsModule } from '@angular/material/tabs';
import { MatIconModule } from '@angular/material/icon';
import { MatStepperModule } from '@angular/material/stepper';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatTreeModule } from '@angular/material/tree';
import { MatCheckboxModule } from '@angular/material/checkbox';

import { PublisherComponent } from './components/publisher/publisher.component';
import { PublisherStep1Component } from './components/publisher/publisher-step1/publisher-step1.component';
import { PublisherStep2Component } from './components/publisher/publisher-step2/publisher-step2.component';
import { HeaderComponent } from './components/header/header.component';
import { NavComponent } from './components/nav/nav.component';
import { FooterComponent } from './components/footer/footer.component';
import { IntroComponent } from './components/intro/intro.component';
import { BannerComponent } from './components/banner/banner.component';
import { MainComponent } from './components/main/main.component';
import { HighlightNewsComponent } from './components/highlight-news/highlight-news.component';
import { HighlightBlogComponent } from './components/highlight-blog/highlight-blog.component';
import { ArticleBodyComponent } from './components/article/article-body/article-body.component';
import { HomeComponent } from './components/home/home.component';
import { ArticleSidebarComponent } from './components/article/article-sidebar/article-sidebar.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { PublisherStep5Component } from './components/publisher/publisher-step5/publisher-step5.component';
import { ArticleComponent } from './components/article/article.component';
import { ArticleMetadataComponent } from './components/article/article-metadata/article-metadata.component';
import { LanderComponent } from './components/lander/lander.component';
import { DynamicRoutes} from './dynamic-routes';

import { NoSanitizePipe } from './no-sanitize-pipe';
import { PublisherStep6Component } from './components/publisher/publisher-step6/publisher-step6.component';
import { PublisherStep3Component } from './components/publisher/publisher-step3/publisher-step3.component';
import { ArticleAttachmentsComponent } from './components/article/article-attachments/article-attachments.component';

import { AppSettingsService } from './services/app-settings.service';

import { RemoveSlashesAndDashesDirective } from './directives/remove-slashes-and-dashes.directive';

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
    HomeComponent,
    PublisherStep5Component,
    ArticleComponent,
    ArticleSidebarComponent,
    ArticleBodyComponent,
    ArticleMetadataComponent,
    LanderComponent,
    NoSanitizePipe,
    PublisherStep6Component,
    PublisherStep3Component,
    ArticleAttachmentsComponent,
    RemoveSlashesAndDashesDirective
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    CKEditorModule,

    MaterialModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatInputModule,
    MatStepperModule,
    MatTabsModule,
    MatIconModule,
    MatProgressSpinnerModule,
    MatTreeModule,
    MatCheckboxModule,
    //NoSanitizePipe
  ],
  exports: [
    NoSanitizePipe
  ],
  entryComponents: [
    LanderComponent
  ],
  providers: [
    DynamicRoutes
    , {
      provide: APP_INITIALIZER,
      multi: true,
      deps: [AppSettingsService],
      useFactory: (appSettingsService: AppSettingsService) => {
        return () => {
          //Make sure to return a promise!
          return appSettingsService.loadAppConfig();
        };
      }
    }],
  bootstrap: [AppComponent]
})
export class AppModule { }
