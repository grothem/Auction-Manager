import { Component } from '@angular/core';
import { AuctionService } from "../../services/auction.service";
import './app.component.less';

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    providers: [AuctionService]
})
export class AppComponent {
}
