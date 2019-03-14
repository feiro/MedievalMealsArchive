import { Component } from '@angular/core'
import { ApiService } from './medievalmealarchive.service'

@Component({
    selector: 'dishes',
    templateUrl: './dishes.component.html'
})
export class DishesComponent {

    dish = {}
    dishes
    
    constructor(private api: ApiService) {}

    ngOnInit() {
        this.api.getDishes().subscribe(res => {
            this.dishes = res
        })
    }
}