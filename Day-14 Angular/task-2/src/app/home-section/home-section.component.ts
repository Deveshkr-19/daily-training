import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home-section',
  templateUrl: './home-section.component.html',
  styleUrls: ['./home-section.component.css'],
})
export class HomeSectionComponent implements OnInit {
  company = 'Bhavna Corp.';
  about_company =
    'The technology veterans at Bhavna Corp specialize in bringing next-gen solutions geared to solve unique business problems. We re-imagine technology to help our clients realize the full value of their investments in engaging with us.';
  company_url = 'https://www.bhavnacorp.com/';
  constructor() {}

  ngOnInit(): void {}
}
