//--EJERCICIO NUMERO 1--
//--INTEGRADO POR LOS ARCHIVOS
    //--app.js
    //--Models/saludador.js

//--IMPLEMENTANDO EXPRESS CON EL METODO GET EN UNA RUTA DEFAULT
//--Comando para ejecutar text: node app.js


//--Llamamos al modulo y obtenemos sus funciones
var saludador = require("./models/saludador");
//--Se agrega el modulo express
var express = require('express');

//--Generamos el objeto express
var app = express();

//--usamos el metodo GET de http
//Ruta: http://localhost:8000/?nombre=hugo
app.get('/',(req,res)=>{
    //--Obtenemos el nombre
    var nombre =req.query.nombre;
    res.send('<h1>Hola '+ saludador.saludar(nombre) +'</h1>');
})

// Decimos en que puerto queremos escuchar (el 8000)
app.listen(8000, function () {
    console.log("Esperando requests en el puerto 8000");
  });
  
//app.use(app.router);