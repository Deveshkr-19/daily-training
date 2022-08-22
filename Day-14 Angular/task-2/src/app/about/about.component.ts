import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-about',
  templateUrl: './about.component.html',
  styleUrls: ['./about.component.css'],
})
export class AboutComponent implements OnInit {
  aboutHeadStyles() {
    let aboutHeadCss = {
      color: '#339933',
    };
    return aboutHeadCss;
  }

  aboutImgStyles() {
    let imgStyles = {
      'max-width': '600px',
    };
    return imgStyles;
  }

  constructor() {}

  ngOnInit(): void {}
}
