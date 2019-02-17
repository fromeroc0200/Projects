
// Dada una golondrina
var pepita = { nombre: "Pepita", energia: 200};
/**
 * Funcion inmutable que simula como come una golondrina. Por cada alpiste
 * que come, la golondrina aumenta 10 veces la cantidad de gramos en energia
 */

function comer(golondrina, alpiste) { 
    return {
          nombre: golondrina.nombre,
          energia: golondrina.energia + 10 * alpiste
    }
}

/**
 * Funcion inmutable que simula como vuela una golondrina. Por cada kilometro
 * que vuela, la golondrina gasta 2 puntos de energia.
 */
function volar(golondrina, distancia) {
 
  return{
    energia: golondrina.energia - (2*distancia), 
    nombre:golondrina.nombre}
}



var vol = volar(pepita, 10); // Deberia devolver { nombre: "Pepita", energia: 180}
var obj = comer(pepita, 4);  // Deberia devolver { nombre: "Pepita", energia: 250}
var obj2 = comer(volar(pepita, 10), 2); // Deberia devolver { nombre: "Pepita", energia: 230}
// pepita deberia seguir teniendo energia 200. Eso es lo que hace que las funciones
// sean inmutables