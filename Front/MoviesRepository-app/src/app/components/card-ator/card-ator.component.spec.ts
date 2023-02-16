import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CardAtorComponent } from './card-ator.component';

describe('CardAtorComponent', () => {
  let component: CardAtorComponent;
  let fixture: ComponentFixture<CardAtorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CardAtorComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CardAtorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
