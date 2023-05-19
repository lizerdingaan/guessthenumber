import { Component } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Inject } from '@angular/core';

@Component({
  selector: 'app-need-help-dialog',
  templateUrl: './need-help-dialog.component.html',
  styleUrls: ['./need-help-dialog.component.css']
})
export class NeedHelpDialogComponent {

  public userDetails: { title?: string, content?: string } = {};

  constructor(@Inject(MAT_DIALOG_DATA) public data: any) {
    this.userDetails = data;
  }

}
