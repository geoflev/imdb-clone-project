import { Component, EventEmitter, Input, OnInit, Output, TemplateRef } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ImdbClient, MovieDto } from 'src/app/shared/services/ImdbClient';
import { ModelsService } from 'src/app/shared/services/models.service';
import { finalize } from 'rxjs/operators';
import { Subscription } from 'rxjs';
import { IIdentifiableModel } from 'src/app/shared/models/group.models';

@Component({
  selector: 'app-movies',
  templateUrl: './movies.component.html',
  styleUrls: ['./movies.component.scss']
})
export class MoviesComponent<TModel extends IIdentifiableModel> implements OnInit {

  movies: MovieDto[] = [];
  moviesFiltered: MovieDto[] = [];
  loading: boolean = true;
  @Input() items: TModel[] = [];
  @Input() content?: TemplateRef<any>;
  @Output() selected = new EventEmitter<TModel>();

  constructor(
    private client: ImdbClient,
    private modelsService: ModelsService,
    private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit(): void {

    this.client.getMovies().pipe(
      finalize(() => this.loading = false)
    ).subscribe(response => {
      this.movies = response;
      this.onMoviesChanged();
      console.log(this.items)
    })
  }

  onMoviesChanged(): void {
    this.movies = this.movies.sort((a, b) => a.name!.toLowerCase() <= b.name!.toLowerCase() ? -1 : 1);
  }

  onSelect(item: any): void{
    this.selected.emit(item);
  }

}
