var users = require('../modules/Users/user')

module.exports= (app)=> {
    
    //--Indicamos el modulo a usuar al cual acompletara 
    //--la url api/user/(url modulo) ej. api/user/1/editar
    app.use('/api/users', users);
    
}