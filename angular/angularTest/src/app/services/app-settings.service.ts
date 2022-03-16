import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AppSettingsService {
  public baseUrl: string;
  public apiUrl: string;
  public exportFileLocation: string;
  public archiveFileLocation: string;
  public downloadLocation: string;

  constructor(public httpClient: HttpClient) {
  }

  loadAppConfig() {
    var test = this.httpClient.get('/assets/app-settings.json').pipe(
      tap((data) => {
        this.baseUrl = data["BaseUrl"];
        this.apiUrl = data["APIUrl"];
        this.downloadLocation = data["DownloadLocation"];
      })
    );

    return test;
  }
}
