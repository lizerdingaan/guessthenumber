import { Component, EventEmitter, Input, Output } from '@angular/core';
import { SetDisabledStateOption } from '@angular/forms';

@Component({
  selector: 'app-button',
  templateUrl: './button.component.html',
  styleUrls: ['./button.component.css']
})
export class ButtonComponent {
  @Input() text!: string;
  @Input() color!: string;
  @Input() isButtonDisabled: boolean = false;

}
