import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { PageEvent } from '@angular/material/paginator';
import { ActivatedRoute } from '@angular/router';
import { finalize } from 'rxjs/operators';
import { ActorDto, ImdbClient } from 'src/app/shared/services/ImdbClient';
import { ActorsFormComponent } from './actors-form/actors-form.component';

export interface IActorTableData {
  firstName?: string;
  lastName?: string;
  birthDate?: Date;
  bio?: string;
  actingScore?: number;
}

@Component({
  selector: 'app-actors',
  templateUrl: './actors.component.html',
  styleUrls: ['./actors.component.scss']
})
export class ActorsComponent implements OnInit {

  loading: boolean = true;
  splicedData: any;
  length?= 500;
  pageSize = 10;
  pageIndex = 0;
  pageSizeOptions = [5, 10, 25];
  showFirstLastButtons = true;
  displayedColumns: string[] = ['firstName', 'lastName', 'birthDate', 'bio', 'actingScore'];
  dataSource: any[] = [];

  constructor(
    private dialog: MatDialog,
    private route: ActivatedRoute,
    private client: ImdbClient
  ) { }

  ngOnInit(): void {
    this.client.getActors().pipe(
      finalize(() => this.loading = false)
      ).subscribe(response => {
        this.dataSource = response.map(movie => this.transform(movie));
        this.length = Object.values(this.dataSource!).length;
        this.splicedData = Object.values(this.dataSource!).slice(((0 + 1) - 1) * this.pageSize).slice(0, this.pageSize);
        this.displayedColumns = Object.values(this.displayedColumns!)
      });
  }

  onCreate(): void {
    this.dialog.open(ActorsFormComponent, {
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

  handlePageEvent(event: PageEvent) {
    this.length = event.length;
    this.pageSize = event.pageSize;
    this.pageIndex = event.pageIndex;
    const offset = ((event.pageIndex + 1) - 1) * event.pageSize;
    this.splicedData = Object.values(this.dataSource!).slice(offset).slice(0, event.pageSize);
  }

   transform(actor: ActorDto): IActorTableData {
    return {
      firstName: actor.firstName,
      lastName: actor.lastName,
      birthDate: actor.birthDate?.toLocaleString(),
      bio: actor.bio,
      actingScore: actor.actingScore,
    } as  IActorTableData
  }

}
