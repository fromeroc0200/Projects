import { Component, OnInit } from '@angular/core';
/**/
import { Users } from '../../users';

@Component({
  selector: 'app-ngstyle',
  templateUrl: './ngstyle.component.html',
  styleUrls: ['./ngstyle.component.scss'],
  providers: [Users]
})
export class NgstyleComponent implements OnInit {

  users$: object;
  constructor(private obj: Users) { }

  ngOnInit() {
    this.users$ = this.obj.users;
  }

}
