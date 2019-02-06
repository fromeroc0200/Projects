var user = require('../controllers/userController');

function getUserDefault(req, res, next){
    setTimeout(()=>{
        //--Se modifica la variable local
        res.locals.userName ='Fercho';
        console.log(res.locals.userName );
        
        next();
    }, 2000);
}

//-- manda llamar el middleware primero y despues a la funcion del controlador
module.exports = (app) => {
    app.get('/api/user/:userName',[ getUserDefault, user.GetUser ]);
}