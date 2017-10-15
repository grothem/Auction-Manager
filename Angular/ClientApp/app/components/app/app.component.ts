import { Component } from '@angular/core';
import { ExampleService } from "../../services/example.service";

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css'],
    providers: [ExampleService]
})
export class AppComponent {
    //constructor(private exampleService: ExampleService) { }
}
