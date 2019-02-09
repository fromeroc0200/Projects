var express= require('express');
var user = require('../../Controllers/UserController');

var users = express.Router();

users.get('/nuevo', user.Nuevo);

users.post('/',user.PostUser);
//--URL http://localhost:8000/api/users/fer
users.get('/:id',user.Ver);

//--URL http://localhost:8000/api/users/fer/editar
users.get('/:id/Editar',user.Editar);


//--Forma de llamar metodos sin controller
/*users.get('/:id',(req, res) =>{
    res.locals.id = req.params.id;
    res.render('Users/Ver');
});


users.get('/:id/editar',(req, res)=>{
    res.locals.id = req.params.id;
    res.render('Users/Editar');
});
*/
//--Forma de llamar metodos sin controller


module.exports = users;