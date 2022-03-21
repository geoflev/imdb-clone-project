import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { finalize } from 'rxjs/operators';
import { CategoryDto, CategoryForm, ImdbClient } from 'src/app/shared/services/ImdbClient';
import { ModelsService } from 'src/app/shared/services/models.service';

export interface ICategoryDialogData {
  categoryId: string;
  category: CategoryDto;
  route: ActivatedRoute
}

@Component({
  selector: 'app-category-form',
  templateUrl: './category-form.component.html',
  styleUrls: ['./category-form.component.scss']
})
export class CategoryFormComponent implements OnInit {

  new: boolean = true;
  loading: boolean = false;
  form: CategoryForm = new CategoryForm();

  constructor(
    private client: ImdbClient,
    private modelsService: ModelsService,
    private dialogRef: MatDialogRef<CategoryFormComponent>,
    @Inject(MAT_DIALOG_DATA) public data: ICategoryDialogData
  ) {
  
   }

  ngOnInit(): void {
  }

  onCreate(): void {
    this.loading = true;
    this.client.createCategory(this.form).pipe(
      finalize(() => this.loading = false)
    ).subscribe(response => this.saved(response));
  }

  saved(category: CategoryDto): void {
    this.modelsService.categorySaved(category);
    this.onClose(true);
  }

  onClose(saved?: boolean): void {
    this.dialogRef.close();
  }

}
