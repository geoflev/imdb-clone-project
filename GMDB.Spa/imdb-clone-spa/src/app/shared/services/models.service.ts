import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';
import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { ActorDto, CategoryDto, MovieDto, MovieDtoLite } from './ImdbClient';

@Injectable({ providedIn: 'root' })
export class ModelsService {
  private movieSavedSubject = new Subject<MovieDtoLite>();
  public movieSaved$ = this.movieSavedSubject.asObservable();

  private movieDeletedSubject = new Subject<string>();
  public movieDeleted$ = this.movieDeletedSubject.asObservable();

  private categorySavedSubject = new Subject<CategoryDto>();
  public categorySaved$ = this.categorySavedSubject.asObservable();

  private categoryDeletedSubject = new Subject<string>();
  public categoryDeleted$ = this.categoryDeletedSubject.asObservable();

  private actorSavedSubject = new Subject<ActorDto>();
  public actorSaved$ = this.actorSavedSubject.asObservable();

  private actorDeletedSubject = new Subject<string>();
  public actorDeleted$ = this.actorDeletedSubject.asObservable();

  public movieSaved(movie: MovieDtoLite): void {
    this.movieSavedSubject.next(movie);
  }

  public movieDeleted(movieId: string): void {
    this.movieDeletedSubject.next(movieId);
  }

  public categorySaved(category: CategoryDto): void {
    this.categorySavedSubject.next(category);
  }

  public categoryDeleted(categoryId: string): void {
    this.categoryDeletedSubject.next(categoryId);
  }

  public actorSaved(actor: ActorDto): void {
    this.actorSavedSubject.next(actor);
  }

  public actorDeleted(actorId: string): void {
    this.actorDeletedSubject.next(actorId);
  }
}
