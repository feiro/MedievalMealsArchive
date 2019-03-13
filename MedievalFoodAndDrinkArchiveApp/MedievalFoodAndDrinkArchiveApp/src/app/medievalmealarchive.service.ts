import { Injectable } from '@angular/core';
import { Http } from '@angular/http';

import { Category } from "./categories/category";

@Injectable()
export class MedievalMealArchiveService {

    constructor(private http: Http) {

    }

    getCategories(): Promise<Category[]> {
        return this.http.get('api/categories')
            .toPromise()
            .then(r => r.json() as Category[]);
    }
}