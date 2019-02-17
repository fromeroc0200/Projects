//--calcular la sumatoria de array

//--Este es el caso base usando foreach
function sumatoriafor(lista) {
    var resultado = 0;
    lista.forEach(function(x) { resultado += x });
    return resultado;
  }
  
//-Creamos una function recursiva
  function factorial(n) {
    if(n == 0) {
       return 1
    } else  {
        return factorial(n-1) * n
    }
  }

  var result = factorial(4);
  console.log('El resultado recursivo es: ' + result);