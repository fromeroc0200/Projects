var express = require('express');
var routes = require('./config/routes');

var app = express();

routes(app);


app.listen(8000, ()=>{console.log('Esperando respuesta puero 8000')});
