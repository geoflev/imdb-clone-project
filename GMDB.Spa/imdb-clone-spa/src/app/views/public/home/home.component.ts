import { Component, OnInit } from '@angular/core';

export interface IFeature {
  icon: string;
  title: string;
  description: string;
}

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  features: IFeature[] = [
    { icon: 'cloud-upload', title: 'Movies', description: 'Search movies from a large database' },
    { icon: 'chart-network', title: 'Actors', description: 'Search actors from a large database' },
    { icon: 'chart-network', title: 'Producers', description: 'Search producers from a large database' },
    
  ];

  constructor() { }

  ngOnInit(): void {
  }

}
