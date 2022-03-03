import { Component, Inject, OnInit } from '@angular/core';
import { MatChipInputEvent } from '@angular/material/chips';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { finalize } from 'rxjs/operators';
import { COMMA, ENTER } from '@angular/cdk/keycodes';
import { ImdbClient, MovieDto, MovieForm } from 'src/app/shared/services/ImdbClient';
import { ModelsService } from 'src/app/shared/services/models.service';

export interface IMovieDialogData {
  movieId: string;
  movie: MovieDto;
  route: ActivatedRoute
}

@Component({
  selector: 'app-movie-form',
  templateUrl: './movie-form.component.html',
  styleUrls: ['./movie-form.component.scss']
})
export class MovieFormComponent implements OnInit {
  new: boolean = true;
  loading: boolean = false;
  form: MovieForm;
  categories: any[] = [];
  actors: any[] = [];
  producers: any[] =[];

  readonly separatorKeysCodes = [ENTER, COMMA] as const;

  constructor(
    private client: ImdbClient,
    private modelsService: ModelsService,
    private dialogRef: MatDialogRef<MovieFormComponent>,
    @Inject(MAT_DIALOG_DATA) public data: IMovieDialogData
  ) { 
    this.form = !this.data.movie
      ? new MovieForm({
          tags: [],
        })
      : new MovieForm(this.data.movie);
    if (!this.form.tags) {
      this.form.tags = [];
    } 
  }

  ngOnInit(): void {
    this.client.getCategories().subscribe((response) => {
      this.categories = response;
    });
    this.client.getActors().subscribe((response) => {
      this.actors = response;
    });
    this.client.getProducers().subscribe((response) => {
      this.producers = response;
    });
  }

  onCreate(): void {
    this.loading = true;
    this.client.createMovie(this.form).pipe(
      finalize(() => this.loading = false)
    ).subscribe(response => this.saved(response));
  }

  onUpdate(): void {
    this.loading = true;
    this.client.updateMovie(this.data.movieId, this.form).pipe(
      finalize(() => this.loading = false)
    ).subscribe(response => this.saved(response));
  }

  saved(movie: MovieDto): void {
    this.modelsService.movieSaved(movie);
    this.onClose(true);
  }

  onClose(saved?: boolean): void {
    this.dialogRef.close();
  }

  isTagRemovable(tag: string): boolean {
    return !this.data ;
  }

  onAddTag(event: MatChipInputEvent): void {
    const value = (event.value || '').trim();
    if (value) {
      this.form.tags!.push(value);
    }
    event.chipInput!.clear();
  }

  onRemoveTag(tag: string): void {
    this.form.tags?.splice(this.form.tags.indexOf(tag), 1);
  }
}
