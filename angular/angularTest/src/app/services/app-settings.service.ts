import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';


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
    return this.httpClient.get('/assets/app-settings.json')
      .toPromise()
      .then(data => {
        this.baseUrl = data["BaseUrl"];
        this.apiUrl = data["APIUrl"];
        this.exportFileLocation = data["ExportFileLocation"];
        this.archiveFileLocation = data["ArchiveFileLocation"];
        this.downloadLocation = data["DownloadLocation"];
      });
  }
}
