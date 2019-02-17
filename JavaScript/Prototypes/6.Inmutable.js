var tanque = {nivelDeNafta:0, volumenMaximo:100};

//--no se modifica el tanque actual o anteriormente creado
function cargarTanque(tanque, litrosDeNafta) {
    return {
      nivelDeNafta: tanque.nivelDeNafta + litrosDeNafta,
      volumenMaximo: tanque.volumenMaximo 
   };
 }

 var nuevoTanque = cargarTanque(tanque, 10);
 //--Se aumenta el valor de nivelDeNafta de 0 a 10
 console.log('Se obtiene un objeto nuevo: ' + nuevoTanque.nivelDeNafta + ' - ' + nuevoTanque.volumenMaximo );
 //--Mostramos info del objeto original y no es modifcado
 console.log('Se obtiene original: ' + tanque.nivelDeNafta + ' - ' + tanque.volumenMaximo );