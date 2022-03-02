import { THIS_EXPR } from "@angular/compiler/src/output/output_ast";
import { Injectable } from "@angular/core";
import { Subject } from "rxjs";
import { ActorDto, MovieDto } from "./ImdbClient";

@Injectable({providedIn: 'root'})
export class ModelsService {
    private movieSavedSubject = new Subject<MovieDto>();
    public movieSaved$ = this.movieSavedSubject.asObservable();

    private movieDeletedSubject = new Subject<string>();
    public movieDeleted$ = this.movieDeletedSubject.asObservable();

    private actorSavedSubject = new Subject<ActorDto>();
    public actorSaved$ = this.actorSavedSubject.asObservable();

    private actorDeletedSubject = new Subject<string>();
    public actorDeleted$ = this.actorDeletedSubject.asObservable();

    public movieSaved(movie: MovieDto): void {
        this.movieSavedSubject.next(movie);
      }
    
      public movieDeleted(movieId: string): void {
        this.movieDeletedSubject.next(movieId);
      }
}