import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { IIdentifiableModel } from 'src/app/shared/models/group.models';

export interface IFeature {
    icon: string;
    title: string;
    description: string;
  }

@Component({
  selector: 'app-features',
  templateUrl: './features.component.html',
  styleUrls: ['./features.component.scss']
})
export class FeaturesComponent<TModel extends IIdentifiableModel> implements OnInit {

    @Output() selected = new EventEmitter<TModel>();
    features: IFeature[] = [
        { icon: 'film', title: 'Movies', description: 'Search movies from a large database' },
        { icon: 'user', title: 'Actors', description: 'Search actors from a large database' },
        { icon: 'camcorder', title: 'Producers', description: 'Search producers from a large database' }
      ];

  constructor() { }

  ngOnInit(): void {
  }

  
  onSelect(item: any): void{
    this.selected.emit(item);
  }


}