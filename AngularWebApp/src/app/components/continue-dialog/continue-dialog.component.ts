import { Component } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Inject } from '@angular/core';


@Component({
  selector: 'app-continue-dialog',
  templateUrl: './continue-dialog.component.html',
  styleUrls: ['./continue-dialog.component.css']
})
export class ContinueDialogComponent {

  public userDetails: { title?: string, content?: string } = {};

  constructor(@Inject(MAT_DIALOG_DATA) public data: any) {
    this.userDetails = data;
  }

}
