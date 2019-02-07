module.exports = {
    Ver:Ver,
    Editar: Editar
}

function Ver (req,res){
    res.locals.id= req.params.id;
    console.log(req.url);
    res.render('Users/Ver');
}

function Editar (req,res){
    res.locals.id= req.params.id;
    res.render('Users/Editar');
}