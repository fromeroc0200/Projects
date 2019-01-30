var http = require("http");
var fs = require("fs");
var server = http.createServer(function(req, res){
    console.log(req.url);
    if(req.url === "/"){
        fs.readFile("./index.html", function(err, data){
            res.writeHead(200, {"Content-Type": "text/html"});
            res.end(data);
        });
    } else if (req.url === "/img/logo.jpg"){
        fs.readFile("./img/logo.jpg", function(err, data){
            res.writeHead(200, {"Content-Type": "image/jpg"});
            res.end(data);
        });        
    }else{
        res.writeHead(404, {"Content-Type": "text/html"});
            res.end("pagina no encontrada");
    }
    console.log(req.url);
});

server.listen(8000);

console.log("Esperando request en el puerto 8000");