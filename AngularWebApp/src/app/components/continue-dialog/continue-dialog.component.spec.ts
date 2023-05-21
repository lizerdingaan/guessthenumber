import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ContinueDialogComponent } from './continue-dialog.component';

describe('ContinueDialogComponent', () => {
  let component: ContinueDialogComponent;
  let fixture: ComponentFixture<ContinueDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ContinueDialogComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ContinueDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
