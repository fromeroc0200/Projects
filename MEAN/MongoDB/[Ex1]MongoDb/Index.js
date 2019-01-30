
const MongoClient = require('mongodb').MongoClient

const mongoUrl = process.env.MONGO_URL || 'mongodb://localhost:27017/test';
MongoClient.connect(mongoUrl, function (err, base) {
    if (err) {
        console.log(err);
        return;
    }

    //--Especificamos la db a la cual nos vamos a conectar
    var dbo = base.db("test");

    //--Indicamos la coleccion (tabla)
    var usuarios = dbo.collection('usuarios');

    //--indicamos la accion a realizar
    var act = 2;

    switch(act){
        case 1:
            //-- Funcionalidad de insert a DB mongo
            var hern = { nombre: 'Hernan' };

            //--inserta registro
            usuarios.insertOne(hern, (err, result) => {
                if (err) {
                    console.log(err);
                    return;
                }
                console.log('id: ' + result.insertedId);
                base.close();
            });
            break;
        case 2:
             usuarios.find({}).toArray((err, users) => {
                
                    if (err) {
                        console.log(err);
                        return;
                    }
                    console.log('Los usuarios son: ', users);
                    base.close();
                });
            break;
    }

    
});
/*
const http = require('http')
const port = 3000

const mongoUrl = process.env.MONGO_URL || 'mongodb://localhost:27017/test';

http.createServer((req, res) => {
  // Use connect method to connect to the Server
  MongoClient.connect(mongoUrl, (err, db) => {
    if (err) {
      res.writeHead(500, {'Content-Type': 'text/plain'})
      res.end('BOOM algo salio mal: ' + err)
    } else {
      res.writeHead(200, {'Content-Type': 'text/plain'})
      res.end('Me conecte a la DB jujuju!')
      db.close();
    }
  });
}).listen(port, err => {
  console.log('Server listening at *:', port)
});

*/