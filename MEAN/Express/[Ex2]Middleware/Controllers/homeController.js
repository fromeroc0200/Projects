
//--Exportamos las funcionalidades
module.exports = {
    BuildCats:BuildCats,
    GetCats:GetCats
}

//---------------------FUNCIONES SECTION----------------------
//--Creamos las funciones que vamos a realizar


function BuildCats(req, res){
        res.send({
            cats:[{name: 'lilly'}, {name: 'lucy'}]
        });
};

function GetCats(req,res){
    var nameCat = req.params.name;
    res.locals.name = req.params.name;
    console.log(res.locals.name);
    res.send({name: nameCat});
}

//---------------------FUNCIONES SECTION----------------------