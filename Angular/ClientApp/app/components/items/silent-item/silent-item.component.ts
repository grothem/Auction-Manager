import { Component, Input, Output, EventEmitter } from '@angular/core';
import './silent-item.component.less';
import { Item, AuctionService } from '../../../services/auction.service';
import { OnInit } from '@angular/core/src/metadata/lifecycle_hooks';

@Component({
    selector: 'silent-item',
    templateUrl: './silent-item.component.html'
})
export class SilentItemComponent implements OnInit {
    @Input() item: Item;
    @Output() deleteItem = new EventEmitter<Item>();
    @Output() saveItem = new EventEmitter<Item>();

    itemCopy: Item;
    editing: boolean = false;
    
    constructor(private auctionService: AuctionService) {}

    ngOnInit() {
        this.itemCopy = {
            id: this.item.id,
            number: this.item.number,
            description: this.item.description,
            type: this.item.type,
            winningBid: this.item.winningBid
        } as Item;
    }

    delete() {
        this.deleteItem.emit(this.item);
    }

    edit() {
        this.editing = true;
        Object.assign(this.itemCopy, this.item);
    }

    cancel() {
        this.editing = false;
        this.itemCopy = {id: 0, number: '', description: '', type: ''} as Item;
    }

    save() {
        Object.assign(this.item, this.itemCopy);
        this.saveItem.emit(this.itemCopy);
        this.editing = false
    }
}
