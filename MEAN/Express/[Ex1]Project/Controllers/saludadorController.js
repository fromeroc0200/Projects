var saludador = require('../models/saludador');
module.exports= {
        saludo : saludo,
        despedida : despedida
}

//--Utilizamos handlebars para usar el template views/saludo.handlebars por medio del metodo res.render()
function saludo (req, res) {
        var nombre = req.query.nombre;
        //--se indica la vista a utilzar en el primer parametro y posteriormente los  databindings {{value}}, ej. {{mensaje}}
        res.render('saludo', {mensaje :  saludador.saludar(nombre)});
        }

//------------------------------------------------------------------------------------------------------------
/*
//--Esta es la forma sin utilizar una vista y colocando directamente el codigo para la 'funcion saludo'
function saludo (req, res) {
        var nombre = req.query.nombre;
        res.send('<h1>Hola ' + saludador.saludar(nombre) + ' estas usando controladores.</h1>');
        }
*/


//--Esta es la forma sin utilizar una vista y colocando directamente el codigo
function despedida (req, res) {
        var nombre = req.query.nombre;
        res.send('<h1>Chau ' + saludador.saludar(nombre) + ' dejaste de usar controladores.</h1>');
        }