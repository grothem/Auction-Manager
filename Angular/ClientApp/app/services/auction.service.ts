import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';

import 'rxjs/add/operator/toPromise';

@Injectable()
export class AuctionService {
   
    constructor(private http: Http) { }

    getItems(): Promise<Item[]> {
        return this.http.get('api/Item/GetItems')
            .toPromise()
            .then(response => response.json() as Item[])
            .catch(this.handleError);
    }

    getLiveItems(): Promise<Item[]> {
        return this.http.get('api/Item/GetLiveItems')
            .toPromise()
            .then(response => response.json() as Item[])
            .catch(this.handleError);
    }

    getSilentItmes(): Promise<Item[]> {
        return this.http.get('api/Item/GetSilentItems')
            .toPromise()
            .then(response => response.json() as Item[])
            .catch(this.handleError);
    }

    addNewItem(item: NewItem): Promise<Item> {
        return this.http.post('api/Item/AddSilentItem', item)
            .toPromise()
            .then(response => response.json() as Item)
            .catch()
    }

    private handleError(error: any): Promise<any> {
        console.error('An error occurred', error); // for demo purposes only
        return Promise.reject(error.message || error);
    }
}

export interface NewItem {
    number: string;
    description: string;
}

export interface Item {
    id: number;
    number: string;
    description: string;
    type: string;
    winningBid: WinningBid;
}

export interface WinningBid {
    id: number;
    bidderId: number;
    price: number;
    paid: boolean;
    item: Item;
    bidder: Bidder;
}

export interface Bidder {
    id: number;
    winningBids: WinningBid[];
}
