var http = require('http');
var url = require('url');
var saludador = require("./models/saludador");
//--Creamos un servidor
var server = http.createServer(function(req, res){
    var query = url.parse(req.url, true).query;
    res.writeHead(200,{"Content-Type": "text/html"});
    res.end("valor: "+ saludador.saludar(query.nombre));

});

server.listen(8000);