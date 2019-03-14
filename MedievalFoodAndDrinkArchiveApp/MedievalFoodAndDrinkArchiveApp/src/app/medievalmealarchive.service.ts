import { Injectable } from '@angular/core'
import { HttpClient } from '@angular/common/http'
import { Subject} from 'rxjs'

@Injectable()
export class ApiService {

    private selectedDish = new Subject<any>();
    dishSelected = this.selectedDish.asObservable();

    constructor(private http: HttpClient) {}  

    getDishes(){
        return this.http.get('https://localhost:44361/api/dishes');
    }

    selectDish(dish) {
        this.selectedDish.next(dish)
    }
}