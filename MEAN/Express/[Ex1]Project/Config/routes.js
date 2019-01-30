//--Especificamos la rura del controlador
var saludador = require('../controllers/saludadorController');

module.exports = function(app){    
    app.get('/saludo', saludador.saludo);
    app.get('/despedida', saludador.despedida);
};