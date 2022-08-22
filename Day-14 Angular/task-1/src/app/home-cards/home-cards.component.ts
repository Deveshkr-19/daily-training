import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home-cards',
  templateUrl: './home-cards.component.html',
  styleUrls: ['./home-cards.component.css']
})
export class HomeCardsComponent implements OnInit {
  mission = "We are dedicated to creating differentiators for our clients' businesses through innovative use of talent that help bring best products to market in less time and at reduced cost.";
  vision = "To become THE trusted partner of our clients through a world-class team of developers, technologists, and QA personnel where people can define the company and are our most important asset.";
  values = "These three pillars guide our behavior and attitude, ensuring that we focus on customer delight, team collaboration, growth and deliver innovative solutions with quality."

  constructor() { }

  ngOnInit(): void {
  }

}
