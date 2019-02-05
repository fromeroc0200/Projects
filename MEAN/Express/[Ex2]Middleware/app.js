

var express = require('express');
var app = express();
var routes = require('./config/routes')

app.use(express.static('public'));

//--Este es el middleware
function LogMiddleware(req, res, next){
    console.log('la url es: ' + req.url);
    next();
}


//--Mandamos llamar al middleware (imprime un mensaje en el log)
app.use(LogMiddleware);

routes(app);

app.listen(8000,()=>{console.log("Esperando respuesta puerto 8000")});