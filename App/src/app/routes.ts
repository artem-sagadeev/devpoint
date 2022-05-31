import { HomeComponent } from './components/main/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { AboutUsComponent } from './components/main/about-us/about-us.component';
import { PricingComponent } from './components/main/pricing/pricing.component';
import { SearchComponent } from './components/search/search.component';
import { DeveloperComponent } from './components/developers/developer/developer.component';
import { WalletComponent } from './components/account/wallet/wallet.component';
import { ProfileComponent } from './components/account/profile/profile.component';
import { SubscriptionsComponent } from './components/account/subscriptions/subscriptions.component';
import { SettingsComponent } from './components/account/settings/settings.component';

export const routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'about-us', component: AboutUsComponent },
  { path: 'pricing', component: PricingComponent },
  { path: 'search', component: SearchComponent },
  { path: 'developer/:id', component: DeveloperComponent },
  { path: 'project/:id', component: DeveloperComponent },
  { path: 'company/:id', component: DeveloperComponent },
  { path: 'wallet', component: WalletComponent },
  { path: 'profile', component: ProfileComponent },
  { path: 'subscriptions', component: SubscriptionsComponent },
  { path: 'settings', component: SettingsComponent },
];
