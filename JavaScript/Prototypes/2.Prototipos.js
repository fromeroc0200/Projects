
//--Creamos una function constructora
function HormigaComun(cantidadDeAlimentoTransportado) {
                        this.cantidadDeAlimentoTransportado = cantidadDeAlimentoTransportado;   
};

//--Creamos su prototype sobre la funcion constructora
    HormigaComun.prototype = {
                                recolectar: function(cantidad) {  
                                            this.cantidadDeAlimentoTransportado += cantidad;
                                },
                                entregarAlimentoA: function(hormiguero) {
                                            hormiguero.depositarAlimento(this.cantidadDeAlimentoTransportado);
                                            this.cantidadDeAlimentoTransportado = 0;
                                }
    };

    //--Creamos un objeto Hormiga Comun
    var otraHormiga = new HormigaComun(10);
    
    console.log('CantidadAlimentoTransportado: '+ otraHormiga.cantidadDeAlimentoTransportado );
    //--Le indicamos el mensaje a ejecutar
    otraHormiga.recolectar(2);
    console.log('Se recolecta 2 unidades y el resultado es: '+ otraHormiga.cantidadDeAlimentoTransportado);
    




    //--Se crea la function constructora hormiguero 
    function Hormiguero(cantidadDeAlimento,hormigas){
                        this.cantidadDeAlimento =cantidadDeAlimento;
                        this.hormigas = hormigas;                    
    }
    
    //--Se asigna el  prototipo al hormiguero 
    Hormiguero.prototype = {
                            depositarAlimento: function(cantidadAlimento) {
                                    this.cantidadDeAlimento += cantidadAlimento;
                            },
                            agregarHormiga: function(hormiga) {
                                    this.hormigas.push(hormiga);
                            },
                            reclamarAlimento: function(hormiga) {
                                                this.hormigas.forEach(function(h){
                                                h.entregarAlimentoA(this);
                                                }, this);
                            },
                            expulsar: function(cantidad) {
                                        this.hormigas.splice(0, 2);
                            }
    
    };
    
    //--Creamos function constructora
    function HormigaGuerrera(cantidadDeAlimento){
    
    }
    //--Le asiganamos un prototipo
    HormigaGuerrera.prototype = {
                                entregarAlimentoA: function(hormiguero) {
                                                    //--no ejecuta ninguna acción por que es guerrera
                                                    }
    }

    