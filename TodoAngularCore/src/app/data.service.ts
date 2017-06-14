import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Headers, RequestOptions } from '@angular/http';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';

import { Todo } from './todo';

@Injectable()
export class DataService {
	private url = '/api/todo/'; // Url to web api
	public options: RequestOptions;

	constructor(private http: Http) {
		let headers = new Headers({ 'Content-Type': 'application/json' });
		this.options = new RequestOptions({ headers: headers });
	}

	getAll(): Observable<Todo[]> {
		console.log('getall');
		return this.http.get(this.url)
			.map(this.extractData)
			.catch(this.handleError);
	}

	delete(id: string): Observable<Response> {
		return this.http
			.delete(this.url + id)
			.map(this.extractData)
			.catch(this.handleError);
	}

	create(todo: Todo) {
		return this.http
			.post(this.url, JSON.stringify(todo), this.options)
			.map(this.extractData)
			.catch(this.handleError);
	}

	private extractData(res: Response) {
		console.log(res);
		let body = res.json();
		return body || {};
	}

	private handleError(error: Response | any) {
		// In a real world app, you might use a remote logging infrastructure
		let errMsg: string;
		if (error instanceof Response) {
			const body = error.json() || '';
			const err = body.error || JSON.stringify(body);
			errMsg = `${error.status} - ${error.statusText || ''} ${err}`;
		} else {
			errMsg = error.message ? error.message : error.toString();
		}
		console.error(errMsg);
		return Observable.throw(errMsg);
	}
}

