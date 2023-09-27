import { Directive, ElementRef } from '@angular/core';

@Directive({
  selector: 'button[appPrimaryButton]',
  standalone: true
})
export class PrimaryButtonDirective {

  constructor(el: ElementRef<HTMLButtonElement>) {

    el.nativeElement.classList.add('btn', 'btn-primary');
  }

}

@Directive({
  selector: 'button[appSecondaryButton]',
  standalone: true
})
export class SecondaryButtonDirective {

  constructor(el: ElementRef<HTMLButtonElement>) {

    el.nativeElement.classList.add('btn', 'btn-secondary');
  }

}

