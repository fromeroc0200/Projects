import { Component, OnInit } from '@angular/core';
import { Users } from '../../users';
@Component({
  selector: 'app-ngif',
  templateUrl: './ngif.component.html',
  styleUrls: ['./ngif.component.scss'],
  providers: [Users]
})
export class NgifComponent implements OnInit {

  users$: object;
  constructor(private obj: Users) { }

  ngOnInit() {
    this.users$ = this.obj.users;
  }

}
