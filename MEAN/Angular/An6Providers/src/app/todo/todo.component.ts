import { Component, OnInit, Inject } from '@angular/core';
import { UNIQUE_ID_PROVIDER, UNIQUE_ID } from '../id-generator.provider';

/*let NB_INSTANCES = 0;*/

@Component({
  selector: 'my-todo',
  templateUrl: './todo.component.html',
  styleUrls: ['./todo.component.scss'],
  providers: [UNIQUE_ID_PROVIDER]
})
export class TodoComponent implements OnInit {

  constructor(@Inject(UNIQUE_ID) public id: string) {}

  ngOnInit() {

  }

}
