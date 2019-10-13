import { enableProdMode } from '@angular/core';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

import { AppModule } from './app/app.module';
import { environment } from './environments/environment';

export function getBaseUrl() {
  debugger;
  return document.getElementsByTagName('base')[0].href;
}

export function getOrdersUrl() {
  return 'https://localhost:5001/api/orders/';
}

const providers = [
  { provide: 'BASE_URL', useFactory: getBaseUrl, deps: [] },
  { provide: 'ORDERS_API_URL', useFactory: getOrdersUrl, deps: [] },
];

if (environment.production) {
  enableProdMode();
}

platformBrowserDynamic(providers).bootstrapModule(AppModule)
  .catch(err => console.log(err));
