//------------- SEECCION USO MODULO CORE FILE SYSTEM ----------------


//--- lectura forma sincrona
var fs = require('fs');
var resultado = fs.readFileSync("NodeFileTest.txt");
console.log(resultado.toString());

//--- lectura forma asincrona
fs.readFile("NodeFileTest.txt",function(err, data){
    if(err) throw err;
    console.log("Imprimiendo resultado forma asincrona");
    console.log(data.toString());
});



//------------- Seccion para implementar un modulo llamado chalk ----
//------------- (agrega color al texto) y se instala con: -----------
//------------- npm install chalk -----------------------------------

// Obtengo una referencia a la librería
var chalk = require('chalk');

// Configuro los colores
var azul = chalk.blue;
var verde = chalk.green;
// Uso los colores
console.log(azul('Acamica'));
console.log(verde('Exito'));

//-------------- Seccion para pasar parametro --------------------- 
//-- node index.js Fernando 
//-- Output.- Nombre de usuario: Fernando
var username = process.argv[2];

console.log("Nombre de usario: " + username);
