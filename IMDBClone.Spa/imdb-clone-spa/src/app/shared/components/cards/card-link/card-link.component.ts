import { Component, EventEmitter, Input, OnInit, Output, TemplateRef } from '@angular/core';
import { IIdentifiableModel } from 'src/app/shared/models/group.models';

export interface Test<TModel> {
  item: TModel;
}

@Component({
  selector: 'app-card-link',
  templateUrl: './card-link.component.html',
  styleUrls: ['./card-link.component.scss']
})
export class CardLinkComponent<TModel extends IIdentifiableModel> implements OnInit {
  @Input() item!: TModel;
  @Input() content?: TemplateRef<any>;
  @Output() selected = new EventEmitter<TModel>();
  constructor() { }

  ngOnInit(): void {
  }

  get context(): Test<TModel> {
    return { item: this.item }
  }

  onSelect(): void{
    this.selected.emit(this.item);
  }
}
