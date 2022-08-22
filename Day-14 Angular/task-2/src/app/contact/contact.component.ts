import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css'],
})
export class ContactComponent implements OnInit {
  isNoida: boolean = true;
  changeData(noida: boolean) {
    this.isNoida = noida;
  }

  contactCard() {
    let cardCss = {
      background: 'rgba(0,0,0,0.3)',
    };
    return cardCss;
  }

  constructor() {}

  ngOnInit(): void {}
}
