import { Component, OnInit, Output } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { PageEvent } from '@angular/material/paginator';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { finalize } from 'rxjs/operators';
import { ImdbClient, MovieDto } from 'src/app/shared/services/ImdbClient';
import { ModelsService } from 'src/app/shared/services/models.service';
import { MovieFormComponent } from './movie-form/movie-form.component';

export interface IMovieTableData {
  name?: string;
  description?: string;
  budget?: number;
  duration?: number;
  releaseDate?: string;
}
@Component({
  selector: 'app-movies',
  templateUrl: './movies.component.html',
  styleUrls: ['./movies.component.scss']
})
export class MoviesComponent implements OnInit {
  loading: boolean = true;
  splicedData: any;
  length?= 500;
  pageSize = 10;
  pageIndex = 0;
  pageSizeOptions = [5, 10, 25];
  showFirstLastButtons = true;
  displayedColumns: string[] = ['name', 'description', 'budget', 'duration', 'releaseDate'];
  dataSource: any[] = [];

  constructor(
    private dialog: MatDialog,
    private route: ActivatedRoute,
    private client: ImdbClient,
    private modelsService: ModelsService) { }


  ngOnInit(): void {
    this.client.getMovies().pipe(
      finalize(() => this.loading = false)
    ).subscribe(response => {
      this.dataSource = response.map(movie => this.transform(movie));
      this.length = Object.values(this.dataSource!).length;
      this.splicedData = Object.values(this.dataSource!).slice(((0 + 1) - 1) * this.pageSize).slice(0, this.pageSize);
      this.displayedColumns = Object.values(this.displayedColumns!)
    });

  }

  handlePageEvent(event: PageEvent) {
    this.length = event.length;
    this.pageSize = event.pageSize;
    this.pageIndex = event.pageIndex;
    const offset = ((event.pageIndex + 1) - 1) * event.pageSize;
    this.splicedData = Object.values(this.dataSource!).slice(offset).slice(0, event.pageSize);
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
    }).afterClosed()
      .subscribe(() => {
        this.ngOnInit();
      });
  }

  transform(movie: MovieDto): IMovieTableData {
    return {
      name: movie.name,
      description: movie.description,
      budget: movie.budget,
      duration: movie.duration,
      releaseDate: movie.releaseDate?.toLocaleDateString()
    } as IMovieTableData
  }
}
