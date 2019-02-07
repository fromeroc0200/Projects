
var express = require('express');
var users = express.Router();
var userController = require('../../Controllers/usercontroller');


//--Esta es una fuction middleware
function getUserDefault(req, res, next, id){
    setTimeout(()=>{
        id = 'Hugo';
        console.log('Se estan esperando 2 segundos: nuevo valor: ' + id);
        next();
    },2000);
}

//--Se añade el parametro al middleware y este se aplica a todas las peticiones http y no se tienen que declarar em cada peticion
//-- es decir se aplica el delay en todo el modulo users
users.param('id', getUserDefault);


//--Acompleta la ruta solicitando el id y ejecuta la peticion
//--api/user/:id
users.get('/:id', userController.Ver);

//--Acompleta la ruta y ejecuta la petición
//--api/user/:id/editar
users.get('/:id/editar', userController.Editar);

module.exports = users;