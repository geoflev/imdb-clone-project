import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ActorsComponent } from './views/admin/actors/actors.component';
import { AdminComponent } from './views/admin/admin.component';
import { CategoriesComponent } from './views/admin/categories/categories.component';
import { DashboardComponent } from './views/admin/dashboard/dashboard.component';
import { MoviesComponent } from './views/admin/movies/movies.component';
import { HomeComponent } from './views/public/home/home.component';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent
  },
  {
    path: 'admin',
    component: AdminComponent,
    children: [
      {
        path: '',
        redirectTo: 'dashboard',
        pathMatch: 'full'
      },
      {
        path: 'dashboard',
        component: DashboardComponent
      },
      {
        path: 'movies',
        component: MoviesComponent
      },
      {
        path: 'categories',
        component: CategoriesComponent
      },
      {
        path: 'actors',
        component: ActorsComponent
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
