import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AboutComponent } from './about/about.component';
import { AppComponent } from './app.component';
import { ContactComponent } from './contact/contact.component';
import { HomeSectionComponent } from './home-section/home-section.component';

const routes: Routes = [
  {
    path: '',
    component: HomeSectionComponent,
  },
  {
    path: 'about_us',
    component: AboutComponent,
  },
  {
    path: 'contact_us',
    component: ContactComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
