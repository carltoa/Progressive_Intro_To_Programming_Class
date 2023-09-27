import { Component } from "@angular/core";
import { CommonModule } from "@angular/common";

@Component({
  selector: "app-heading",
  standalone: true,
  imports: [CommonModule],
  template: `
    <header class="border-gray-400 border-4 p-4 mb-4">
      <h1 class="text-center font-black uppercase text-2xl">Angular App</h1>
      <h2 class="text-center capitalize text-red-400">Intro to Programming</h2>
    </header>
  `,
  styles: [],
})
export class HeadingComponent { }
