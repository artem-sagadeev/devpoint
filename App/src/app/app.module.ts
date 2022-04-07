import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './components/shared/header/header.component';
import { HomeComponent } from './components/main/home/home.component';
import { FooterComponent } from './components/shared/footer/footer.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { AboutUsComponent } from './components/main/about-us/about-us.component';
import { PricingComponent } from './components/main/pricing/pricing.component';
import { Service } from './services/shared.service';
import { HttpClientModule } from '@angular/common/http';
import { DeveloperPreviewComponent } from './components/developers/developer-preview/developer-preview.component';
import { DeveloperComponent } from './components/developers/developer/developer.component';
import { SearchComponent } from './components/search/search.component';
import { ProjectComponent } from './components/projects/project/project.component';
import { ProjectPreviewComponent } from './components/projects/project-preview/project-preview.component';
import { CompanyComponent } from './components/companies/company/company.component';
import { CompanyPreviewComponent } from './components/companies/company-preview/company-preview.component';
import { ProfileComponent } from './components/account/profile/profile.component';
import { WalletComponent } from './components/account/wallet/wallet.component';
import { SettingsComponent } from './components/account/settings/settings.component';
import { SubscriptionsComponent } from './components/account/subscriptions/subscriptions.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    HomeComponent,
    FooterComponent,
    LoginComponent,
    RegisterComponent,
    AboutUsComponent,
    PricingComponent,
    DeveloperPreviewComponent,
    DeveloperComponent,
    DeveloperPreviewComponent,
    SearchComponent,
    ProjectComponent,
    ProjectPreviewComponent,
    CompanyComponent,
    CompanyPreviewComponent,
    ProfileComponent,
    WalletComponent,
    SettingsComponent,
    SubscriptionsComponent
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    AppRoutingModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'login', component: LoginComponent },
      { path: 'register', component: RegisterComponent },
      { path: 'about-us', component: AboutUsComponent },
      { path: 'pricing', component: PricingComponent },
      { path: 'search', component: SearchComponent },
      { path: 'developer/:id', component: DeveloperComponent},
      { path: 'project/:id', component: DeveloperComponent},
      { path: 'company/:id', component: DeveloperComponent},
      { path: 'wallet', component: WalletComponent }
    ])
  ],
  providers: [Service],
  bootstrap: [AppComponent]
})
export class AppModule { }
