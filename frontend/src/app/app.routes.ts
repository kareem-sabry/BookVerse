import { Routes } from '@angular/router';
import { BookListComponent } from './features/catalog/book-list/book-list.component';
import { BookDetailComponent } from './features/catalog/book-detail/book-detail.component';
import { LoginComponent } from './features/auth/login/login.component';
import { RegisterComponent } from './features/auth/register/register.component';
import { CartComponent } from './features/cart/cart/cart.component';
import { OrderListComponent } from './features/orders/order-list/order-list.component';
import { OrderDetailComponent } from './features/orders/order-detail/order-detail.component';
import { BookAdminComponent } from './features/admin/book-admin/book-admin.component';
import { BookFormComponent } from './features/admin/book-form/book-form.component';

export const routes: Routes = [
    { path: '', redirectTo: '/books', pathMatch: 'full' },
    { path: 'books', component: BookListComponent },
    { path: 'books/:id', component: BookDetailComponent },
    { path: 'login', component: LoginComponent },
    { path: 'register', component: RegisterComponent },
    { path: 'cart', component: CartComponent },
    { path: 'orders', component: OrderListComponent },
    { path: 'orders/:id', component: OrderDetailComponent },
    { path: 'admin/books', component: BookAdminComponent },
    { path: 'admin/books/new', component: BookFormComponent },
    { path: 'admin/books/:id/edit', component: BookFormComponent },
    { path: '**', redirectTo: '/books' },
];
