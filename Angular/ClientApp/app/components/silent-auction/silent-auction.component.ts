import { Component, Inject } from '@angular/core';
import './silent-auction.component.less';
import { Http } from '@angular/http';
import { AuctionService, Item, NewItem } from '../../services/auction.service';

@Component({
    selector: 'silen-auction',
    templateUrl: './silent-auction.component.html'
})
export class SilentAuctionComponent {
    items: Item[] = [];
    newItemModel: NewItem = { number: "", description: "" };
    
    constructor(http: Http, @Inject('BASE_URL') baseUrl: string, private auctionService: AuctionService) {
        this.auctionService.getSilentItmes().then(response => {
            this.items = response;
        });
    }

    addNewItem() {
        this.auctionService.addNewItem(this.newItemModel)
            .then(result => {
                this.items.push(result);
                this.newItemModel.description = "";
                this.newItemModel.number = "";
            });
    }
}
