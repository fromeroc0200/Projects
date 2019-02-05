
var routes = require('./config/routes');
var express = require('express');
var exphbs = require('express-handlebars');
var app = express();

//--Establecemos la ruta estatica donde se encontraran los js,css e imagenes

app.engine('handlebars',exphbs({defaultLayout:'main'}));
app.set("view engine","handlebars");
app.use(express.static('public'));
routes(app);

app.listen(8000,()=> {console.log('Esperando repuesta por el puerto 8000')});
