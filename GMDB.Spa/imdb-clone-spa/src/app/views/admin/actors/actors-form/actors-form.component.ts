import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { finalize } from 'rxjs/operators';
import { ActorDto, ActorForm, Gender, ImdbClient } from 'src/app/shared/services/ImdbClient';
import { ModelsService } from 'src/app/shared/services/models.service';

export interface IMovieDialogData {
  actor: ActorDto;
  route: ActivatedRoute
}
//Genders from form doesnt work
//always returns male
//find a way to bind
@Component({
  selector: 'app-actors-form',
  templateUrl: './actors-form.component.html',
  styleUrls: ['./actors-form.component.scss']
})
export class ActorsFormComponent implements OnInit {
  new: boolean = true;
  loading: boolean = false;
  form: ActorForm;

  constructor(
    private client: ImdbClient,
    private modelsService: ModelsService,
    private dialogRef: MatDialogRef<ActorsFormComponent>,
    @Inject(MAT_DIALOG_DATA) public data: IMovieDialogData
  ) { 
    this.form = !this.data.actor
    ? new ActorForm()
    : new ActorForm();
  }

  ngOnInit(): void {
  }

  onCreate(): void {  
    this.loading = true;
    this.client.createActor(this.form).pipe(
      finalize(() => this.loading = false)
    ).subscribe(response => this.saved(response));
  }

  saved(actor: ActorDto): void {
    this.modelsService.actorSaved(actor);
    this.onClose(true);
  }

  onClose(saved?: boolean): void {
    this.dialogRef.close();
  }
}



