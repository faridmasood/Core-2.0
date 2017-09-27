import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
//@CrossOrigin(origins="*")
@Component({
    selector: 'todos',
    templateUrl: './todos.component.html'
})
export class TodosComponent {
    public todos: ToDo[];

    constructor(http: Http) {
        http.get('http://localhost:8080/api/todoservice').subscribe(result => {
            this.todos = result.json() as ToDo[];
        }, error => console.error(error));
    }
}

interface ToDo {
    id: string;
    text: number;
    isComplete: boolean;
    startDate: Date;
    dueDate: Date;
}
