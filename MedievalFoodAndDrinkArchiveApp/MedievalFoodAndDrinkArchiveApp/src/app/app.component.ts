import { NgModule, Component, Injectable, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClientModule, HttpClient } from "@angular/common/http";
import { BrowserModule } from "@angular/platform-browser";

@Injectable()
class SearchService {
    apiRoot: string = 'https://itunes.apple.com/search';
    results: Object[];
    loading: boolean;

    constructor(private http: HttpClient) {
        
        this.results = [];
        this.loading = false;
    }

    search(term: string) {
        let promise = new Promise((resolve, reject) => {
            let apiURL = `${this.apiRoot}?term=${term}&media=music&limit=20`;
            this.http.get(apiURL)
                .toPromise()
                .then(
                    res => { // Success
                        console.log(res.toString);
                        resolve();
                    }
                );
        });
        return promise;
    }
}

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css'],
    /* template: `
<app-header></app-header>
<p></p><p></p>
<form class="form-inline">
  <div class="form-group">
    <input type="search"
           class="form-control"
           placeholder="Enter search string"
           #search> (1)
  </div>
  <button class="btn btn-primary"
          (click)="doSearch(search.value)"> (2)
          Search
  </button>
</form>
 ` */
})

@NgModule({
    imports: [BrowserModule, HttpClientModule],
    declarations: [AppComponent],
    bootstrap: [AppComponent],
    providers: [SearchService]
})

export class AppComponent {
    //constructor(private itunes: SearchService) { }

    //doSearch(term: string) {
    //    this.itunes.search(term)
    //}
}
