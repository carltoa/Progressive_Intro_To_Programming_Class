import { Routes } from "@angular/router";
import { HomeComponent } from "./pages/home/home.component";
import { SupportComponent } from "./pages/support/support.component";
import { TodosComponent } from "./pages/todos/todos.component";

export const routes: Routes = [
  {
    path: "dashboard",
    component: HomeComponent,
  },
  {
    path: "support",
    component: SupportComponent,
  },
  {
    path: 'todos',
    component: TodosComponent
  },

  {
    path: "**",
    redirectTo: "dashboard",
  },
];
