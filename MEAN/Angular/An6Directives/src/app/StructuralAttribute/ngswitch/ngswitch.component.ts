import { Component, OnInit } from '@angular/core';
import { Places } from '../../places';

@Component({
  selector: 'app-ngswitch',
  templateUrl: './ngswitch.component.html',
  styleUrls: ['./ngswitch.component.scss'],
  providers: [Places]
})
export class NgswitchComponent implements OnInit {

  places$: object;

  constructor(private obj: Places) { }

  ngOnInit() {
    this.places$ = this.obj.places;
  }

}
