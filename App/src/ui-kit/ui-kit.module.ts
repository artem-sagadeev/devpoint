import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { DevpointButtonComponent } from './components';
import { AppRoutingModule } from '../app/app-routing.module';

const components = [DevpointButtonComponent];

@NgModule({
  imports: [BrowserModule, AppRoutingModule],
  declarations: components,
  exports: components,
})
export class UiKitModule {}
