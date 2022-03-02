import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { IIdentifiableModel } from 'src/app/shared/models/group.models';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.scss']
})
export class FormComponent<TForm extends IIdentifiableModel>  implements OnInit {
  @Input() header!: string;
  @Input() new: boolean = true;
  @Input() loading: boolean = false;
  @Input() form!: TForm;
  @Input() formValid!: boolean | null;
  
  @Output() cancel = new EventEmitter();
  @Output() create = new EventEmitter();
  @Output() update = new EventEmitter();
  constructor() { }

  ngOnInit(): void {
  }
  
  onCancel(): void {
    this.cancel.emit();
  }

  onSave(): void {
    this.new ? this.create.emit() : this.update.emit();
  }
}
