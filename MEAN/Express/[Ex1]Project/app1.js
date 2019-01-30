//--EJERCICIO NUMERO 2--
//--INTEGRADO POR LOS ARCHIVOS
    //--app1.js
    //--Models/saludador.js

//--IMPLEMENTANDO EXPRESS CON EL METODO GET EN UNA RUTA ESTABLECIDAS
//--Comando para ejecutar text: node app.js


var express = require('express');
var saludador = require('./models/saludador');

var app = express();

//--Definimos la ruta saludo
//Ruta: http://localhost:8000/saludo?nombre=hugo
app.get('/saludo',(req,res)=>{
    var nombre = req.query.nombre;
    res.send('<h1>Hola '+ saludador.saludar(nombre)+'</h1>');
});

//--Definimos la ruta despedida
//Ruta: http://localhost:8000/despedida?nombre=hugo
app.get('/despedida',(req,res)=>{
    var nombre = req.query.nombre;
    res.send('<h1>Adios '+ saludador.saludar(nombre)+'</h1>');
});


// Decimos en que puerto queremos escuchar (el 8000)
app.listen(8000, function () {
    console.log("Esperando requests en el puerto 8000");
  });