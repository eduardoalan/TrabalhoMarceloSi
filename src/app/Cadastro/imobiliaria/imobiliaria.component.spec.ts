/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { ImobiliariaComponent } from './imobiliaria.component';

describe('ImobiliariaComponent', () => {
  let component: ImobiliariaComponent;
  let fixture: ComponentFixture<ImobiliariaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ImobiliariaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ImobiliariaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
