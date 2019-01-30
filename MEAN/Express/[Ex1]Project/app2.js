//--EJERCICIO NUMERO 3 MVC with Handlebars--
//--INTEGRADO POR LOS ARCHIVOS
    //--app2.js
    //--Models/saludador.js
    //--Controllers/saludadorController.js
    //--Config/routes.js
    //--Views/saludo.handlebars
    //--Views/Layouts/main.handlebars

//--IMPLEMENTANDO EXPRESS CON EL METODO GET EN UNA RUTA DEFAULT
//--Comando para ejecutar text: node app.js

var express = require('express');
var routes = require('./config/routes');
var exphbs  = require('express-handlebars');

// Lo iniciamos
var app = express();

//--definimos una plantilla layout

app.engine('handlebars', exphbs({defaultLayout : 'main'}));
app.set('view engine', 'handlebars');
//--Los metodos se aplican al llamado del Config/routes.js
routes(app);

app.listen(8000, ()=>{
    console.log('Esperando repsuesta en el puerto 8000')
});


