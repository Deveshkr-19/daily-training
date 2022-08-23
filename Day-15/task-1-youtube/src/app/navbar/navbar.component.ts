import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css'],
})
export class NavbarComponent implements OnInit {
  sidebar: any[] = [
    { Icon: 'bi bi-house-door-fill', Title: 'Home' },
    { Icon: 'bi bi-compass', Title: 'Explore' },
    { Icon: 'bi bi-file-play', Title: 'Shorts' },
    { Icon: 'bi bi-collection-play', Title: 'Subscriptions' },
    { Icon: 'bi bi-play-circle', Title: 'YouTube Music' },
    { Icon: 'bi bi-youtube', Title: 'Library' },
  ];
  constructor() {}

  ngOnInit(): void {}
}
