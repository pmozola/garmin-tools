import { Component, signal } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';
import { LoadingIndicator } from './components/loading-indicator/loading-indicator';
import { MatListItem, MatListModule } from '@angular/material/list';
import { MatButton, MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, LoadingIndicator, MatButtonModule, MatListModule, MatListItem, RouterLink],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('garmin-tools');
}
