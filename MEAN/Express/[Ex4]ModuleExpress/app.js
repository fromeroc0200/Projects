var express = require('express');
var routes = require('./config/Routes');
var exphbs = require('express-handlebars');

var app = express();
app.engine('handlebars', exphbs());
app.set('view engine','handlebars');

//Se manda llamar al config del routing
routes(app);


app.listen(8000,()=>{console.log('Esperando respuesta puerto 8000')});