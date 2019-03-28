import { Component, OnInit } from '@angular/core';
import { DataService } from '../../data.service';

@Component({
  selector: 'app-ngfor',
  templateUrl: './ngfor.component.html',
  styleUrls: ['./ngfor.component.scss']
})
export class NgforComponent implements OnInit {

  users$: object;

  constructor(private data: DataService) { }

  ngOnInit() {
    this.data.getUsers().subscribe(
      data => this.users$ = data
    );
  }

}
