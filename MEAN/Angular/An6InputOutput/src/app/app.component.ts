import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'An6InputOutput';
  pData = 'I am parent component';
  pcData: string;

  /*Recibe el evento del child component*/
  receivedValue($event) {
    this.pcData = $event;
  }
}
