import { Component, OnInit } from '@angular/core';

import { DataService } from './data.service';

import { Todo } from './todo';

@Component({
	selector: 'app-root',
	templateUrl: './app.component.html',
	providers: [DataService],
	styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

	constructor(private dataService: DataService) { }

	newTodo: Todo = new Todo();


	errorMessage: string;
	Todos: Todo[] = [];
	mode = 'Observable';
	ngOnInit() {
		this.getData();
        /*this._httpService.get('/api/values').subscribe(values => {
            this.apiValues = values.json() as string[];
        });*/
	}

	getData() {
		//console.log('jestem tu');
		this.dataService.getAll()
			.subscribe(
			result => this.Todos = result,
			error => this.errorMessage = <any>error);
	}
	removeTodo(todo) {
		//console.log(todo);

		this.dataService.delete(todo.id)
			.subscribe(
			result => this.getData(),
			error => this.errorMessage = <any>error);

		//this.getData()
	}

	addTodo() {
		console.log(this.newTodo);
		this.dataService.create(this.newTodo).subscribe(
			result => this.getData(),
			error => this.errorMessage = <any>error);

		this.newTodo = new Todo();
	}

	updateTodo(todo) {
		console.log('zmieniam todo = ' + JSON.stringify(todo));
		this.dataService.update(todo);
		todo.complete = !todo.complete;

	}
}
