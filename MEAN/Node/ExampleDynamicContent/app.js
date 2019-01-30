//comando de node para ejecutar pagina: node app.js
//--Ejemplo para pasarle parametros en la url (query parameters) '?nombre=valor'
//-- URL: http://localhost:8000/?nombre=fer

//--se instala nodemon que al momento de guardar se visualiza las modificaciones sin tener que ejeccutar un 'node [file.js]'
//-- npm install - nodemon
//-- se ejecuta el comando para hacerlo funcionar
//-- nodemon app.js

var http = require('http');

var url = require('url');

var server = http.createServer(function(req, res){
    var query = url.parse(req.url, true).query;
    res.writeHead(200,{"Content-Type" : "text/html"});
    res.end("<h1>Leyendo parametro de la url:" + query.nombre +"</h1>");
});

server.listen(8000);

console.log("Esperando un contenido puerto");