import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { PageEvent } from '@angular/material/paginator';
import { ActivatedRoute } from '@angular/router';
import { finalize } from 'rxjs/operators';
import { CategoryDto, ImdbClient } from 'src/app/shared/services/ImdbClient';
import { CategoryFormComponent } from './category-form/category-form.component';

export interface ICategoryData {
 name: string;   
}

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.scss']
})
export class CategoriesComponent implements OnInit {

  loading: boolean = true;
  splicedData: any;
  length? = 500;
  pageSize = 10;
  pageIndex = 0;
  pageSizeOptions = [5, 10, 25];
  showFirstLastButtons = true;
  displayColumns: string[] = ['name'];
  dataSource: any[] = [];

  constructor(
    private dialog: MatDialog,
    private route: ActivatedRoute,
    private client: ImdbClient
  ) { }

  ngOnInit(): void {
    this.client.getCategories().pipe(
      finalize(() => this.loading = false)
    ).subscribe(response => {
      this.dataSource = response.map(category => this.transform(category));
      this.length = Object.values(this.dataSource!).length;
      this.splicedData = Object.values(this.dataSource!).slice(((0 + 1) - 1) * this.pageSize).slice(0, this.pageSize);
      this.displayColumns = Object.values(this.displayColumns);
    })
  }
  
  handlePageEvent(event: PageEvent) {
    this.length = event.length;
    this.pageSize = event.pageSize;
    this.pageIndex = event.pageIndex;
    const offset = ((event.pageIndex + 1) - 1) * event.pageSize;
    this.splicedData = Object.values(this.dataSource!).slice(offset).slice(0, event.pageSize);
  }

  onCreate(): void {
    this.dialog.open(CategoryFormComponent, {
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

  transform(category: CategoryDto): ICategoryData {
    return {
      name: category.name
    } as ICategoryData
  }

}
