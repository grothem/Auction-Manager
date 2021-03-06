﻿import { Component, Inject } from '@angular/core';
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

    deleteItem(item: Item) {
        this.auctionService.deleteItem(item).then(() => {
            var index = this.items.indexOf(item);
            if (index > -1)
                this.items.splice(index, 1);
        });
    }

    saveItem(item: Item) {
        var index = this.items.findIndex((i) => { return i.id === item.id });
        this.auctionService.saveItem(item).then((i) => {
            // var index = this.items.indexOf(item);
            if (index > -1)
                this.items[index] = i;
        });
    }
}
