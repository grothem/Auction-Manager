import { Component, Input } from '@angular/core';
import './silent-item.component.less';
import { Item } from '../../../services/auction.service';

@Component({
    selector: 'silent-item',
    templateUrl: './silent-item.component.html'
})
export class SilentItemComponent {
    @Input() item: Item;
    
    constructor() { }
}
