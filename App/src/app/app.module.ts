import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UiKitModule } from '@ui-kit';
import { HttpService } from './services/http.service';
import { HttpClientModule } from '@angular/common/http';
import {
  HeaderComponent,
  HomeComponent,
  FooterComponent,
  LoginComponent,
  RegisterComponent,
  AboutUsComponent,
  PricingComponent,
  DeveloperPreviewComponent,
  DeveloperComponent,
  SearchComponent,
  ProjectComponent,
  ProjectPreviewComponent,
  CompanyComponent,
  CompanyPreviewComponent,
  ProfileComponent,
  WalletComponent,
  SettingsComponent,
  SubscriptionsComponent,
  ProjectMiniPreviewComponent,
  PostComponent,
  PostPreviewComponent,
  PreviewBaseComponent,
  ViewBaseComponent
} from './components';
import { SwiperModule } from 'swiper/angular';
import { RangePipe } from './range.pipe';

@NgModule({
  imports: [
    HttpClientModule, 
    BrowserModule, 
    AppRoutingModule, 
    UiKitModule,
    SwiperModule
  ],
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
    SearchComponent,
    ProjectComponent,
    ProjectPreviewComponent,
    CompanyComponent,
    CompanyPreviewComponent,
    ProfileComponent,
    WalletComponent,
    SettingsComponent,
    SubscriptionsComponent,
    ProjectMiniPreviewComponent,
    RangePipe,
    PostComponent,
    PostPreviewComponent,
    PreviewBaseComponent,
    ViewBaseComponent,
  ],
  providers: [HttpService],
  bootstrap: [AppComponent],
})
export class AppModule {}
