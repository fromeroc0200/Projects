import { Component, OnInit } from '@angular/core';

/*Importamos los servicios y lo que necesita para API asu como se realizo primero en Users*/
import { DataService } from '../data.service';
import { Observable} from 'rxjs';
/* Agregamos otro  */
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.scss']
})
export class DetailsComponent implements OnInit {

  user$: Object;

  constructor(private data: DataService, private route: ActivatedRoute) {
    this.route.params.subscribe( params => this.user$ = params.id);
  }

  /* Este es el hooks ngOnInit*/
  ngOnInit() {
    this.data.getUser(this.user$).subscribe(data => this.user$ = data);
  }

}
