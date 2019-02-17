//-- comando de node para testear
//-- node FuncionesConstructoras.js


//--Creamos funcion constructora
function Celular(nEnergia, nMaxEnergia){
    //--Se inicializan los atributos
    this.nivelEnergia = nEnergia;
    this.nivelMaximoEnergia= nMaxEnergia;
}

//--Se crea un nuevo objeto con parametros inicializados
var nuevoCelular = new Celular(10, 500);

//--Iprimimos los valor ya inicializados
console.log('Los valores son: nivelEnergia: ' + nuevoCelular.nivelEnergia + ' nivelMaximoEnergia: ' + nuevoCelular.nivelMaximoEnergia );
