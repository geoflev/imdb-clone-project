import { Component, OnInit, Output } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { MovieFormComponent } from './movie-form/movie-form.component';

export interface PeriodicElement {
  name: string;
  position: number;
  weight: number;
  symbol: string;
}

const ELEMENT_DATA: PeriodicElement[] = [
  { position: 1, name: 'Hydrogen', weight: 1.0079, symbol: 'H' },
  { position: 2, name: 'Helium', weight: 4.0026, symbol: 'He' },
  { position: 3, name: 'Lithium', weight: 6.941, symbol: 'Li' },
  { position: 4, name: 'Beryllium', weight: 9.0122, symbol: 'Be' },
  { position: 5, name: 'Boron', weight: 10.811, symbol: 'B' },
  { position: 6, name: 'Carbon', weight: 12.0107, symbol: 'C' },
  { position: 7, name: 'Nitrogen', weight: 14.0067, symbol: 'N' },
  { position: 8, name: 'Oxygen', weight: 15.9994, symbol: 'O' },
  { position: 9, name: 'Fluorine', weight: 18.9984, symbol: 'F' },
  { position: 10, name: 'Neon', weight: 20.1797, symbol: 'Ne' },
  { position: 11, name: 'Neon2', weight: 20.1797, symbol: 'Ne' },
  { position: 12, name: 'Neon3', weight: 20.1797, symbol: 'Ne' },
];
@Component({
  selector: 'app-movies',
  templateUrl: './movies.component.html',
  styleUrls: ['./movies.component.scss']
})
export class MoviesComponent implements OnInit {

  @Output() displayedColumns: string[] = ['position', 'name', 'weight', 'symbol'];
  @Output() dataSource = ELEMENT_DATA;

  constructor(
    private dialog: MatDialog,
    private route: ActivatedRoute,) {

  }
  ngOnInit(): void {

  }

  onCreate(): void {
    this.dialog.open(MovieFormComponent, {
      width: '550px',
      disableClose: true,
      hasBackdrop: true,
      data: {
        movie: undefined,
        route: this.route
      }
    });
  }
}
