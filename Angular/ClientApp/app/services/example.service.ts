import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';

import 'rxjs/add/operator/toPromise';

@Injectable()
export class ExampleService {

    private exampleUrl = 'api/SampleData/WeatherForecasts';  // URL to web api

    constructor(private http: Http) { }

    getData(): Promise<WeatherForecast[]> {
        return this.http.get(this.exampleUrl)
            .toPromise()
            .then(response => response.json() as WeatherForecast[])
            .catch(this.handleError);
    }

    private handleError(error: any): Promise<any> {
        console.error('An error occurred', error); // for demo purposes only
        return Promise.reject(error.message || error);
    }
}

interface WeatherForecast {
    dateFormatted: string;
    temperatureC: number;
    temperatureF: number;
    summary: string;
}
