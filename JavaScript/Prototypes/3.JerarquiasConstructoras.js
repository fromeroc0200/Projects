//--Creamos una function constructora
function HormigaComun() {
    this.cantidadDeAlimentoTransportado = 5;   
};

//--Creamos su prototype sobre la funcion constructora
HormigaComun.prototype = {
            recolectar: function(cantidad) {  
                        this.cantidadDeAlimentoTransportado += cantidad;
            },
            cantidadARecolectar: function(cantidad) {
                        return cantidad;
            }
};

function HormigaConEsteroides(cantidadEsteroides){
    this.cantidadEsteroides = cantidadEsteroides;
}

var unaHormiga = new HormigaConEsteroides(10);

console.log('La cantidad de esteroides es: ' + unaHormiga.cantidadEsteroides);
//--No se mostrara nada ya que se inicializo HormigaConEsteroides y no inicializo a HormigaComun y nos marcara 'undefined'
console.log('Cantidad de alimento transportado: ' + unaHormiga.cantidadDeAlimentoTransportado);


function HormigaConEsteroides2(cantidadEsteroides){
    //--Con esto inicializamos los atributos de la HormigaComun
    HormigaComun.call(this);
    this.cantidadEsteroides = cantidadEsteroides;
}

var otraHormiga = new HormigaConEsteroides2(20);
console.log('La cantidad de esteroides es: ' + otraHormiga.cantidadEsteroides);
//--Ya se muestra el valor a causa de que fue inicializado el atributo de HormigaComun
console.log('Cantidad de alimento transportado: ' + otraHormiga.cantidadDeAlimentoTransportado);