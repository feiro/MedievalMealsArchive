import { Dish } from '../dishes/dish';

export class Category {
    id: number;
    name: string;
    description: string;
    dishes: Dish[];
}