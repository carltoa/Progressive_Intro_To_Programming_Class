import { Component } from "@angular/core";
import { CommonModule } from "@angular/common";
import { RouterLink, RouterLinkActive } from "@angular/router";
import { TodoSummaryComponent } from "../todo-summary.component";

@Component({
  selector: "app-nav-bar",
  standalone: true,
  template: `
    <div class="navbar bg-base-100">
      <div class="flex-1">
        <a class="btn btn-ghost normal-case text-xl">Frontend</a>
        <app-todo-summary />
      </div>
      <div class="flex-none">
        <ul class="menu menu-horizontal px-1">
          <li>
            <a routerLink="dashboard" [routerLinkActive]="['link', 'link-active']"
              >Dashboard</a
            >
          </li>
          <li>
            <a routerLink="support" [routerLinkActive]="['link', 'link-active']"
              >Support</a
            >
          </li>
          <li>
            <details>
              <summary>Demos</summary>
              <ul class="p-2 bg-base-100">
                <li><a routerLink="todos">Todos</a></li>
                <li><a routerLink="admin">Admin Stuff</a></li>
                <li><a routerLink="counter">Counter</a></li>
              </ul>
            </details>
          </li>
        </ul>
      </div>
    </div>
  `,
  styles: [],
  imports: [CommonModule, RouterLink, RouterLinkActive, TodoSummaryComponent]
})
export class NavBarComponent { }
