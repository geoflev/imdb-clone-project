import { Component, Input, OnInit } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.scss']
})
export class TableComponent implements OnInit {
  splicedData: any;
  length?= 500;
  pageSize = 10;
  pageIndex = 0;
  pageSizeOptions = [5, 10, 25];
  showFirstLastButtons = true;
  @Input() dataSource: any[] = [];
  @Input() displayedColumns: string[] = [];

  constructor() { }

  ngOnInit(): void {
    this.length = Object.values(this.dataSource!).length;
    this.splicedData = Object.values(this.dataSource!).slice(((0 + 1) - 1) * this.pageSize).slice(0, this.pageSize);
    this.displayedColumns = Object.values(this.displayedColumns!)
  }

  handlePageEvent(event: PageEvent) {
    this.length = event.length;
    this.pageSize = event.pageSize;
    this.pageIndex = event.pageIndex;
    const offset = ((event.pageIndex + 1) - 1) * event.pageSize;
    this.splicedData = Object.values(this.dataSource!).slice(offset).slice(0, event.pageSize);
  }
}
