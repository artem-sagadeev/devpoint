import {
  AboutUsComponent,
  CompanyComponent,
  DeveloperComponent,
  HomeComponent,
  LoginComponent,
  PostComponent,
  PricingComponent,
  ProfileComponent,
  ProjectComponent,
  RegisterComponent,
  SearchComponent,
  SubscriptionsComponent,
  WalletComponent,
} from './components';
import { AddPostComponent } from './components/post/add-post/add-post.component';
import { CreateProjectComponent } from './components/projects/create-project/create-project.component';
import { CreateCompanyComponent } from './components/companies/create-company/create-company.component';
import { EditPostComponent } from './components/post/edit-post/edit-post.component';
import { EditCompanyComponent } from './components/companies/edit-company/edit-company.component';
import { EditProjectComponent } from './components/projects/edit-project/edit-project.component';
import { ProfileEditComponent } from './components/account/profile-edit/profile-edit.component';
import { Routes } from '@angular/router';
import { NoAuthGuard } from './guards/no-auth.guard';

export const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'login', component: LoginComponent, canActivate: [NoAuthGuard] },
  {
    path: 'register',
    component: RegisterComponent,
    canActivate: [NoAuthGuard],
  },
  { path: 'about-us', component: AboutUsComponent },
  { path: 'pricing', component: PricingComponent },
  { path: 'search', component: SearchComponent },
  { path: 'developer/:id', component: DeveloperComponent },
  { path: 'project/:id', component: ProjectComponent },
  { path: 'company/:id', component: CompanyComponent },
  { path: 'post/:id', component: PostComponent },
  { path: 'wallet', component: WalletComponent },
  { path: 'profile', component: ProfileComponent },
  { path: 'subscriptions', component: SubscriptionsComponent },
  { path: 'add-post', component: AddPostComponent },
  { path: 'create-project', component: CreateProjectComponent },
  { path: 'create-company', component: CreateCompanyComponent },
  { path: 'profile/edit', component: ProfileEditComponent },
  { path: 'company/:id/edit', component: EditCompanyComponent },
  { path: 'project/:id/edit', component: EditProjectComponent },
  { path: 'post/:id/edit', component: EditPostComponent },
];
