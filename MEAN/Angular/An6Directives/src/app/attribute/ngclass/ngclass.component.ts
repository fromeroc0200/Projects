import { Component, OnInit } from '@angular/core';
import { Users } from '../../users';

@Component({
  selector: 'app-ngclass',
  templateUrl: './ngclass.component.html',
  styleUrls: ['./ngclass.component.scss'],
  providers: [Users]
})
export class NgclassComponent implements OnInit {

  users$: object;
  constructor(private obj: Users) { }

  ngOnInit() {
    this.users$ = this.obj.users;
  }

}
