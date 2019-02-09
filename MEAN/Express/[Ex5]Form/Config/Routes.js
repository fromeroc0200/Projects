var users = require('../Modules/Users/user');
module.exports = (app)=> {
    app.use('/api/users', users);
    //--Manejo de URL no encontrada, por si se ingresa una URL que no exista,
    //-- mandara el mensaje establecido, ej URL: http://localhost:8000/api/users
    app.use((req,res)=>{res.status(404).send('Pagina no encontrada');});
    
    //--Como usar
    app.use((err,req,res,next)=>{
        console.log(err);
        res.status(500).send('Ups hubo un error');
        next();
    });
}