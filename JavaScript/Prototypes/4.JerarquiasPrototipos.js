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
    HormigaComun.call(this);
    this.cantidadEsteroides = cantidadEsteroides;
}

//--Creamos un protype para HormigaConEsteroides
HormigaConEsteroides.prototype = {

    cantidadARecolectar : function(cantidad){
        return cantidad + this.cantidadEsteroides;
    }
}

var unaHormiga = new HormigaConEsteroides(20);

console.log('Test1: Cantidad: ' + unaHormiga.cantidadEsteroides)
console.log('Test1: Cantidad Alimento: ' + unaHormiga.cantidadDeAlimentoTransportado)
console.log('Test 1: Cantidad recolectada: ' + unaHormiga.cantidadARecolectar(20));

///---------NOTA
//--Si queremos implementar la funcion recolectar no se podra ya que es un metodo definido en el prototipo de HormigaComun y mandara error
//unaHormiga.recolectar();  //---DESCOMENTAR PARA DEMOSTRAR EJEMPLO


//--------------------------------------------------------------------------------------
//--Pero si queremos implementarlo debemos asociar y deben ser creados aparatir de otro prototipo

//--Creamos el prototype apartir de HormigaComun.prototype
HormigaConEsteroides.prototype = Object.create(HormigaComun.prototype);
//--Añadimos de la siguiente manera las funciones propias o añadidas al HormigaConEsteroides.prototype
HormigaConEsteroides.prototype.cantidadARecolectar = function(cantidad){
    return cantidad + this.cantidadEsteroides;
}

var unaHormiga2 = new HormigaConEsteroides(5);

console.log('Test 2: Cantidad esteroides: ' + unaHormiga2.cantidadEsteroides);
console.log('Test 2: Cantidad AlimentoTransportado: ' + unaHormiga2.cantidadDeAlimentoTransportado);
//--De esta manera ya podremos implementar las funciones de HormigaComun
unaHormiga2.recolectar(5);
console.log('Test 2: Cantidad AlimentoTransportado mas recolecta de 5 unidades es: ' + unaHormiga2.cantidadDeAlimentoTransportado);
console.log('Test 2: Cantidad recolectada: ' + unaHormiga2.cantidadARecolectar(20));