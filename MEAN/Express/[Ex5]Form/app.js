var express = require('express');
var exphbs = require('express-handlebars');
var app = express();
var bodyParser = require('body-parser');


app.use(express.static('public'));

app.use(bodyParser.urlencoded({extended:false}));
app.use(bodyParser.json());

app.engine('handlebars',exphbs({defaultLayout:'Main'}));
app.set('view engine','handlebars');
var routes = require('./Config/routes');

routes(app);

app.listen(8000,()=>{console.log('Esperando repuesta por el puerto 8000')});

