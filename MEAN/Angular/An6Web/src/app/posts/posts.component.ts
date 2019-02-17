import { Component, OnInit } from '@angular/core';
/*Importamos los servicios y lo que necesita para API asu como se realizo primero en Users*/
import { DataService } from '../data.service';
import { Observable} from 'rxjs';


@Component({
  selector: 'app-posts',
  templateUrl: './posts.component.html',
  styleUrls: ['./posts.component.scss']
})
export class PostsComponent implements OnInit {

  posts$: object;

  constructor(private data: DataService) { }

  /* Este es el hooks ngOnInit*/
  ngOnInit() {

    this.data.getPost().subscribe(data => this.posts$ = data);
  }

}
