import { Component } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Inject } from '@angular/core';

@Component({
  selector: 'app-detail-dialog',
  templateUrl: './detail-dialog.component.html',
  styleUrls: ['./detail-dialog.component.css']
})
export class DetailDialogComponent {

  public userDetails: { title?: string, content?: string } = {};

  constructor(@Inject(MAT_DIALOG_DATA) public data: any) {
    this.userDetails = data;
  }
}
