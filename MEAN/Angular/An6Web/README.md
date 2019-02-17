#Process to Do a Angular project
npm install -g @angular/cli
ng new [nombreProyecto] --style=[tipo de css] --routing
ng g c [nombreComponente] (es para generar los componentes)
ng g s [nombreDelServico] (crea servicios de angular)


npm install @angular/animations@latest --save (se instalan complementos de animacion de angular)

#Steps to do this project
Editamos app
  - Modificamos app.component.html para mostrar app-sidebar y el contenido del routing
  - Creamos los componentes posts, users, details, sidebar con : ng g c [nombre]
  - Iniciamos con el componente de usuarios
    1.- modificamos su html
  - Creamos el servico con : ng g s [nombreServicio]

- Se instalan modulos de animacion de angular con: npm install @angular/animations@latest --save
  -En app.Module.ts
      - Agregamos por ultimo modulo de animación  import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
      - lo añadimos a imports el modulo BrowserAnimationsModule

# An6Web

This project was generated with [Angular CLI](https://github.com/angular/angular-cli) version 7.3.1.

## Development server

Run `ng serve` for a dev server. Navigate to `http://localhost:4200/`. The app will automatically reload if you change any of the source files.

## Code scaffolding

Run `ng generate component component-name` to generate a new component. You can also use `ng generate directive|pipe|service|class|guard|interface|enum|module`.

## Build

Run `ng build` to build the project. The build artifacts will be stored in the `dist/` directory. Use the `--prod` flag for a production build.

## Running unit tests

Run `ng test` to execute the unit tests via [Karma](https://karma-runner.github.io).

## Running end-to-end tests

Run `ng e2e` to execute the end-to-end tests via [Protractor](http://www.protractortest.org/).

## Further help

To get more help on the Angular CLI use `ng help` or go check out the [Angular CLI README](https://github.com/angular/angular-cli/blob/master/README.md).
