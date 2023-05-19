import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NeedHelpDialogComponent } from './need-help-dialog.component';

describe('NeedHelpDialogComponent', () => {
  let component: NeedHelpDialogComponent;
  let fixture: ComponentFixture<NeedHelpDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NeedHelpDialogComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NeedHelpDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
