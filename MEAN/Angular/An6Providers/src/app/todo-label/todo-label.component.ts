import { Component, OnInit, Input, Inject } from '@angular/core';
import { UNIQUE_ID } from '../id-generator.provider';

let NB_INSTANCES = 0;

@Component({
  selector: 'my-todo-label',
  templateUrl: './todo-label.component.html',
  styleUrls: ['./todo-label.component.scss']
})
export class TodoLabelComponent implements OnInit {


  constructor(@Inject(UNIQUE_ID) public checkboxId: string) {}

  ngOnInit() {
  }

}
