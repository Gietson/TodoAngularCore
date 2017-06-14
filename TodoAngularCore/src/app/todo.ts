export class Todo {
	id: string;
	message: string = '';
	complete: boolean = false;

	constructor(values: Object = {}) {
		Object.assign(this, values);
	}
}
