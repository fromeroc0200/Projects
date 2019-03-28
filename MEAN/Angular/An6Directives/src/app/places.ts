/*Esta clase se utiliza como provider - suple un objeto para varios componentes que lo usan para ejemplificar funcionalidad*/
export class Places {
  places = [
           {
             id: '1',
             name: 'Mexico',
             distance: 1,
             nearness: 1,
             active: true
           },
           {
             id: '2',
             name: 'USA',
             distance: 1.8,
             nearness: 1,
             active: false
           },
           {
             id: '3',
             name: 'Spain',
             distance: 10,
             nearness: 2,
             active: true
           },
           {
             id: '4',
             name: 'Canada',
             distance: 35,
             nearness: 3,
             active: false
           },
           {
             id: '5',
             name: 'Europe',
             distance: 120,
             nearness: 4,
             active: false
           }
 ];
 }
