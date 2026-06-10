import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BookListComponent } from './features/catalog/book-list/book-list.component';
import { BookDetailComponent } from './features/catalog/book-detail/book-detail.component';
import { LoginComponent } from './features/auth/login/login.component';
import { RegisterComponent } from './features/auth/register/register.component';
import { CartComponent } from './features/cart/cart/cart.component';
import { OrderListComponent } from './features/orders/order-list/order-list.component';
import { OrderDetailComponent } from './features/orders/order-detail/order-detail.component';
import { BookAdminComponent } from './features/admin/book-admin/book-admin.component';
import { BookFormComponent } from './features/admin/book-form/book-form.component';
import { NavbarComponent } from './shared/components/navbar/navbar.component';
import { BookCardComponent } from './shared/components/book-card/book-card.component';
import { LoadingSpinnerComponent } from './shared/components/loading-spinner/loading-spinner.component';

@NgModule({
  declarations: [
    AppComponent,
    BookListComponent,
    BookDetailComponent,
    LoginComponent,
    RegisterComponent,
    CartComponent,
    OrderListComponent,
    OrderDetailComponent,
    BookAdminComponent,
    BookFormComponent,
    NavbarComponent,
    BookCardComponent,
    LoadingSpinnerComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
