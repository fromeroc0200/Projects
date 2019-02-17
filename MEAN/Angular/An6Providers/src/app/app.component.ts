import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'An6Providers';
  /*Añadimos los textos para los labels*/
  todos = ['Stop using TODO examples', '???', 'Profit!'];
}
