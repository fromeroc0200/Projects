
function startsWith(str1, str2){
	var index= str2.indexOf(str1);
	return index == 0 ? true : false;
}

console.log('El resultado de la comparacion es: '+ startsWith('Hola', 'Holass'));