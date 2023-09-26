import { Component } from "@angular/core";
import { CommonModule } from "@angular/common";
import { RouterLink, RouterLinkActive } from "@angular/router";

@Component({
  selector: "app-nav-bar",
  standalone: true,
  imports: [CommonModule, RouterLink, RouterLinkActive],
  template: `
    <div class="navbar bg-base-100">
      <div class="flex-1">
        <a class="btn btn-ghost normal-case text-xl">Frontend</a>
      </div>
      <div class="flex-none">
        <ul class="menu menu-horizontal px-1">
          <li>
            <a
              routerLink="dashboard"
              [routerLinkActive]="['link', 'link-active']"
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
                <li><a>Link 2</a></li>
              </ul>
            </details>
          </li>
        </ul>
      </div>
    </div>
  `,
  styles: [],
})
export class NavBarComponent {}
